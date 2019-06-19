using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qitz.ADVGame
{
    public class CutVO : ICutVO
    {
        public IWindowVO WindowVO { get; set; }

        public string BgmID { get; set; }

        public List<IEffectVO> Effects { get; set; }

        public IBackgroundVO BackgroundVO { get; set; }

        public List<ICaracterVO> CaracterVO { get; set; }

        public List<IChoiceVO> Choices { get; set; }
    }
}