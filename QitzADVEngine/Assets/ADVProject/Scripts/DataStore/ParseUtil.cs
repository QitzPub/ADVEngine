using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using System.Linq;
using Qitz.ADVGame;
using static System.StringSplitOptions;

public sealed class ParseUtil
{
    //const string WHITE_SPACE = " \t\r";			// 空白扱いにする記号(タブ, 復帰)
    //const string WORD_BREAK = " \t\r{}[]【】,:\"=";	// ワードを区切る記号
    //const string CUT_BREAK = "\n";

    //private StringReader	m_reader;

    //private enum MToken
    //{
    //    None,			//
    //    CommandOpen,	// [
    //    CommandClose,	// ]
    //    CharaNameOpen,  // 【
    //    CharaNameClose,  // 】
    //    SemiColon,      // ;
    //    Message,        // Any Character
    //    Null,			// null
    //}
    
    //public ParseUtil( string macroText )
    //{
        
    //    m_reader = new StringReader( macroText );
    //}

    //public List<ICutVO> Deserialize()
    //{
    //    List<ICutVO> cutVos = new List<ICutVO>();
    //    while (m_reader.Peek() != -1)
    //    {
    //        CutVO cutVo = new CutVO();
    //        cutVo.Caracters = new List<ICaracterVO>();
    //        cutVo.Effects = new List<ICommandWrapVO>();
    //        cutVo.BackgroundVO = new BackgroundVO();
    //        cutVo.Choices = new List<IChoiceVO>();
    //        while ( m_reader.Peek() != -1 && CUT_BREAK.IndexOf(PeekChar) != 0)
    //        {
                
    //            ParseValue(ref cutVo);
    //            m_reader.Read();
    //            if (m_reader.Peek() == -1 || CUT_BREAK.IndexOf(PeekChar) == 0)
    //            {
    //                break;
    //            }
    //        }
            
    //        cutVos.Add(cutVo);
            
    //        m_reader.Read();
    //    }
    //    return cutVos;
    //}
    
    //// 空白を除去
    //private void EatWhitespace()
    //{
    //    while ( WHITE_SPACE.IndexOf( PeekChar ) != -1 ) {
    //        m_reader.Read();

    //        if ( m_reader.Peek() == -1 ) {
    //            break;
    //        }
    //    }
    //}
    
    //// 空白・改行を除去
    //private void EatWhitespaceWithEnter()
    //{
    //    while (WORD_BREAK.IndexOf(PeekChar) != -1 || CUT_BREAK.IndexOf(PeekChar) != -1) {
            
    //        m_reader.Read();

    //        if ( m_reader.Peek() == -1 ) {
    //            break;
    //        }
    //    }
    //}

    ////２回読み込む
    //private void ReadTwice()
    //{
    //    m_reader.Read();
    //    m_reader.Read();
    //}
    
    //// 次の文字を確認
    //private char PeekChar { get { return Convert.ToChar( m_reader.Peek() ); } }
    //// 次の文字へ進める
    //private char NextChar { get { return Convert.ToChar( m_reader.Read() ); } }
    //// 次の単語へ進める
    //private string NextWord
    //{
    //    get
    //    {
    //        StringBuilder word = new StringBuilder();

    //        while ( WORD_BREAK.IndexOf( PeekChar ) == -1 ) {
    //            word.Append( NextChar );

    //            if ( m_reader.Peek() == -1 ) {
    //                break;
    //            }
    //        }

    //        return word.ToString();
    //    }
    //}
    
    //// 次の文章へ進める
    //private string NextMessage
    //{
    //    get
    //    {
    //        StringBuilder word = new StringBuilder();

    //        while ( CUT_BREAK.IndexOf( PeekChar ) == -1 ) {
    //            word.Append( NextChar );
    //            if ( m_reader.Peek() == -1 ) {
    //                break;
    //            }
    //        }
            
    //        return word.ToString();
    //    }
    //}
    
    //// 次のトークンへ進める
    //private MToken NextToken
    //{
    //    get
    //    {
    //        //EatWhitespace();

    //        if ( m_reader.Peek() == -1 ) {
    //            return MToken.None;
    //        }

    //        char c = PeekChar;
            
    //        switch ( c ) {
    //            case ';':
    //                EatWhitespace();
    //                //var str = NextMessage;
    //                m_reader.Read();
    //                return MToken.SemiColon;
    //            case '[':
    //                return MToken.CommandOpen;

    //            case ']':
    //                m_reader.Read();
    //                return MToken.CommandClose;
                
    //            case '【':
    //                return MToken.CharaNameOpen;
    //            case '】':
    //                m_reader.Read();
    //                return MToken.CharaNameClose;
    //            default:
    //                return MToken.Message;
                    
    //                break;

    //        }

    //        return MToken.None;
    //    }
    //}
    
    //// パース
    //private void ParseValue(ref CutVO cutVo)
    //{
    //    MToken nextToken = NextToken;

    //    ParseByToken( nextToken, ref cutVo );
    //}
    
    //// トークン別で分岐
    //private void ParseByToken( MToken token, ref CutVO cutVo )
    //{
    //    switch ( token ) {
    //        case MToken.SemiColon:
    //            //コメントは飛ばす
    //            string str = NextMessage;
    //            break;
    //        case MToken.CommandOpen:
    //            ParseCommand(ref cutVo);
    //            return;
    //        case MToken.CommandClose:
    //            m_reader.Read();
    //            return;
            
    //        case MToken.CharaNameOpen:
    //            //ParseMessage(ref cutVo);
    //            ParseCharaName(ref cutVo);
    //            return;
                
    //        case MToken.Message:
    //            ParseMessage(ref cutVo);
    //            return;

    //        default:
    //            return;
    //    }
    //}

    //private void ParseCommand(ref CutVO cutVo)
    //{
    //    string str;
        
    //    CommandWrapVO eVo = new CommandWrapVO();
    //    CharacterVO cVo = new CharacterVO();
        
    //    bool parsing = true;
    //    m_reader.Read();
    //    while ( parsing ) {
            
            
    //        if ( m_reader.Peek() == -1) {
    //            parsing = false;
    //            break;
    //        }

    //        str = NextWord;
    //        if (string.IsNullOrEmpty(str))
    //        {
    //            parsing = false;
    //            break;
    //        }
           
    //        eVo.CommandType = CommandType.NONE;
    //        // コマンドイベント
    //        //Debug.Log(str);
    //        switch (str)
    //        {
    //            case "messageoff":
    //                eVo.CommandType = CommandType.MESSAGEOFF;
    //                break;
    //            case "messageon":
    //                eVo.CommandType = CommandType.MESSAGEON;
    //                break;
    //            case "flash":
    //                eVo.CommandType = CommandType.FLASH;
    //                break;
    //            case "shake":
    //                eVo.CommandType = CommandType.SHACKE;
    //                break;
    //            case "blackout":
    //                eVo.CommandType = CommandType.BLAKOUT;
    //                break;
    //            case "hidecharacter":
    //                eVo.CommandType = CommandType.HIDE_CARACTER;
    //                break;
    //            case "ev":
    //                eVo.CommandType = CommandType.EV;
    //            {
    //                EatWhitespace();
    //                string commandName = NextWord;
    //                ReadTwice();
    //                commandName = NextWord;
    //                BackgroundVO backgroundVo = new BackgroundVO();
    //                backgroundVo.SpriteBackGroundName = commandName;
    //                backgroundVo.Name = commandName;
    //                cutVo.BackgroundVO = backgroundVo;
    //            }
    //                break;
    //            // 選択肢
    //            case "seladd":
    //            {
    //                ChoiceVO chVo = new ChoiceVO();
    //                string word = NextWord;
    //                EatWhitespace();
    //                word = NextWord;
    //                EatWhitespace();
    //                m_reader.Read();
    //                //一旦行の最後まで読み込む
    //                word = NextMessage;
                    
    //                //テキストとターゲットを分離。もっと良い方法は無いだろうか
    //                string[] separator = {" target="};
    //                string[] choice = word.Split(separator, None);
    //                chVo.text = choice[0];
    //                //ターゲットの不要な部分を削除
    //                string target = choice[1].Replace("target=", "");
    //                target = target.Remove(target.Length - 2);
    //                chVo.target = target;
    //                cutVo.Choices.Add(chVo);
    //            }
    //                break;
    //            case "暗転共通":
    //                eVo.CommandType = CommandType.BLAKOUT;
    //                break;
    //            case "wait":
    //                eVo.CommandType = CommandType.WAIT;
    //            {
    //                EatWhitespace();
    //                string commandName = NextWord;
    //                // TODO Waitイベント
    //            }
    //                break;
    //            case "bg":
    //                eVo.CommandType = CommandType.BG;
    //            {
    //                EatWhitespace();
    //                string commandName = NextWord;
    //                ReadTwice();
    //                BackgroundVO backgroundVo = new BackgroundVO();
    //                backgroundVo.SpriteBackGroundName = NextWord;
    //                cutVo.BackgroundVO = backgroundVo;
    //            }
    //                break;
    //            case "bgm":
    //            {
    //                EatWhitespace();
    //                string bgmCommannd = NextWord;
    //                if (bgmCommannd.Equals("stop"))
    //                {
    //                    cutVo.BgmID = string.Empty;
    //                    continue;
    //                }
    //                // BGMファイル指定
    //                else if (bgmCommannd.Equals("file"))
    //                {
    //                    ReadTwice();
    //                    cutVo.BgmID = NextWord;
    //                    continue;
    //                }
    //            }
    //                break;
    //            // キャラクタコマンドもあるのでdefaultはException無し
    //            default:
    //                //throw new Exception();
    //                break;
    //        }

    //        // 何かしらコマンドイベントがあれば登録
    //        if (eVo.CommandType != CommandType.NONE)
    //        {
    //            cutVo.Effects.Add(eVo);
    //            continue;
    //        }
            

    //        // キャラの表示系イベント
    //        string characterName = ParseCommandList.characterList.FirstOrDefault(_ => _.Equals(str));

    //        if (characterName != null)
    //        {
    //            //キャラの名前を入れる
    //            cVo.Name = characterName;
    //            m_reader.Read();
    //            while (CUT_BREAK.IndexOf(PeekChar) != 0 && m_reader.Peek() != -1)
    //            {
    //                str = NextWord;
    //                if (string.IsNullOrEmpty(str))
    //                {
    //                    m_reader.Read();
    //                    continue;
    //                }
    //                switch (str)
    //                {
    //                    case "出":
    //                        //デフォルト値を入れる
    //                        cVo.CharacterEffectType = CharacterEffectType.FADEIN;
    //                        break;
    //                    case "消":
    //                        //デフォルト値を入れる
    //                        cVo.CharacterEffectType = CharacterEffectType.FADEOUT;
    //                        break;
    //                    // 表示時間
    //                    case "time":
    //                        EatWhitespace();
    //                        m_reader.Read();
    //                        string word = NextWord;
    //                        int time = 0;
    //                        int.TryParse(word, out time);
    //                        cVo.ShowTime = time;
    //                        continue;
    //                    case CUT_BREAK:
    //                        m_reader.Read();
    //                        continue;
    //                    default:
    //                    {
    //                        //服判定
    //                        string costume = ParseCommandList.costumeList.FirstOrDefault(_ => _.Equals(str));
    //                        if (!string.IsNullOrEmpty(costume))
    //                        {
    //                            cVo.SpriteBodyName = costume;
    //                        }
    //                        else
    //                        {
    //                            //顔判定
    //                            string face = ParseCommandList.faceList.FirstOrDefault(_ => _.Equals(str));
    //                            if (!string.IsNullOrEmpty(face))
    //                            {
    //                                cVo.SpriteFaceName = face;
    //                            }
    //                            // 何も見つからなかったら登録コマンドでは無い
    //                            else
    //                            {
    //                                Debug.LogWarning("UnknownCommand:" + str);
    //                            }
    //                        }

    //                        break;
    //                    }
    //                }

    //                m_reader.Read();
    //            }
    //            cutVo.Caracters.Add(cVo);
    //        }

    //        parsing = false;
    //    }

    //    return;
    //}

    //private void ParseCharaName(ref CutVO cutVo)
    //{
    //    CharacterVO cVo = new CharacterVO();
    //    m_reader.Read();
    //    string str = NextWord;
    //    string characterName = ParseCommandList.characterList.FirstOrDefault(_ => _.Equals(str));
    //    cVo.Name = characterName;
    //    if (cutVo.WindowVO == null)
    //    {
    //        WindowVO wVo = new WindowVO();
    //        wVo.WindowNaviCaracterVO = cVo;
    //        cutVo.WindowVO = wVo;
    //    }
    //    else
    //    {
    //        WindowVO wVo = (WindowVO)cutVo.WindowVO;
    //        wVo.WindowNaviCaracterVO = cVo;
    //        cutVo.WindowVO = wVo;
    //    }
    //}

    //private void ParseMessage(ref CutVO cutVo)
    //{    
        
    //    string str = NextMessage;

    //    // 空白のみは無視する
    //    if (string.IsNullOrWhiteSpace(str))
    //    {
    //        return;
    //    }

    //    if (cutVo.WindowVO == null)
    //    {
    //        WindowVO wVo = new WindowVO();
    //        wVo.WindowText = str;
    //        cutVo.WindowVO = wVo;
    //    }
    //    else
    //    {
    //        WindowVO wVo = (WindowVO)cutVo.WindowVO;
    //        wVo.WindowText = str;
    //        cutVo.WindowVO = wVo;
    //    }
        
    //    m_reader.Read();
        
    //}
}
