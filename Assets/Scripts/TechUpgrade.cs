using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UIElements;
using DG.Tweening;
using UnityEditor.UI;

public enum TechType
{
    AddGrowthRate,
    SetMaxQuantity
}

public class Tecnology : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public TechType type;
    [Header("Preço")]
    public float moneySubtract;
    public float foodSubtract;
    public float productSubtract;
    [Header("Recompensa")]
    public float moneyGain;
    public float foodGain;
    public float productGain;
    public GameObject[] techList;
    [Header("UI")]
    public TextMeshProUGUI moneyUI;
    public TextMeshProUGUI foodUI;
    public TextMeshProUGUI productUI;
    [TextArea(4,6)]
    public string description;

    private bool pointerOver = false;

    public void ApplyReward()
    {
        switch (type)
        {
            case TechType.AddGrowthRate:
                GameManager.Instance.dinheiro.ChangeGrowthRate(moneyGain);
                GameManager.Instance.alimento.ChangeGrowthRate(foodGain);
                GameManager.Instance.produto.ChangeGrowthRate(productGain);
                break;
            case TechType.SetMaxQuantity:
                GameManager.Instance.dinheiro.SetMaxQuantity((int)moneyGain);
                GameManager.Instance.alimento.SetMaxQuantity((int)foodGain);
                GameManager.Instance.produto.SetMaxQuantity((int)productGain);
                break;
        }
    }

    public void OnClick()
    {
        int enoughResources = -2;
        if (GameManager.Instance.dinheiro.quantity >= moneySubtract)
        {
            enoughResources++;
        }
        if (GameManager.Instance.alimento.quantity >= foodSubtract)
        {
            enoughResources++;
        }
        if (GameManager.Instance.produto.quantity >= productSubtract)
        {
            enoughResources++;
        }

        if (enoughResources == 1)
        {
            GameManager.Instance.dinheiro.ChangeQuantity(-moneySubtract);
            GameManager.Instance.alimento.ChangeQuantity(-foodSubtract);
            GameManager.Instance.produto.ChangeQuantity(-productSubtract);
            ApplyReward();
            GameUIManager.Instance.techDescriptionBox.SetActive(false);
            foreach(GameObject tecnologia in techList)
            {
                tecnologia.SetActive(true);
            }
            this.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).SetEase(Ease.OutExpo).onComplete = RemoveTech;
        }
    }

    public void RemoveTech()
    {
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        moneyUI.text = moneySubtract.ToString();
        foodUI.text = foodSubtract.ToString();
        productUI.text = productSubtract.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerOver = true;
        GameUIManager.Instance.techDescriptionBox.SetActive(true);
        GameUIManager.Instance.techDescriptionBox.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
        GameUIManager.Instance.techDescriptionText.text = description;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerOver = false;
        GameUIManager.Instance.techDescriptionBox.SetActive(false);
    }



    private void Update()
    {
        if (pointerOver)
        {
            GameUIManager.Instance.techDescriptionBox.GetComponent<RectTransform>().position = Input.mousePosition + new Vector3(-10, -10, 0);
        }
    }
}
