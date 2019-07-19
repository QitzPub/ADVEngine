using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Qitz.ADVGame
{
    public abstract class ASelectItemView: ADVGameView
    {
        abstract public void Initialize(List<CommandVO> selectCommands, Action<string> selectAction);
        abstract public void HideView();
        abstract public void ShowView();
    }

    public class SelectItemView : ASelectItemView
    {
        [SerializeField]
        Text text;
        [SerializeField]
        Button button;

        public override void HideView()
        {
            this.gameObject.SetActive(false);
        }
        public override void ShowView()
        {
            this.gameObject.SetActive(true);
        }

        public override void Initialize(List<CommandVO> selectCommands, Action<string> selectAction)
        {
            this.text.text = selectCommands.FirstOrDefault(sc=>sc.CommandValueType == CommandValueType.TEXT).Value;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(()=> {
                var selectValue = selectCommands.FirstOrDefault(sc => sc.CommandValueType == CommandValueType.TARGET).Value;
                selectAction.Invoke(selectValue);
            });
            this.gameObject.SetActive(true);
        }
    }
}
