﻿using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public class BackgroundView : ABackgroundView
    {
        [SerializeField]
        Image backgroundImage;

        public override void SetBackgroundVO(IBackgroundVO vo)
        {
            //throw new NotImplementedException();
        }

        public override void SetEffect(List<IEffectVO> vo)
        {
            //throw new NotImplementedException();
        }
    }
}
