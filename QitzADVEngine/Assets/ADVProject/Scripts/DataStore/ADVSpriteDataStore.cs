using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Qitz.ArchitectureCore;
using  System;

namespace Qitz.ADVGame
{
    public class ADVSpriteDataStore : ADataStore,IADVSpriteDataStore
    {
        public List<IADVSpriteVO> BodySpriteList { get; }
        public List<IADVSpriteVO> FaceSpriteList { get; }
        public List<IADVSpriteVO> BackgroundSpriteList { get; }
    }

    public class CharacterBodySpriteVO : AVO,IADVSpriteVO
    {
        public Sprite Sprite => bodySprite;
        [SerializeField] private Sprite bodySprite;
        
        
    }
    
    
}
