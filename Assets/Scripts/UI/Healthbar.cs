using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        healthText.text = slider.value.ToString("0");
    }

    public void UpdateHealth(float amount)
    {
        slider.value = amount;
        healthText.text = amount.ToString("0");
    }
}
