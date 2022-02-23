using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ArcherSetting();
        CrusaderSetting();
    }

    public void ArcherSetting()
    {
        CharacterArcher archer = new CharacterArcher();
        archer.Attack();
        archer.Evasion();
        archer.QSkill();
        archer.WSkill();
        archer.Evasion();
        archer.RSkill();
    }

    public void CrusaderSetting()
    {
        CharacterCrusader crusader = new CharacterCrusader();
        crusader.Attack();
        crusader.Evasion();
        crusader.QSkill();
        crusader.WSkill();
        crusader.Evasion();
        crusader.RSkill();
    }
}
