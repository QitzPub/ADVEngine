using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Qitz.ADVGame
{
    public class CharacterVO : ICaracterVO
    {
        public CharacterVO(string name, string spriteBodyName, string spriteFaceName, List<CommandVO> characterCommands)
        {
            this.Name = name;
            this.SpriteBodyName = spriteBodyName;
            this.SpriteFaceName = spriteFaceName;
            this.characterCommands = characterCommands;
        }

        IADVSpriteDataStore aDVSpriteDataStore;

        List<CommandVO> characterCommands;

        public bool ExistFaseSprite => characterCommands.FirstOrDefault(cv => cv.CommandValueType == CommandValueType.SET_FACE) != null && SpriteFaceName != "";
        public bool ExistBodySprite => characterCommands.FirstOrDefault(cv => cv.CommandValueType == CommandValueType.SET_COSTUME) != null && SpriteBodyName != "";

        public string Name { get; private set; }

        public Expression Expression => (Expression)Enum.Parse(typeof(Expression), SpriteFaceName.Replace("(", "").Replace(")", ""), true);

        public string SpriteBodyName { get; private set; }

        public string SpriteFaceName { get; private set; }
        
        public CharacterEffectType CharacterEffectType { get; set; }
        

        public Character Character => (Character)Enum.Parse(typeof(Character), Name, true);

        public Costume Costume
        {
            get
            {
                if (SpriteBodyName == null) return Costume.NONE;
                return (Costume)Enum.Parse(typeof(Costume), SpriteBodyName.Replace("(", "").Replace(")", ""), true);
            }
        }


        public ICharacterBodySpriteVO CharacterBodySpriteVO => aDVSpriteDataStore.BodySpriteList.FirstOrDefault(bs=>bs.Character== this.Character &&bs.Costume== this.Costume);

        public ICharacterFaceSpriteVO FaceSpriteVO => aDVSpriteDataStore.FaceSpriteList.FirstOrDefault(fs=>fs.Character== this.Character&&fs.Expression== this.Expression);

        public Sprite BodySprite {
        get {
                if (!ExistBodySprite) return null;

                var bs = this.aDVSpriteDataStore.BodySpriteList.FirstOrDefault(b=>b.Character== Character && b.Costume== Costume);
                if (bs == null)
                {
                    return this.aDVSpriteDataStore.BodySpriteList.FirstOrDefault(b => b.Character == Character).Sprite;
                }
                return bs.Sprite;
            }
        }
        public Sprite FaceSprite
        {
            get
            {
                if (!ExistFaseSprite) return null;

                var fs = this.aDVSpriteDataStore.FaceSpriteList.FirstOrDefault(f => f.Character == Character && f.Expression == Expression);
                return fs.Sprite;
            }
        }

        public Vector2 BodyPostion => aDVSpriteDataStore.CharacterBodyPostionList.FirstOrDefault(cbp=>cbp.Character== Character).Postion;

        public Vector2 FacePostion => aDVSpriteDataStore.CharacterFacePostionList.FirstOrDefault(cfp => cfp.Character == Character).Postion;



        //public void SetCharacterCommands(List<CommandVO> characterCommands)
        //{
        //    this.characterCommands = characterCommands;
        //}

        public void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore)
        {
            this.aDVSpriteDataStore = aDVSpriteDataStore;
        }
    }
}