using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Data/AudioData")]
public class AudioData : ScriptableObject
{
    public AudioClip backgroundMusic;
    public AudioClip tapFx;
    public AudioClip winnerFx;
}
