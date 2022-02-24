using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public void HealthBoost(Test target)
    {
        Debug.Log(target.playerName + "ü���� ��ȭ�ߴ�!");
        target.hp += 10;
    }

    public void ShieldBoost(Test target)
    {
        Debug.Log(target.playerName + "������ ��ȭ�ߴ�!");
        target.defense += 10;
    }

    public void DamageBoost(Test target)
    {
        Debug.Log(target.playerName + "���ݷ��� ��ȭ�ߴ�!");
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
