
namespace Qitz.ADVGame
{
    public interface ICaracterVO
    {
        string Name { get; }

        Expression Expression { get; }

        string SpriteBodyName { get; }

        string SpriteFaceName { get; }
        
        CharacterEffectType CharacterEffectType { get; }
        
        int ShowTime { get; }

    }

    //キャラクタの出現効果
    public enum CharacterEffectType
    {
        NONE,    //なし（現状維持）
        UP,      //下からにゅい〜ん
        DOWN,    //上から
        SLIDEIN, //スライドイン
        FADEIN,  //フェードイン
        
        //ここから退出処理
        SLIDEOUT,//スライドアウト
        FADEOUT, //フェードアウト
        
    }
}
