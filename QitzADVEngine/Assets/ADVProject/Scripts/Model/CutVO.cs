using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qitz.ADVGame
{
    public class CutVO : ICutVO
    {
        IADVSpriteDataStore aDVSpriteDataStore;

        public IWindowVO WindowVO { get; set; }

        public string BgmID { get; set; }

        public List<IEffectVO> Effects { get; set; }

        public IBackgroundVO BackgroundVO { get; set; }

        public List<ICaracterVO> CaracterVO { get; set; }

        public List<IChoiceVO> Choices { get; set; }

        public void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore)
        {
            this.aDVSpriteDataStore = aDVSpriteDataStore;
            CaracterVO.ForEach(cv => cv.SetDataStore(aDVSpriteDataStore));
            BackgroundVO.SetDataStore(aDVSpriteDataStore);
        }
    }
}