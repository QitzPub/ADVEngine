using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore;
using Qitz.ADVGame.ParseUtil;

namespace Qitz.ADVGame
{
    public interface IADVGameDataStore
    {
        List<ICutVO> CutVOs { get; }
        void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore);
    }

    public class ADVGameDataStore : ADataStore, IADVGameDataStore
    {

        public ADVGameDataStore(string macro)
        {
        
            QitzADVMacroParseUtil util = new QitzADVMacroParseUtil(macro);
            CutVOs = util.Deserialize();

        }

        public List<ICutVO> CutVOs { get; private set; }

        public void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore)
        {
            CutVOs.ForEach(cv => cv.SetDataStore(aDVSpriteDataStore));
        }
        
        
    }
}