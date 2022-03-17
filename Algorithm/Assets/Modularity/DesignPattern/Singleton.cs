using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    // 다른오브젝트에서 인스턴스 접근가능하도록 전역변수로 선언
    public static Singleton instance = null;

    void Awake()
    {
        // instance가 존재하지 않을때
        if(instance == null)
        {
            instance = this; // 자신을 instnace로 넣어준다.
            DontDestroyOnLoad(gameObject); // 씬전환시 파괴되지 않도록 설정
        }
        else
        {
            if(instance != this) // 자기 자신이외의 이미 instance가 존재할경우 
            {
                Destroy(this.gameObject); // 둘 이상 존재하면 안되기 때문에 생성된 게임오브젝트 삭제
            }
        }
    }
}
