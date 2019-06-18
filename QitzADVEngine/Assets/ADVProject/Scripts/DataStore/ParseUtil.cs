using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using System.Linq;
using Qitz.ADVGame;

public sealed class ParseUtil
{
    const string WHITE_SPACE = " \t\r";			// 空白扱いにする記号(タブ, 復帰)
    const string WORD_BREAK = " \t\r{}[]【】,:\"=";	// ワードを区切る記号
    const string CUT_BREAK = "\n";

    // TODO 自動生成
    private static readonly string[] characterList = new[]
    {
        "永峰あさひ",
        "森若ちとせ",
        "藤枝アキラ",
        "女子生徒１",
        "加賀谷ソウ",
        "男子生徒１",
        "南啓一",
    };
    
    // TODO 自動生成
    private static readonly string[] costumeList = new[]
    {
        "制服(冬服)",
        "私服(部屋着)",
        "私服(コート)",
        "冬服",
        "私服(冬服)",
    };
    
    //TODO 自動生成
    private static readonly string[] faceList = new[]
    {
        "真顔",
        "悲しみ",
        "真顔(眼鏡)",
        "半目",
        "半目(眼鏡)",
        "微笑",
        "笑顔",
        
    };

    private StringReader	m_reader;

    private enum MToken
    {
        None,			//
        CommandOpen,	// [
        CommandClose,	// ]
        CharaNameOpen,  // 【
        CharaNameClose,  // 】
        SemiColon,      // ;
        Message,        // Any Character
        Null,			// null
    }

    // TODO 自動生成
    private enum CommandList
    {
        Comment,
        Event,
        Wait,
        BackGround,
        BGM,
        SE,
        MessageOn,
        MessageOff,
        
    }
    
    public ParseUtil( string macroText )
    {
        
        m_reader = new StringReader( macroText );
    }

    public List<ICutVO> Deserialize()
    {
        List<ICutVO> cutVos = new List<ICutVO>();
        while (m_reader.Peek() != -1)
        {
            CutVO cutVo = new CutVO();
            cutVo.CaracterVO = new List<ICaracterVO>();
            cutVo.Effects = new List<IEffectVO>();
            cutVo.BackgroundVO = new BackgroundVO();
            while ( m_reader.Peek() != -1 && CUT_BREAK.IndexOf(PeekChar) != 0)
            {
                
                ParseValue(ref cutVo);
                m_reader.Read();
                if (m_reader.Peek() == -1 || CUT_BREAK.IndexOf(PeekChar) == 0)
                {
                    break;
                }
            }
            
            cutVos.Add(cutVo);
            
            m_reader.Read();
        }
        return cutVos;
    }
    
    // 空白を除去
    private void EatWhitespace()
    {
        while ( WHITE_SPACE.IndexOf( PeekChar ) != -1 ) {
            m_reader.Read();

            if ( m_reader.Peek() == -1 ) {
                break;
            }
        }
    }
    
    // 空白・改行を除去
    private void EatWhitespaceWithEnter()
    {
        while (WORD_BREAK.IndexOf(PeekChar) != -1 || CUT_BREAK.IndexOf(PeekChar) != -1) {
            
            m_reader.Read();

            if ( m_reader.Peek() == -1 ) {
                break;
            }
        }
    }
    
    // 次の文字を確認
    private char PeekChar { get { return Convert.ToChar( m_reader.Peek() ); } }
    // 次の文字へ進める
    private char NextChar { get { return Convert.ToChar( m_reader.Read() ); } }
    // 次の単語へ進める
    private string NextWord
    {
        get
        {
            StringBuilder word = new StringBuilder();

            while ( WORD_BREAK.IndexOf( PeekChar ) == -1 ) {
                word.Append( NextChar );

                if ( m_reader.Peek() == -1 ) {
                    break;
                }
            }

            return word.ToString();
        }
    }
    
    // 次の文章へ進める
    private string NextMessage
    {
        get
        {
            StringBuilder word = new StringBuilder();

            while ( CUT_BREAK.IndexOf( PeekChar ) == -1 ) {
                word.Append( NextChar );
                if ( m_reader.Peek() == -1 ) {
                    break;
                }
            }
            
            return word.ToString();
        }
    }
    
    // 次のトークンへ進める
    private MToken NextToken
    {
        get
        {
            //EatWhitespace();

            if ( m_reader.Peek() == -1 ) {
                return MToken.None;
            }

            char c = PeekChar;
            
            switch ( c ) {
                case ';':
                    EatWhitespace();
                    //var str = NextMessage;
                    m_reader.Read();
                    return MToken.SemiColon;
                case '[':
                    return MToken.CommandOpen;

                case ']':
                    //m_reader.Read();
                    return MToken.CommandClose;
                
                case '【':
                    return MToken.CharaNameOpen;
                case '】':
                    m_reader.Read();
                    return MToken.CharaNameClose;
                default:
                    return MToken.Message;
                    
                    break;

            }

            return MToken.None;
        }
    }
    
    // パース
    private void ParseValue(ref CutVO cutVo)
    {
        MToken nextToken = NextToken;

        ParseByToken( nextToken, ref cutVo );
    }
    
    // トークン別で分岐
    private void ParseByToken( MToken token, ref CutVO cutVo )
    {
        switch ( token ) {
            case MToken.SemiColon:
                //コメントは飛ばす
                string str = NextMessage;
                break;
            case MToken.CommandOpen:
                ParseCommand(ref cutVo);
                return;
            case MToken.CommandClose:
                m_reader.Read();
                return;
            
            case MToken.CharaNameOpen:
                ParseMessage(ref cutVo);
                return;
                
            case MToken.Message:
                ParseMessage(ref cutVo, withName: false);
                return;

            default:
                return;
        }
    }

    private void ParseCommand(ref CutVO cutVo)
    {
        string str;
        
        EffectVO eVo = new EffectVO();
        CharacterVO cVo = new CharacterVO();
        
        bool parsing = true;
        m_reader.Read();
        while ( parsing ) {
            
            
            if ( m_reader.Peek() == -1) {
                parsing = false;
                break;
            }

            str = NextWord;
            if (string.IsNullOrEmpty(str))
            {
                parsing = false;
                break;
            }
           
            eVo.EffectType = EffectType.NONE;
            // コマンドイベント
            //Debug.Log(str);
            switch (str)
            {
                case "messageoff":
                    eVo.EffectType = EffectType.MESSAGEOFF;
                    break;
                case "messageon":
                    eVo.EffectType = EffectType.MESSAGEON;
                    break;
                case "flash":
                    eVo.EffectType = EffectType.FLASH;
                    break;
                case "shake":
                    eVo.EffectType = EffectType.SHACKE;
                    break;
                case "blackout":
                    eVo.EffectType = EffectType.BLAKOUT;
                    break;
                case "hidecharacter":
                    eVo.EffectType = EffectType.HIDE_CARACTER;
                    break;
                case "ev":
                    eVo.EffectType = EffectType.EV;
                {
                    EatWhitespace();
                    string commandName = NextWord;
                    m_reader.Read();
                    m_reader.Read();
                    commandName = NextWord;
                }
                    break;
                case "暗転共通":
                    eVo.EffectType = EffectType.BLAKOUT;
                    break;
                case "wait":
                    eVo.EffectType = EffectType.WAIT;
                {
                    EatWhitespace();
                    string commandName = NextWord;
                }
                    break;
                case "bg":
                    eVo.EffectType = EffectType.BG;
                {
                    EatWhitespace();
                    string commandName = NextWord;
                    m_reader.Read();
                    m_reader.Read();
                    BackgroundVO backgroundVo = new BackgroundVO();
                    backgroundVo.SpriteBackGroundName = NextWord;
                    cutVo.BackgroundVO = backgroundVo;
                }
                    break;
                case "bgm":
                    
                {
                    EatWhitespace();
                    string bgmCommannd = NextWord;
                    if (bgmCommannd.Equals("stop"))
                    {
                        cutVo.BgmID = string.Empty;
                        continue;
                    }
                    // BGMファイル指定
                    else if (bgmCommannd.Equals("file"))
                    {
                        m_reader.Read();
                        m_reader.Read();
                        cutVo.BgmID = NextWord;
                        continue;
                    }
                }
                    break;
                // キャラクタコマンドもあるのでdefaultはException無し
                default:
                    //throw new Exception();
                    break;
            }

            // 何かしらコマンドイベントがあれば登録
            if (eVo.EffectType != EffectType.NONE)
            {
                cutVo.Effects.Add(eVo);
                continue;
            }
            

            // キャラの表示系イベント
            string characterName = characterList.FirstOrDefault(_ => _.Equals(str));

            if (characterName != null)
            {
                //キャラの名前を入れる
                cVo.Name = characterName;
                m_reader.Read();
                while (CUT_BREAK.IndexOf(PeekChar) != 0 && m_reader.Peek() != -1)
                {
                    //EatWhitespace();
                    str = NextWord;
                    switch (str)
                    {
                        case "出":
                            //デフォルト値を入れる
                            cVo.CharacterEffectType = CharacterEffectType.FADEIN;
                            break;
                        case "消":
                            //デフォルト値を入れる
                            cVo.CharacterEffectType = CharacterEffectType.FADEOUT;
                            break;
                        // 表示時間
                        case "time":
                            EatWhitespace();
                            //m_reader.Read();
                            string word = NextWord;
                            int time = 0;
                            int.TryParse(word, out time);
                            cVo.ShowTime = time;
                            
                            continue;
                        case CUT_BREAK:
                            m_reader.Read();
                            continue;
                        default:
                        {
                            //服判定
                            string costume = costumeList.FirstOrDefault(_ => _.Equals(str));
                            if (string.IsNullOrEmpty(costume))
                            {
                                cVo.SpriteBodyName = costume;
                            }
                            else
                            {
                                //顔判定
                                string face = faceList.FirstOrDefault(_ => _.Equals(str));
                                if (string.IsNullOrEmpty(face))
                                {
                                    cVo.SpriteFaceName = face;
                                }
                            }

                            break;
                        }
                    }

                    m_reader.Read();
                }
                cutVo.CaracterVO.Add(cVo);
            }

            parsing = false;
        }

        return;
    }

    private void ParseMessage(ref CutVO cutVo, bool withName = true)
    {
        WindowVO wVo = new WindowVO();
        CharacterVO cVo = new CharacterVO();
        
        
        string str;
        // 名前付きのメッセージなら名前を読み込む
        if (withName)
        {
            m_reader.Read();
            str = NextWord;
            string characterName = characterList.FirstOrDefault(_ => _.Equals(str));
            cVo.Name = characterName;
            
            EatWhitespaceWithEnter();
        }
        else
        {
            cVo.Name = string.Empty;
        }

        str = NextMessage;
        // 空白のみは無視する
        if (string.IsNullOrWhiteSpace(str))
        {
            return;
        }
        cutVo.WindowVO = new WindowVO();
        wVo.WindowText = str;
        wVo.WindowNaviCaracterVO = cVo;
        
        cutVo.WindowVO = wVo;
        m_reader.Read();
        
    }
}
