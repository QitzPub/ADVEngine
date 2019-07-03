using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore;
namespace Qitz.ADVGame
{
    public interface IADVGameDataStore
    {
        List<ICutVO> cutVOs { get; }
        void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore);
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

        public void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore)
        {
            cutVOs.ForEach(cv => cv.SetDataStore(aDVSpriteDataStore));
        }

        private void ShowData()
        {
            foreach (CutVO cVo in cutVOs)
            {
                if (cVo.WindowVO!= null)
                {
                    if(cVo.WindowVO.WindowNaviCaracterVO != null)
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

                foreach (var VARIABLE in cVo.Choices)
                {
                    Debug.Log("Choice:" + VARIABLE.text);
                    Debug.Log(("Target:" + VARIABLE.target));
                }
                Debug.Log(("BG:"  +cVo.BackgroundVO.SpriteBackGroundName));
                Debug.Log(("BGM:"  +cVo.BgmID));
            }
        }
        
        
    }
}