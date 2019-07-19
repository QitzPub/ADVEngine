using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore;
using System;

namespace Qitz.ADVGame
{
    //[CreateAssetMenu]
    public class ADVAudioDataStore : ADataStore, IADVAudioDataStore
    {
        [SerializeField]
        List<QitzAudioAsset> qitzAudios;
        public List<QitzAudioAsset> QitzAudios => qitzAudios;
    }

    [Serializable]
    public class QitzAudioAsset
    {
        [SerializeField]
        AudioClip audio;
        public AudioClip Audio => audio;
    }

    public interface IADVAudioDataStore
    {
        List<QitzAudioAsset> QitzAudios { get; }
    }


}