
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public abstract class ACharactersWrapView:ADVGameView
    {
        abstract public void SetCaracterVO(List<ICaracterVO> characters);
    }
}
