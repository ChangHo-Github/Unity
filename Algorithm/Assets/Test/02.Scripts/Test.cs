using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Test : MonoBehaviour
{
    public delegate void Test2(Test target);
    public Test2 playerBoost;
    

    public string playerName = "Neon";
    public float hp = 100;
    public float defense = 50;
    public float damage = 30;

    void Start()
    {
        playerBoost(this);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerBoost(this);
        }
    }
}
