using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySlider : MonoBehaviour
{
    [SerializeField] private string difficultySetting;
    [SerializeField] private float difficultyModifier;

    [SerializeField] private TMP_Text valueText;

    private Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();

        slider.value = PlayerPrefs.GetFloat(difficultySetting, difficultyModifier);
        valueText.text = slider.value.ToString("0.00");
    }

    public void Slider(float value)
    {
        difficultyModifier = Mathf.Round(value * 10.0f) * 0.1f;
        valueText.text = value.ToString("0.00");
    }

    public void SaveDifficulty()
    {

       Debug.Log("Saved");
       PlayerPrefs.SetFloat(difficultySetting, difficultyModifier);

       PlayerPrefs.Save();
    }
}
