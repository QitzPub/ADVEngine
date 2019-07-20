
using Qitz.ArchitectureCore;
using UnityEngine;

namespace Qitz.ADVGame
{
    public interface IADVGameRepository
    {
    }
    public class ADVGameRepository : ARepository, IADVGameRepository
    {
        ADVGameDataStore aDVGameDataStore;

        public IADVGameDataStore ADVGameDataStore => aDVGameDataStore;

        [SerializeField]
        ADVSpriteDataStore aDVSpriteDataStore;
        [SerializeField]
        ADVAudioDataStore aDVAudioDataStore;

        public void Initialize(string macro)
        {
            this.aDVGameDataStore = new ADVGameDataStore(macro);
            aDVGameDataStore.SetDataStore(aDVSpriteDataStore, aDVAudioDataStore);
        }

    }
}