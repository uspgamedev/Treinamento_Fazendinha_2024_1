using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MoneyAmount : MonoBehaviour
{

    private int money;
    [SerializeField] private TextMeshProUGUI texto;
    //public GameManager gamemanager;
    //public GameObject gm;

    // Start is called before the first frame update
    void Start()
    {
        //money = PlayerPrefs.GetInt("quantia");
        texto.text = "$ " + money;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            money += 1;
            //GameManager.Instance.square.GetComponent<SpriteRenderer>().color = Color.red;
            //gamemanager.square.GetComponent<SpriteRenderer>().color = Color.red;
            //gm.GetComponent<GameManager>().square.GetComponent<SpriteRenderer>().color = Color.red;
            //PlayerPrefs.SetInt("quantia", money);
        }

        texto.text = "$ " + money;
    }

    public void AddMoney(int moneyAdded)
    {
        money += moneyAdded;
    }
}
