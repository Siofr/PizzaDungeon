using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerPrefsLoader : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string[] mixerGroups;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;

        for (int i = 0; i < mixerGroups.Length; i++)
        {
            audioMixer.SetFloat(mixerGroups[i], PlayerPrefs.GetFloat(mixerGroups[i]));
        }
    }
}
