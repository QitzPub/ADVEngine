using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Qitz.ADVGame
{
    public abstract class ASelectItemView: ADVGameView
    {
        abstract public void SetText(string text);
        abstract public void HideView();
    }

    public class SelectItemView : ASelectItemView
    {
        [SerializeField]
        Text text;

        public override void HideView()
        {
            this.gameObject.SetActive(false);
        }

        public override void SetText(string text)
        {
            this.text.text = text;
            this.gameObject.SetActive(true);
        }
    }
}
