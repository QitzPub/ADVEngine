
using UnityEngine;
using Qitz.ArchitectureCore;

namespace Qitz.ADVGame
{
    public interface IADVGameController
    {
        void Initialize(string macro);
    }

    public class ADVGameController : AController<ADVGameRepository>, IADVGameController
    {
        [SerializeField]
        ADVGameRepository repository;
        protected override ADVGameRepository Repository { get { return repository; } }

        public void Initialize(string macro)
        {
            this.repository.Initialize(macro);
        }

    }
}