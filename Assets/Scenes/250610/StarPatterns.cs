using UnityEngine;

public class StarPhases : MonoBehaviour
{
    private string star;

    void Start()
    {
        Phase1();
        Phase2();
    }

    // Phase1: 왼쪽 정렬 삼각형 (높이 5)
    public void Phase1()
    {
        star = string.Empty;
        int n = 5;
        for (int i = 1; i <= n; i++)
        {
            // 별 i개
            star += new string('★', i);
            star += "\n";
        }
        Debug.Log(star);
    }

    // Phase2: 오른쪽 정렬 삼각형 (높이 5)
    public void Phase2()
    {
        star = string.Empty;
        int n = 5;
        for (int i = 1; i <= n; i++)
        {
            // 공백 n-i, 별 i개
            star += new string('　', n - i)
                  + new string('★', i)
                  + "\n";
        }
        Debug.Log(star);
    }

        }
    
