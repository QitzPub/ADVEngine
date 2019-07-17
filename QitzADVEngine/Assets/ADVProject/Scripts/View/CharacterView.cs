﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Qitz.ADVGame
{
    public class CharacterView : ACharacterView
    {
        [System.Serializable]
        struct CharacterImages
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
        List<CharacterImages> characterImages;
        [SerializeField]
        List<CharacterViewPostionSetting> viewPostion;

        List<ICaracterVO> appendedCharacter = new List<ICaracterVO>();

        public override void SetCaracterVO(List<ICaracterVO> characters)
        {

            characters.ForEach(c=> SetAppendedCharacterList(ref appendedCharacter,c));
            SetViewPostionFromCharacterCount(appendedCharacter.Count);
            //一旦キャラクターイメージを非表示にする
            foreach (var ci in characterImages)
            {
                ci.Parent.SetActive(false);
            }

            for (int i = 0; i < appendedCharacter.Count; i++)
            {
                characterImages[i].Parent.SetActive(true);
                characterImages[i].CharacterBodyImage.sprite = appendedCharacter[i].BodySprite;
                characterImages[i].CharacterBodyImage.SetNativeSize();
                characterImages[i].CharacterBodyImage.transform.localPosition = appendedCharacter[i].BodyPostion;

                characterImages[i].CharacterFaceImage.sprite = appendedCharacter[i].FaceSprite;
                characterImages[i].CharacterFaceImage.SetNativeSize();
                characterImages[i].CharacterFaceImage.transform.localPosition = appendedCharacter[i].FacePostion;
            }

        }

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
