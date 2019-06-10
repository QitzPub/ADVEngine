using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore;

namespace Qitz.ADVGame
{
    public class GameSystemInitializer : MonoBehaviour
    {

        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            var ga = new GameObject();
            PrefabFolder.ResourcesLoadInstantiateTo("ADVGameController", ga.transform.parent);
            Object.Destroy(ga);
        }
    }
}
