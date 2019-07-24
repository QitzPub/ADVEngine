
using UnityEngine;
using Qitz.ArchitectureCore;
using UniRx;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Qitz.ADVGame
{
    public interface IADVGameController
    {
        IObservable<List<int>> ASVScenarioEndObservable { get; }
        IObservable<ICutVO> ADVCutObservable { get; }
        void Initialize(string macro);
        void Next(string jumpTo);
        void AddSelect(int selectNumber);
    }

    public class ADVGameController : AController<ADVGameRepository>, IADVGameController
    {
        [SerializeField]
        ADVGameRepository repository;
        protected override ADVGameRepository Repository { get { return repository; } }
        Subject<ICutVO> advCutSunject = new Subject<ICutVO>();
        public IObservable<ICutVO> ADVCutObservable => advCutSunject;
        Subject<List<int>> advScenarioEndSubject = new Subject<List<int>>();
        public IObservable<List<int>> ASVScenarioEndObservable => advScenarioEndSubject;
        List<ICutVO> cutVOs => repository.CutVOs;
        int aDVCutCount => cutVOs.Count;
        int currentScenarioCutCount = 0;
        List<int> selectedChoice = new List<int>();
        string cacheMacro;

        public void Next(string jumpTo = "")
        {
            if(jumpTo != "")
            {
                repository.ReLoad(cacheMacro);
                ICutVO targetCut = cutVOs.FirstOrDefault(cv=>cv.SelTagValue== jumpTo);
                if (targetCut == null) throw new Exception($"jump先が存在しません:{jumpTo}");
                currentScenarioCutCount = targetCut.Number-1;
            }

            bool isScenarioEnd = cutVOs.Count <= currentScenarioCutCount+1;
            if (isScenarioEnd) {
                Debug.Log($"isScenarioEnd{selectedChoice[0]}");
                advScenarioEndSubject.OnNext(selectedChoice);
                return;
            }
            advCutSunject.OnNext(cutVOs[currentScenarioCutCount]);
            currentScenarioCutCount++;
        }

        public void Initialize(string macro)
        {
            this.cacheMacro = macro;
            this.repository.Initialize(macro);
        }

        public void AddSelect(int selectNumber)
        {
            selectedChoice.Add(selectNumber);
        }
    }
}