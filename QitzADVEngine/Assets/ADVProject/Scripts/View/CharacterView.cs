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

        public override void SetCaracterVO(List<ICaracterVO> vo)
        {
            //throw new System.NotImplementedException();
        }
    }
}
