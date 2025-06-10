using UnityEngine;

public class StarPhases : MonoBehaviour
{
    private string star;

    void Start()
    {
        Phase1();
        Phase2();
    }

    // Phase1: ���� ���� �ﰢ�� (���� 5)
    public void Phase1()
    {
        star = string.Empty;
        int n = 5;
        for (int i = 1; i <= n; i++)
        {
            // �� i��
            star += new string('��', i);
            star += "\n";
        }
        Debug.Log(star);
    }

    // Phase2: ������ ���� �ﰢ�� (���� 5)
    public void Phase2()
    {
        star = string.Empty;
        int n = 5;
        for (int i = 1; i <= n; i++)
        {
            // ���� n-i, �� i��
            star += new string('��', n - i)
                  + new string('��', i)
                  + "\n";
        }
        Debug.Log(star);
    }

        }
    
