
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public interface ICutVO
    {
        IWindowVO WindowVO { get; }

        string BgmID { get; }

        List<IEffectVO> Effects { get; }

        IBackgroundVO BackgroundVO { get; }

        List<ICaracterVO> CaracterVO { get; }

        List<IChoiceVO> Choices { get; }

        void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore);

    }

}
