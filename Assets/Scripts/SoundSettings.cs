
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using AK.Wwise;

public class SoundSettings : MonoBehaviour
{
    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider MusicSlider;

    [SerializeField] private AK.Wwise.RTPC MasterBus;
    [SerializeField] private AK.Wwise.RTPC SFXBus;
    [SerializeField] private AK.Wwise.RTPC MusicBus;

    public float MasterVol = 0.9f;
    public float SFXVol = 0.9f;
    public float MusicVol = 0.9f;

    void Start()
    {

    }

    void Update()
    {
        MasterVol = MasterSlider.value;
        SFXVol = SFXSlider.value;
        MusicVol = MusicSlider.value;

        AkSoundEngine.SetRTPCValue("MasterBus", MasterVol * 100);
        AkSoundEngine.SetRTPCValue("SFXBus", SFXVol * 100);
        AkSoundEngine.SetRTPCValue("MusicBus", MusicVol * 100);
    }



}

