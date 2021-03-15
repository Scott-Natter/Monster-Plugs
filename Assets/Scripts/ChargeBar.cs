using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text PercentText;

    public void SetMaxCharge(float charge)
    {
        slider.maxValue = charge;
        slider.value = charge;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetCharge(float charge)
    {
        slider.value = charge;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void DepleteCharge(float charge)
    {
        slider.value -= charge;
        PercentText.text = Mathf.Round(slider.value) + "%";

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
