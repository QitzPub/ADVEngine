using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qitz.ADVGame
{
    public class CharacterVO : ICaracterVO
    {
        public string Name { get; set; }

        public Expression Expression { get; set; }

        public string SpriteBodyName { get; set; }

        public string SpriteFaceName { get; set; }
        
        public CharacterEffectType CharacterEffectType { get; set; }
        
        public int ShowTime { get; set; }
    }
}