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

        public override void SetWindowVO(IWindowVO vo)
        {
            if(vo != null)
            {
                body.text = vo.WindowText;
            }
        }
    }
}
