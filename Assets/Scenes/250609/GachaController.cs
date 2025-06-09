using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GachaController : MonoBehaviour
{
    // A) 뽑기 풀 & 스프라이트
    [SerializeField] private string[] characterNames;
    [SerializeField] private Sprite[] characterSprites;

    // B) 피티 카운터
    private int pityCount = 0;

    // C) UI 참조
    [SerializeField] private Button gachaButton;
    [SerializeField] private Image[] resultImages; // 길이 10

    void Start()
    {
        // 버튼과 메서드 연결
        gachaButton.onClick.AddListener(OnGachaButtonClicked);
    }

    // D) 단발 뽑기 (인덱스 반환)
    private int PerformSinglePull()
    {
        int rv = Random.Range(1, 101);
        if (pityCount >= 8)
        {
            pityCount = 0;
            return 0;              // ★ 풀[0] 확정
        }
        if (rv <= 10)
        {
            pityCount = 0;
            return 0;
        }
        else if (rv <= 30)
        {
            pityCount++;
            return 1;
        }
        else
        {
            pityCount++;
            return 2;
        }
    }

    // E) 10연차 메서드
    public void OnGachaButtonClicked()
    {
        pityCount = 0;                             // 연차 시작 시 초기화
        List<int> results = new List<int>(10);

        for (int i = 0; i < 10; i++)
        {
            results.Add(PerformSinglePull());
        }

        DisplayResults(results);
    }

    // F) UI에 띄우기
    private void DisplayResults(List<int> results)
    {
        for (int i = 0; i < resultImages.Length && i < results.Count; i++)
        {
            int idx = results[i];
            resultImages[i].sprite = characterSprites[idx];
            resultImages[i].gameObject.SetActive(true);
        }
    }
}
