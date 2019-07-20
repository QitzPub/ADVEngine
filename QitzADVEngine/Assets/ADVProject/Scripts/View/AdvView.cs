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
        [SerializeField] private ACharactersWrapView _characterView;
        [SerializeField] private AWindowView _windowView;
        [SerializeField] private AChoiceSelectView _choiceSelectView;
        [SerializeField] private ADVAudioPlayer aDVAudioPlayer;
        [SerializeField] private EffectView effectView;
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
            //ブラックアウトが走った場合は次のCutへ
            effectView.BlackOutEndObservable.Subscribe(_ => Next());
        }

        void UpdateADVViews(ICutVO cutVo)
        {
            currentCut = cutVo;

            //画面エフェクトの実行
            cutVo.Commands.ForEach(cd => effectView.DoEffect(cd));
            //音楽を鳴らす
            aDVAudioPlayer.PlayAudio(cutVo.QitzAudio?.Audio);
            //seを鳴らす
            aDVAudioPlayer.PlaySE(cutVo.SE?.Audio);
            //Windowの表示更新
            _windowView.SetWindowVO(cutVo.WindowVO);
            //バックグラウンドの更新
            _backgroundView.SetBackgroundVO(cutVo.BackgroundVO);
            //キャラクタービューの更新
            _characterView.SetCaracterVO(cutVo.Caracters);
            //選択肢の表示
            SetChoiceView(cutVo);
        }

        void SetChoiceView(ICutVO cutVo)
        {
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
        }

        void ChoiceSelectAction(string selectValue)
        {
            Next(selectValue);
        }


    }
}
