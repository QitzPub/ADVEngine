using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Qitz.ADVGame
{
    public class CharactersWrapView : ACharactersWrapView
    {
        [System.Serializable]
        class CharacterView
        {
            [SerializeField]
            GameObject parent;
            public GameObject Parent => parent;
            [SerializeField]
            Image characterBodyImage;
            public Image CharacterBodyImage =>characterBodyImage;
            [SerializeField]
            Image characterFaceImage;
            public Image CharacterFaceImage => characterFaceImage;
            [SerializeField]
            CanvasGroup canvasGroup;

            public void SetCharacterVO(ICaracterVO caracterVO)
            {
                Parent.SetActive(true);
                CharacterBodyImage.sprite = caracterVO.BodySprite;
                CharacterBodyImage.SetNativeSize();
                CharacterBodyImage.transform.localPosition = caracterVO.BodyPostion;

                CharacterFaceImage.sprite = caracterVO.FaceSprite;
                CharacterFaceImage.SetNativeSize();
                CharacterFaceImage.transform.localPosition = caracterVO.FacePostion;
            }

        }
        [System.Serializable]
        struct CharacterViewPostionSetting
        {
            [SerializeField]
            Vector3 postion;
            public Vector3 Postion => postion;
            [SerializeField]
            Vector3 scale;
            public Vector3 Scale => scale;
        }


        [SerializeField]
        List<CharacterView> characterViews;
        [SerializeField]
        List<CharacterViewPostionSetting> viewPostion;

        //List<ICaracterVO> prevAppendedCharacter = new List<ICaracterVO>();
        List<ICaracterVO> appendedCharacter = new List<ICaracterVO>();

        public override void SetCaracterVO(List<ICaracterVO> characters)
        {
            characters.ForEach(c=> SetAppendedCharacterList(ref appendedCharacter,c));
            SetViewPostionFromCharacterCount(appendedCharacter.Count);
            //一旦キャラクタービュウを非表示に
            characterViews.ForEach(cv => cv.Parent.SetActive(false));

            for (int i = 0; i < appendedCharacter.Count; i++)
            {
                characterViews[i].SetCharacterVO(appendedCharacter[i]);
            }

        }

        //キャラ数に応じて画面の表示倍率や位置を変える
        void SetViewPostionFromCharacterCount(int characterCount)
        {
            this.transform.localPosition = viewPostion[characterCount].Postion;
            this.transform.localScale = viewPostion[characterCount].Scale;
        }


        void SetAppendedCharacterList(ref List<ICaracterVO> _appendedCharacter, ICaracterVO newCharacterVO)
        {
            if (newCharacterVO.AppendCharacter)
            {
                _appendedCharacter.Add(newCharacterVO);
            }
            else if (newCharacterVO.DisAppendCharacter)
            {
                _appendedCharacter = _appendedCharacter.Where(ac => ac.Name != newCharacterVO.Name).ToList();
            }
            else
            {
                UpdateCharacterState(ref _appendedCharacter, newCharacterVO);
            }
        }

        void UpdateCharacterState(ref List<ICaracterVO> _appendedCharacter, ICaracterVO newCharacterVO)
        {
            foreach (var ac in _appendedCharacter)
            {
                if (ac.Name == newCharacterVO.Name)
                {
                    ac.UpDataCharacterStateFromNewCharacterVO(newCharacterVO);
                }
            }
        }


    }
}
