using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public interface IADVSpriteDataStore 
    {
        List<IADVSpriteVO> BodySpriteList { get; }
        List<IADVSpriteVO> FaceSpriteList { get; }
        List<IADVSpriteVO> BackgroundSpriteList { get; }
    }

}
