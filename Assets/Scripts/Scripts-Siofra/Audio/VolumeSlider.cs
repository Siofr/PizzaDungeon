using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    // Remember you have to expose the mixer group so they can be accessed by AudioMixer.SetFloat()! To do this:
    // Click on the Group in the Mixer
    // Right click volume in the inspector panel and click expose to script

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string mixerGroup;
    [SerializeField] private TMP_Text volumeText;

    private Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();

        audioMixer.SetFloat(mixerGroup, PlayerPrefs.GetFloat(mixerGroup));

        bool isSet = audioMixer.GetFloat(mixerGroup, out float audioVolume);

        if (isSet)
        {
            Debug.Log("Set");
            slider.value = Mathf.Pow(10, audioVolume / 20);
        }
    }

    public void Slider(float value)
    {
        float audioVolume = Mathf.Log10(value) * 20;
        audioVolume = Mathf.Clamp(audioVolume, -60, 0);
        audioMixer.SetFloat(mixerGroup, audioVolume);

        volumeText.text = (value * 100).ToString("0");
    }

    public void SaveVolume()
    {
        bool isSet = audioMixer.GetFloat(mixerGroup, out float audioVolume);

        if (isSet)
        {
            Debug.Log("Saved");
            PlayerPrefs.SetFloat(mixerGroup, audioVolume);
        }

        PlayerPrefs.Save();
    }
}
