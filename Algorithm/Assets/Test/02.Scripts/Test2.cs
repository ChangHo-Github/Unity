using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public void HealthBoost(Test target)
    {
        Debug.Log(target.playerName + "체력을 강화했다!");
        target.hp += 10;
    }

    public void ShieldBoost(Test target)
    {
        Debug.Log(target.playerName + "방어력을 강화했다!");
        target.defense += 10;
    }

    public void DamageBoost(Test target)
    {
        Debug.Log(target.playerName + "공격력을 강화했다!");
        target.damage += 10;
    }

    void Awake()
    {
        Test player = FindObjectOfType<Test>();
        player.playerBoost += HealthBoost;
        player.playerBoost += ShieldBoost;
        player.playerBoost += DamageBoost;
    }
}
