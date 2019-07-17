
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public abstract class ACharacterView:ADVGameView
    {
        abstract public void SetCaracterVO(List<ICaracterVO> characters);
    }
}
