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
            //cutVOs = new List<ICutVO>();
            //※ここにtextmacroをICutVOのリストに変換するロジックなどをいれたりする
            
            ParseUtil util = new ParseUtil(macro);
            cutVOs = util.Deserialize();
            
            //デバッグ用にデータ表示
            ShowData();
        }

        public List<ICutVO> cutVOs { get; private set; }

        private void ShowData()
        {
            foreach (CutVO cVo in cutVOs)
            {
                if (cVo.WindowVO!= null)
                {
                    Debug.Log(cVo.WindowVO.WindowNaviCaracterVO.Name);
                    Debug.Log(cVo.WindowVO.WindowText);
                }
                foreach (EffectVO eVo in cVo.Effects)
                {
                    Debug.Log(eVo.EffectType);
                }

                foreach (var VARIABLE in cVo.CaracterVO)
                {
                    Debug.Log("Body:" + VARIABLE.SpriteBodyName);
                    Debug.Log("Face:" + VARIABLE.SpriteFaceName);
                    Debug.Log("View" + VARIABLE.CharacterEffectType + " Time:" + VARIABLE.ShowTime);
                }
                Debug.Log(("BG:"  +cVo.BackgroundVO.SpriteBackGroundName));
                Debug.Log(("BGM:"  +cVo.BgmID));
            }
        }
        
        
    }
}