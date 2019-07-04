using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public abstract class AChoiceSelectView:ADVGameView
    {
        abstract public void SetChoices(List<IChoiceVO> choices);
        abstract public void HideView();
    }
}