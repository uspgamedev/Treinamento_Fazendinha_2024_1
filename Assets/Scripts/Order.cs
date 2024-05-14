using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class Order : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public float timer;
    private float vartimer;

    private bool pointerOver;

    public TextMeshProUGUI timerUI;

    [TextArea(4, 6)]
    public string description;

    public void SellResources()
    {
        /*
        int moneyAdd1;
        int moneyAdd2;
        if (GameManager.Instance.alimento.quantity >= 10 || GameManager.Instance.produto.quantity >= 2)
        {
            moneyAdd1 = (int)GameManager.Instance.alimento.quantity / 10;
            moneyAdd2 = (int)GameManager.Instance.produto.quantity / 2;
            GameManager.Instance.alimento.ChangeQuantity(moneyAdd1 * -10);
            GameManager.Instance.produto.ChangeQuantity(moneyAdd2 * -2);
            GameManager.Instance.dinheiro.ChangeQuantity(moneyAdd1 + moneyAdd2);
            timer = vartimer;
        }
        */
        bool hasEnoughResources = false;
        if (GameManager.Instance.alimento.quantity >= 10 && GameManager.Instance.dinheiro.quantity + 1 <= GameManager.Instance.dinheiro.maxQuantity)
        {
            GameManager.Instance.alimento.ChangeQuantity(-10);
            GameManager.Instance.dinheiro.ChangeQuantity(1);
            hasEnoughResources = true;
        }
        if (GameManager.Instance.produto.quantity >= 2 && GameManager.Instance.dinheiro.quantity + 1 <= GameManager.Instance.dinheiro.maxQuantity)
        {
            GameManager.Instance.produto.ChangeQuantity(-2);
            GameManager.Instance.dinheiro.ChangeQuantity(1);
            hasEnoughResources = true;
        }
        if (hasEnoughResources)
        {
            timer = vartimer;
        }
        
    }

    public void RefineResources()
    {
        float conversionValue;
        conversionValue = GameManager.Instance.alimento.quantity / 2;
        GameManager.Instance.produto.ChangeQuantity(conversionValue);
        GameManager.Instance.alimento.ResetQuantity();
        timer = vartimer;
    }

    public void ButtonCooldown()
    {
        if (timer > 0f)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
            timer -= Time.fixedDeltaTime;
        } 
        else
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void UpdateUI()
    {
        if (timer > 0f)
        {
            timerUI.text = timer.ToString("F1").Replace(".", ",");
        }
        else
        {
            timerUI.text = "";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerOver = true;
        GameUIManager.Instance.techDescriptionBox.SetActive(true);
        GameUIManager.Instance.techDescriptionBox.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        GameUIManager.Instance.techDescriptionText.text = description;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerOver = false;
        GameUIManager.Instance.techDescriptionBox.SetActive(false);
    }

    public void DescriptionBoxUpdate()
    {
        if (pointerOver)
        {
            GameUIManager.Instance.techDescriptionBox.GetComponent<RectTransform>().position = Input.mousePosition + new Vector3(10, 10, 0);
        }
    }


    private void Awake()
    {
        vartimer = timer;
    }


    private void FixedUpdate()
    {
        ButtonCooldown();
        UpdateUI();
        DescriptionBoxUpdate();
    }

}
