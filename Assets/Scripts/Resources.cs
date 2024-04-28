using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using JetBrains.Annotations;

public class Resources : MonoBehaviour
{
    [Header("Atributos")]
    public string resourceName;
    public string description;
    public float quantity;
    public int maxQuantity;
    public float growthRate;

    [Header("UI")]
    public TextMeshProUGUI quantityUI;
    public TextMeshProUGUI growthRateUI;

    public void FixedUpdate()
    {
        GrowQuantity();
        UpdateResourceUI();

    }

    // Atualiza os Recursos na Interface, arredondando em duas casas decimais
    public void UpdateResourceUI()
    {
        //float roundedQuantity = Mathf.Round(quantity * 10)/10;
        quantityUI.text = quantity.ToString("F1").Replace(".", ",") + "/" + maxQuantity.ToString();

        growthRateUI.text = growthRate.ToString("F1").Replace(".", ",") + "/s";
    }

    // Atualiza os Recursos a cada segundo
    public void GrowQuantity()
    {
        if (quantity < maxQuantity)
        {
            if (quantity + growthRate * Time.fixedDeltaTime > maxQuantity)
            {
                quantity = maxQuantity;
            }
            else
            {
                quantity += growthRate * Time.fixedDeltaTime;
            }
        }

    }

    public void ChangeQuantity(float value)
    {
        quantity += value;
    }

    public void ChangeGrowthRate(float value)
    {
        growthRate += value;
    }

}
