using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tecnology : MonoBehaviour
{
    //public ResourceType resourcetype;
    [Header("Preço em recursos")]
    public float moneySubtract;
    public float foodSubtract;
    public float productSubtract;
    [Header("Aumento da taxa")]
    public float moneyGrowth;
    public float foodGrowth;
    public float productGrowth;
    [Header("UI")]
    public TextMeshProUGUI moneyUI;
    public TextMeshProUGUI foodUI;
    public TextMeshProUGUI productUI;

    public void ChangeAllGrowthRate()
    {
        GameManager.Instance.dinheiro.ChangeGrowthRate(moneyGrowth);
        GameManager.Instance.alimento.ChangeGrowthRate(foodGrowth);
        GameManager.Instance.produto.ChangeGrowthRate(productGrowth);
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
            ChangeAllGrowthRate();
        }
        Destroy(gameObject);
    }

    private void Awake()
    {
        moneyUI.text = moneySubtract.ToString();
        foodUI.text = foodSubtract.ToString();
        productUI.text = productSubtract.ToString();
    }
}
