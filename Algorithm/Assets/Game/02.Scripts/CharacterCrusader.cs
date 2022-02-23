using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCrusader : Character
{
    public override void QSkill()
    {
        Debug.Log("Crusader slash");
    }

    public override void WSkill()
    {
        Debug.Log("Crusader guard");
    }

    public override void ESkill()
    {
        Debug.Log("Crusader crowd control");
    }

    public override void RSkill()
    {
        Debug.Log("Crusader ultimate");
    }
}
