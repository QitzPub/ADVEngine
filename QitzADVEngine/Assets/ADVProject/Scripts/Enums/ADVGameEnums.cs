﻿

namespace Qitz.ADVGame
{
    public enum Expression
    {
        NONE,
        真顔,
        悲しみ,
        真顔眼鏡,
        半目,
        半目眼鏡,
        微笑,
        笑顔,
        微笑眼鏡,
        驚き,
        微笑照れ,
        半目照れ,
        ふてくされ照れ,
        驚き照れ,
        真顔照れ,
        笑顔照れ,
        ふてくされ,
        ときめき,
        怒り,
        怒り照れ,
        笑顔眼鏡,
        目閉じ,
    }
    public enum CommandType
    {
        NONE,
        SHACKE,
        FLASH,
        BLAKOUT,
        MESSAGEOFF,
        MESSAGEON,
        CARACTER,
        BG,
        BGM,
        SE,
        EV,
        WAIT,
        
    }
    public enum CommandValueType
    {
        NONE,
        STOP,
        FILE,
        DISAPPEAR,
        APPEAR,
        TIME,
        SHOW_FACE,
        GO_UP,
        TB,
        KEY_INPUT,
        SET_COSTUME,
        SET_FACE,
    }

    public enum CommandString
    {
        NONE,
        messageoff,
        messageon,
        暗転共通,
        bg,
        bgm,
        wait,
        ev,
    }
    public enum CommandValueString
    {
        NONE,
        stop,
        file,
        消,
        time,
        出,
        顔,
        up,
        tb,
        keyinput,
    }

    public enum Character
    {
        NONE,
        永峰あさひ,
        森若ちとせ,
        藤枝アキラ,
        女子生徒１,
        加賀谷ソウ,
        男子生徒１,
        南啓一,
        //=================
        リリファ,
        アイン,
        二オディ,
        シオト,
        ローウィン,
        ルーヤ,
        ジグル,
        エルバート,
        キルエル,
    }

    public enum Costume
    {
        NONE,
        通常服,
        制服冬服,
        私服部屋着,
        私服コート,
        冬服,
        私服冬服,
        制服ジャージ,
    }
    
    
    
}

