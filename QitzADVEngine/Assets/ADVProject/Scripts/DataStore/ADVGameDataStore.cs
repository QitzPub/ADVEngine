using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore;
namespace Qitz.ADVGame
{
    public interface IADVGameDataStore
    {
        List<ICutVO> cutVOs { get; }
    }

    public class ADVGameDataStore : ADataStore, IADVGameDataStore
    {

        public ADVGameDataStore(string macro)
        {
            //※ここにtextmacroをICutVOのリストに変換するロジックなどをいれたりする
        }

        public List<ICutVO> cutVOs => throw new System.NotImplementedException();
    }
}