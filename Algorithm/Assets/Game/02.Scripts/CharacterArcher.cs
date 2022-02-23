using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterArcher : Character
{
    public override void Attack()
    {
        base.Attack();
        Debug.Log("��ó�� �⺻������ 2���Դϴ�.");
    }

    public override void Evasion()
    {
        base.Evasion();
    }

    public override void QSkill()
    {
        Debug.Log("Archer zoom shot");
    }
    
    public override void WSkill()
    {
        Debug.Log("Archer multiple shot");
    }

    public override void ESkill()
    {
        Debug.Log("Archer slow arror");
    }

    public override void RSkill()
    {
        Debug.Log("Archer ultimate");
    }


}
