using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class MuteButton : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private const string ExposedParameter = "MasterVolume";
    private float _lastValue;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChangeVolume);
    }
    
    private void ChangeVolume()
    {
        if (_audioMixer.GetFloat(ExposedParameter, out float value) && value > -80)
        {
            _lastValue = value;
            _audioMixer.SetFloat(ExposedParameter, -80);
        }
        else
        {
            _audioMixer.SetFloat(ExposedParameter, _lastValue);
        }
    }
    
}
