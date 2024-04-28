using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType {DINHEIRO, ALIMENTO, PRODUTO}
public class Tecnology : MonoBehaviour
{
    //public ResourceType resourcetype;
    public float moneySubtract;
    public float foodSubtract;
    public float productSubtract;

    public float moneyGrowth;
    public float foodGrowth;
    public float productGrowth;

    public void ChangeAllGrowthRate()
    {
        GameManager.Instance.dinheiro.ChangeGrowthRate(moneyGrowth);
        GameManager.Instance.alimento.ChangeGrowthRate(foodGrowth);
        GameManager.Instance.produto.ChangeGrowthRate(productGrowth);
    }

    public void Farm()
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
    }
}
