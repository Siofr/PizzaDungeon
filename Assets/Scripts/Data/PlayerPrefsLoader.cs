using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerPrefsLoader : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string[] mixerGroups;
    [SerializeField] private GameObject saveIndicator;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < mixerGroups.Length; i++)
        {
            audioMixer.SetFloat(mixerGroups[i], PlayerPrefs.GetFloat(mixerGroups[i]));
        }
    }

    public IEnumerator SaveIndicator()
    {
        saveIndicator.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        saveIndicator.SetActive(false);
    }
}
