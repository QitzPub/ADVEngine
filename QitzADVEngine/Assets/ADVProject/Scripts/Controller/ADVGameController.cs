
using UnityEngine;
using Qitz.ArchitectureCore;
using UniRx;
using System;
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public interface IADVGameController
    {
        IObservable<Unit> ASVScenarioEndObservable { get; }
        IObservable<ICutVO> ADVCutObservable { get; }
        void Initialize(string macro);
        void Next();
    }

    public class ADVGameController : AController<ADVGameRepository>, IADVGameController
    {
        [SerializeField]
        ADVGameRepository repository;
        protected override ADVGameRepository Repository { get { return repository; } }
        Subject<ICutVO> advCutSunject = new Subject<ICutVO>();
        public IObservable<ICutVO> ADVCutObservable => advCutSunject;
        Subject<Unit> advScenarioEndSubject = new Subject<Unit>();
        public IObservable<Unit> ASVScenarioEndObservable => advScenarioEndSubject;
        List<ICutVO> cutVOs => repository.ADVGameDataStore.CutVOs;
        int aDVCutCount => cutVOs.Count;
        int currentScenarioCutCount = 0;

        public void Next()
        {
            bool isScenarioEnd = cutVOs.Count <= currentScenarioCutCount;
            if (isScenarioEnd) {
                advScenarioEndSubject.OnNext(Unit.Default);
                return;
            }
            advCutSunject.OnNext(cutVOs[currentScenarioCutCount]);
            currentScenarioCutCount++;
        }

        public void Initialize(string macro)
        {
            this.repository.Initialize(macro);
        }

    }
}