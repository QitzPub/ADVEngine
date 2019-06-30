using System;
using UnityEngine.UI;
using UnityEngine;

namespace Qitz.ADVGame
{
    public class BackgroundView : ABackgroundView
    {
        [SerializeField]
        Image backgroundImage;

        public override void SetBackgroundVO(IBackgroundVO vo)
        {
            throw new NotImplementedException();
        }

        public override void SetEffect(IEffectVO vo)
        {
            throw new NotImplementedException();
        }
    }
}
