using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class VolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _exposedParameter;
    [SerializeField] private float _maxVolume;
    
    private Slider _volumeSlider;
    private float _minSliderValue = 0.0001f;
    private float _maxSliderValue = 1f;
    private float _zeroVolume = -80f;
    
    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }
    
    private void OnDestroy()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }
    
    private void ChangeVolume(float sliderValue)
    {
        float parameterValue = Mathf.Log10(Mathf.Clamp(sliderValue, _minSliderValue, _maxSliderValue)) * (_maxVolume - _zeroVolume) / 4f + _maxVolume;
        _audioMixer.SetFloat(_exposedParameter, parameterValue);
    }
}
