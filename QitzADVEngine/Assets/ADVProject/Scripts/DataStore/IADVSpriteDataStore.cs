using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public interface IADVSpriteDataStore 
    {
        List<ICharacterBodySpriteVO> BodySpriteList { get; }
        List<ICharacterFaceSpriteVO> FaceSpriteList { get; }
        List<IADVSpriteVO> BackgroundSpriteList { get; }
    }

}
