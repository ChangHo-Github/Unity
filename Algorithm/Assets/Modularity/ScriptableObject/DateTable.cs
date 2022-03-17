using UnityEngine;

/*
 * 1. 유니티에서 오브젝트 정보를 설정할때 사용한다.
 * 2. 에셋번들을 이용하면 객체안에 존재하는 스크립트블 오브젝트 정보를 수정할 수 있다.
 */

[CreateAssetMenu(fileName = "DateTableName", menuName = "DateTable/TestDateTable", order = int.MaxValue)]
public class DateTable : ScriptableObject
{
    public string targetName;
    public int hp;
    public int mp;
    public float speed;
}
