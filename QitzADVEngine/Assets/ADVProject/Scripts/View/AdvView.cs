using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using System.Linq;

namespace Qitz.ADVGame
{
    public  abstract class  AAdvView:ADVGameView{
        public abstract void Next(string jumpTo);
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
        ICutVO currentCut;


        public override void Next(string jumpTo = "")
        {
            string _jumpTo = jumpTo;
            bool ableToJump = currentCut != null && currentCut.JumpToValue != "";
            if (ableToJump) _jumpTo = currentCut.JumpToValue;
            this.aDVGameController.Next(_jumpTo);
        }

        private void Start()
        {
            ADVCutObservable.Subscribe(cutVO => UpdateADVViews(cutVO)).AddTo(this.gameObject);
            Next();
        }

        void UpdateADVViews(ICutVO cutVo)
        {
            currentCut = cutVo;


            //ここをよしなにすべし！！！
            _windowView.SetWindowVO(cutVo.WindowVO);
            _backgroundView.SetBackgroundVO(cutVo.BackgroundVO);
            //_backgroundView.SetEffect(cutVo.Commands);
            _characterView.SetCaracterVO(cutVo.Caracters);
            bool existSelectCommand = cutVo.Commands.FirstOrDefault(cd => cd.CommandHeadVO.CommandType == CommandType.SELECT) != null;
            if (existSelectCommand)
            {
                var salAddList = cutVo.Commands.Where(cd => cd.CommandHeadVO.CommandType == CommandType.SELADD).ToList();
                _choiceSelectView.Initialize(ChoiceSelectAction, salAddList);
            }
            else
            {
                _choiceSelectView.HideView();
            }


            //ここに画面暗転や選択肢表示などのコマンドが来た時によしなに表示できるようにする。

        }

        void ChoiceSelectAction(string selectValue)
        {
            Next(selectValue);
        }


    }
}
