using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Button))]

public class SoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private Button _button;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Play);
    }
    
    private void OnDestroy()
    {
        _button.onClick.RemoveListener(Play);
    }
    
    private void Play()
    {
        _audioSource.Play();
    }
}
