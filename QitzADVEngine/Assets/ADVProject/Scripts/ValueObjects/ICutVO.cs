
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public interface ICutVO
    {
        IWindowVO WindowVO { get; }

        string BgmID { get; }

        List<IEffectVO> Effects { get; }

        IBackgroundVO BackgroundVO { get; }

        ICaracterVO CenterCaracterVO { get; }

        ICaracterVO LeftCaracterVO { get; }

        ICaracterVO RightCaracterVO { get; }

        List<string> Choices { get; }

    }
}
