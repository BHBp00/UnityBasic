using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFlow : MonoBehaviour
{
    // 1) 캐릭터 풀 정의 (배열)
    [SerializeField] private string[] characters = new string[] { "각청", "모나", "치치" };

    // 피티(확정) 카운터
    private int pityCount = 0;

    void Awake()
    {
        // 피티 초기화
        pityCount = 0;
    }

    // ★ 버튼 OnClick에 연결할 메서드 ★
    // Inspector > Button 컴포넌트 > OnClick() 리스트에 이 함수를 등록하세요.
    public void Gacha()
    {
        // 10연차 시작할 때마다 피티 초기화
        pityCount = 0;

        for (int i = 0; i < 10; i++)
        {
            int randomValue = Random.Range(1, 101); // 1~100
            string pulled;

            if (pityCount >= 8)               // 8회째 피티
            {
                pulled = characters[0];       // "각청"
                pityCount = 0;
            }
            else if (randomValue <= 10)       // 10%
            {
                pulled = characters[0];
                pityCount = 0;
            }
            else if (randomValue <= 30)       // 20%
            {
                pulled = characters[1];       // "모나"
                pityCount++;
            }
            else                              // 70%
            {
                pulled = characters[2];       // "치치"
                pityCount++;
            }

            Debug.Log($"[{i + 1}회차] 뽑힌 캐릭터: {pulled}");
        }
    }
}