using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UniversalBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public TextMeshProUGUI textValue;


	public void SetMaxValueEntity(int _maxHealth)
	{
		slider.maxValue = _maxHealth;
		slider.value = _maxHealth;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetValueEntity(int health)
	{
		slider.value = health; 
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

    //internal void SetMaxHealth(int maxHealth)
    //{
    //    throw new NotImplementedException();
    //}
}

