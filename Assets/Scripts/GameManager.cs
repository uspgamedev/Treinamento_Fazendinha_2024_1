using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    [Header("Resources")]
    public Resources dinheiro;
    public Resources alimento;
    public Resources produto;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }
}
