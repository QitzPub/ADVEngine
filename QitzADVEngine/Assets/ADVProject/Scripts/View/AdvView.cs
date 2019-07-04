﻿using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using System.Linq;

namespace Qitz.ADVGame
{
    public  abstract class  AAdvView:ADVGameView{
        public abstract void Next();
        public abstract IObservable<Unit> ASVScenarioEndObservable { get; }
        public abstract IObservable<ICutVO> ADVCutObservable { get; }
    }
    
    public class AdvView : AAdvView
    {
        [SerializeField] private ABackgroundView _backgroundView;
        [SerializeField] private ACharacterView _characterView;
        [SerializeField] private AWindowView _windowView;
        [SerializeField] private AChoiceSelectView _choiceSelectView;
        public override IObservable<Unit> ASVScenarioEndObservable => this.aDVGameController.ASVScenarioEndObservable;
        public override IObservable<ICutVO> ADVCutObservable => this.aDVGameController.ADVCutObservable;

        public override void Next()
        {
            this.aDVGameController.Next();
        }

        private void Start()
        {
            ADVCutObservable.Subscribe(cutVO => UpdateADVViews(cutVO)).AddTo(this.gameObject);
        }

        void UpdateADVViews(ICutVO cutVo)
        {
            _backgroundView.SetBackgroundVO(cutVo.BackgroundVO);
            _backgroundView.SetEffect(cutVo.Effects);
            _characterView.SetCaracterVO(cutVo.Caracters);
            _windowView.SetWindowVO(cutVo.WindowVO);
            _choiceSelectView.SetChoices(cutVo.Choices);
        }

    }
}
