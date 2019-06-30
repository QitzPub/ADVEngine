using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qitz.ADVGame
{
    public  abstract class  AAdvView:ADVGameView{
        
    }
    
    public class AdvView : AAdvView
    {
        [SerializeField] private BackgroundView _backgroundView;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private WindowView _windowView;
        [SerializeField] private ChoiceSelectView _choiceSelectView;

        private void Start()
        {
          
        }
    }
}
