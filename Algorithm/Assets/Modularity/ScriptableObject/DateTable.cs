using UnityEngine;

/*
 * 1. ����Ƽ���� ������Ʈ ������ �����Ҷ� ����Ѵ�.
 * 2. ���¹����� �̿��ϸ� ��ü�ȿ� �����ϴ� ��ũ��Ʈ�� ������Ʈ ������ ������ �� �ִ�.
 */

[CreateAssetMenu(fileName = "DateTableName", menuName = "DateTable/TestDateTable", order = int.MaxValue)]
public class DateTable : ScriptableObject
{
    public string targetName;
    public int hp;
    public int mp;
    public float speed;
}
