using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Qitz.ADVGame
{
    public class CharacterView : ACharacterView
    {
        [SerializeField]
        Image characterBody;
        [SerializeField]
        Image characterFace;

        public override void SetCaracterVO(ICaracterVO vo)
        {
            throw new System.NotImplementedException();
        }

        public override void SetEffect(IEffectVO vo)
        {
            throw new System.NotImplementedException();
        }
    }
}
