using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Remember you have to expose the mixer group so they can be accessed by AudioMixer.SetFloat()! To do this:
    // Click on the Group in the Mixer
    // Right click volume in the inspector panel and click expose to script

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string mixerGroup;

    // As a rule, Audio Volume should never go above 0.00 dB, you can get audio clipping if it does and its bad practice :(
    // Remember this when designing sound effects too
    // Audio volume is between -80dB and ideally 0.00dB, but -60dB is generally inaudible
    // The volume sliders are set from 0 to 1 (Percentage Values!), therefore each change of value of 0.01 in the slider is a change in 0.6dB in volume, between -60dB and 0dB

    // Why we're using Mathf.Log10(slider.value) * 20: https://en.wikipedia.org/wiki/Decibel#Uses, human ears hear on a logarithmic scale

    public void Slider(float value)
    {
        // There's no reason the audio should go over 0.00dB without the clamp, but I'll do it anyway just in case :)
        float audioVolume = Mathf.Log10(value) * 20;
        audioVolume = Mathf.Clamp(audioVolume, -60, 0);
        audioMixer.SetFloat(mixerGroup, audioVolume);
    }
}
