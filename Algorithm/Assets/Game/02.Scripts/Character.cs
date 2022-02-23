using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public virtual void Attack()
    {
        Debug.Log("Normal attack");
    }

    public virtual void Evasion()
    {
        Debug.Log("evasion");
    }

    public abstract void QSkill();
    public abstract void WSkill();
    public abstract void ESkill();
    public abstract void RSkill();
}
