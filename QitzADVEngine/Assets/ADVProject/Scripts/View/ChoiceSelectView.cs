using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Qitz.ADVGame
{
    public class ChoiceSelectView : AChoiceSelectView
    {
        [SerializeField]
        List<SelectItemView> selectItems;
        [SerializeField]
        Image background;

        public override void HideView()
        {
            selectItems.ForEach(si=>si.HideView());
            background.gameObject.SetActive(false);
        }

        public override void SetChoices(List<IChoiceVO> choices)
        {
            int i = 0;
            foreach (var t in choices)
            {
                selectItems[i].SetText(choices[i].text);
                i++;
            }
        }
    }
}
