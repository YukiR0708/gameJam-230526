using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _seAudioSouce;
    [SerializeField] AudioSource _bgmAudioSouce;
    [SerializeField] AudioClip[] _se;
    [SerializeField] AudioClip[] _bgm;

    public void SePlay(int index)
    {
        // 1âÒÇæÇØçƒê∂
        _seAudioSouce.PlayOneShot(_se[index]);
    }

    public void BgmPlay(int index)
    {
        _bgmAudioSouce.clip = _bgm[index];
        _bgmAudioSouce.Play();
        _bgmAudioSouce.loop = true;

    }


}
