using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFlow : MonoBehaviour
{
    // 1) ĳ���� Ǯ ���� (�迭)
    [SerializeField] private string[] characters = new string[] { "��û", "��", "ġġ" };

    // ��Ƽ(Ȯ��) ī����
    private int pityCount = 0;

    void Awake()
    {
        // ��Ƽ �ʱ�ȭ
        pityCount = 0;
    }

    // �� ��ư OnClick�� ������ �޼��� ��
    // Inspector > Button ������Ʈ > OnClick() ����Ʈ�� �� �Լ��� ����ϼ���.
    public void Gacha()
    {
        // 10���� ������ ������ ��Ƽ �ʱ�ȭ
        pityCount = 0;

        for (int i = 0; i < 10; i++)
        {
            int randomValue = Random.Range(1, 101); // 1~100
            string pulled;

            if (pityCount >= 8)               // 8ȸ° ��Ƽ
            {
                pulled = characters[0];       // "��û"
                pityCount = 0;
            }
            else if (randomValue <= 10)       // 10%
            {
                pulled = characters[0];
                pityCount = 0;
            }
            else if (randomValue <= 30)       // 20%
            {
                pulled = characters[1];       // "��"
                pityCount++;
            }
            else                              // 70%
            {
                pulled = characters[2];       // "ġġ"
                pityCount++;
            }

            Debug.Log($"[{i + 1}ȸ��] ���� ĳ����: {pulled}");
        }
    }
}