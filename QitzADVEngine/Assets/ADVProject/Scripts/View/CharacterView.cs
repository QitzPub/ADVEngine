using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Qitz.ADVGame
{
    public class CharacterView : ACharacterView
    {
        [SerializeField]
        List<Image> characterBodys;
        [SerializeField]
        List<Image> characterFaces;

        public override void SetCaracterVO(List<ICaracterVO> vo)
        {
            for (int i = 0; i < vo.Count; i++)
            {
                characterBodys[i].sprite = vo[i].BodySprite;
                characterFaces[i].sprite = vo[i].FaceSprite;
            }

            //throw new System.NotImplementedException();
        }
    }
}
