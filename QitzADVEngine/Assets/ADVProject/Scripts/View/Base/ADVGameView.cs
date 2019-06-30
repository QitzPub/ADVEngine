using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore;

namespace Qitz.ADVGame
{
    public abstract class ADVGameView : AView
    {
        protected IADVGameController aDVGameController => this.GetController<ADVGameController>();
    }
}
