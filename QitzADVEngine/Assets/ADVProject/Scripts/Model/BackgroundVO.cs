
using UnityEngine;
using System.Linq;
using System.IO;

namespace Qitz.ADVGame
{
    public class BackgroundVO : IBackgroundVO
    {
        IADVSpriteDataStore aDVSpriteDataStore;

        public string Name { get; set; }

        string withOutExtentionName => Path.GetFileNameWithoutExtension(Name);

        public string SpriteBackGroundName { get; set; }

        public Sprite SpriteBackGround => aDVSpriteDataStore.BackgroundSpriteList.FirstOrDefault(bs=>bs.Sprite.name== withOutExtentionName).Sprite;

        public void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore)
        {
            this.aDVSpriteDataStore = aDVSpriteDataStore;
        }
    }
}
