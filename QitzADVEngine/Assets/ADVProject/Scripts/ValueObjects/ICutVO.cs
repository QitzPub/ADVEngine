
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public interface ICutVO
    {
        IWindowVO WindowVO { get; }

        //string BgmID { get; }

        List<ICommandWrapVO> Commands { get; }

        IBackgroundVO BackgroundVO { get; }

        List<ICaracterVO> Caracters { get; }

        List<IChoiceVO> Choices { get; }

        void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore);

    }

}
