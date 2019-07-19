
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
        IObservable<Unit> ASVScenarioEndObservable { get; }
        IObservable<ICutVO> ADVCutObservable { get; }
        void Initialize(string macro);
        void Next(string jumpTo);
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

        public void Next(string jumpTo = "")
        {
            if(jumpTo != "")
            {
                ICutVO targetCut = cutVOs.FirstOrDefault(cv=>cv.SelTagValue== jumpTo);
                if (targetCut == null) throw new Exception($"jump先が存在しません:{jumpTo}");
                currentScenarioCutCount = targetCut.Number;
            }

            bool isScenarioEnd = cutVOs.Count <= currentScenarioCutCount;
            if (isScenarioEnd) {
                Debug.Log("isScenarioEnd");
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