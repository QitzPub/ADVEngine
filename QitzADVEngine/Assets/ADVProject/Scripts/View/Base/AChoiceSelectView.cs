using System;
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public abstract class AChoiceSelectView:ADVGameView
    {
        abstract public void Initialize(Action<string> selectAction, List<ICommandWrapVO> commands);
        abstract public void HideView();
    }
}