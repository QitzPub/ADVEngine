using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qitz.ADVGame
{
    public class MacroLoaderTest : MonoBehaviour
    {
        
        ADVGameDataStore dataStore;
        // Start is called before the first frame update
        void Start()
        {
            TextAsset txt = Resources.Load<TextAsset>("TestMacro");
            dataStore = new ADVGameDataStore(txt.text);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}