using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qitz.ADVGame
{
    public class MacroLoaderTest : MonoBehaviour
    {
        
        ADVGameDataStore dataStore;

        public TextAsset testMacro;
        // Start is called before the first frame update
        void Start()
        {
            if (testMacro == null)
            {
                TextAsset txt = Resources.Load<TextAsset>("TestMacro");
                dataStore = new ADVGameDataStore(txt.text);
            }
            else
            {
                dataStore = new ADVGameDataStore(testMacro.text);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}