using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

namespace Qitz.ADVGame
{
    public class ChoiceSelectView : AChoiceSelectView
    {
        [SerializeField]
        List<SelectItemView> selectItems;
        [SerializeField]
        Image background;

        public List<SelectItemView> SelectItems { get => selectItems; set => selectItems = value; }

        public override void Initialize(Action<string> selectAction,List<ICommandWrapVO> commands)
        {
            int i = 0;
            background.gameObject.SetActive(true);
            SelectItems.Take(commands.Count).ToList().ForEach(si=>si.ShowView());
            foreach (var c in commands)
            {
                SelectItems[i].Initialize(c.CommandValues, selectAction);
                i++;
            }
        }

        public override void HideView()
        {
            SelectItems.ForEach(si=>si.HideView());
            background.gameObject.SetActive(false);
        }

    }
}
