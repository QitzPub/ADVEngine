using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Qitz.ADVGame
{
    public class CharacterVO : ICaracterVO
    {
        IADVSpriteDataStore aDVSpriteDataStore;

        public string Name { get; set; }

        public Expression Expression => (Expression)Enum.Parse(typeof(Expression), SpriteFaceName.Replace("(", "").Replace(")", ""), true);

        public string SpriteBodyName { get; set; }

        public string SpriteFaceName { get; set; }
        
        public CharacterEffectType CharacterEffectType { get; set; }
        
        public int ShowTime { get; set; }

        public Character Character => (Character)Enum.Parse(typeof(Character), Name, true);

        public Costume Costume => (Costume)Enum.Parse(typeof(Costume), SpriteBodyName.Replace("(","").Replace(")", ""), true);

        public ICharacterBodySpriteVO CharacterBodySpriteVO => aDVSpriteDataStore.BodySpriteList.FirstOrDefault(bs=>bs.Character== this.Character &&bs.Costume== this.Costume);

        public ICharacterFaceSpriteVO FaceSpriteVO => aDVSpriteDataStore.FaceSpriteList.FirstOrDefault(fs=>fs.Character== this.Character&&fs.Expression== this.Expression);

        public void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore)
        {
            this.aDVSpriteDataStore = aDVSpriteDataStore;
        }
    }
}