using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusProgressBar : MonoBehaviour
{
    private bool isActive = false;
    private float IndicatorTimer;
    private float maxIndicator;

    private Image Bar;

    private void Awake()
    {
        Bar = GetComponent<Image>();   
    }


    public void ActivateCD(float CDT)
    {
        isActive = true;
        maxIndicator = CDT;
        IndicatorTimer = maxIndicator;
    }
    public void DeactivateCD()
    {
        isActive  = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            IndicatorTimer -= Time.deltaTime;
            Bar.fillAmount = (IndicatorTimer / maxIndicator);
            if (IndicatorTimer <= 0)
            {
                DeactivateCD();
            }
        }
    }
}
