using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public void SellResources()
    {
        int moneyAdd1;
        int moneyAdd2;
        if (GameManager.Instance.alimento.quantity >= 10 || GameManager.Instance.produto.quantity >= 2 )
        {
            moneyAdd1 = (int)GameManager.Instance.alimento.quantity /10;
            moneyAdd2 = (int)GameManager.Instance.produto.quantity / 2;
            GameManager.Instance.alimento.ChangeQuantity(moneyAdd1 * -10);
            GameManager.Instance.produto.ChangeQuantity(moneyAdd2 * -2);
            GameManager.Instance.dinheiro.ChangeQuantity(moneyAdd1 + moneyAdd2);
        }
    }
}
