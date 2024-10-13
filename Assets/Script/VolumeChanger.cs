using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using UnityEditor;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] Slider volume;

    void Start() {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        } else {
            Load();
        }
    }

    public void changeVolume() {
        AudioListener.volume = volume.value;
        Save();
    }

    private void Load() {
        volume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save() {
        PlayerPrefs.SetFloat("musicVolume", volume.value);
    }
}
