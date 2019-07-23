using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Qitz.ADVGame
{
    public class WindowView : AWindowView
    {
        [SerializeField]
        Text name;
        [SerializeField]
        Text body;
        [SerializeField]
        TextAnimation bodyTextAnimation;

        public override void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public override void SetWindowVO(IWindowVO vo)
        {
            //body.text = vo.WindowText;
            bodyTextAnimation.SetNextLine(vo.WindowText);
            name.text = vo.WindowCharacterName;
        }

        public override void Show()
        {
            this.gameObject.SetActive(true);
        }
    }
}
