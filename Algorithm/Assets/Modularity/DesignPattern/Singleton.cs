using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    // �ٸ�������Ʈ���� �ν��Ͻ� ���ٰ����ϵ��� ���������� ����
    public static Singleton instance = null;

    void Awake()
    {
        // instance�� �������� ������
        if(instance == null)
        {
            instance = this; // �ڽ��� instnace�� �־��ش�.
            DontDestroyOnLoad(gameObject); // ����ȯ�� �ı����� �ʵ��� ����
        }
        else
        {
            if(instance != this) // �ڱ� �ڽ��̿��� �̹� instance�� �����Ұ�� 
            {
                Destroy(this.gameObject); // �� �̻� �����ϸ� �ȵǱ� ������ ������ ���ӿ�����Ʈ ����
            }
        }
    }
}
