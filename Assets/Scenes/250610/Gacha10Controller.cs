using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Gacha10Controller : MonoBehaviour
{
    [Header("뽑기 대상 스프라이트 풀")]
    public Sprite[] gachaPool;

    [Header("각 스프라이트별 가중치 (배열 크기 == gachaPool.Length)")]
    [Tooltip("예: 50, 30, 20 같은 식으로 입력하면, 전체 합 100에서 50%, 30%, 20% 확률로 뽑힙니다.")]
    public float[] weights;

    [Header("결과 Image 슬롯 (10개)")]
    public Image[] resultImages;

    [Header("10회 뽑기 버튼")]
    public Button gachaButton;

    void Start()
    {
        // 1) 버튼 연결
        if (gachaButton == null) Debug.LogError("GachaButton 할당 필요");
        else gachaButton.onClick.AddListener(DrawTen);

        // 2) 스프라이트 풀↔가중치 길이 자동 체크
        if (weights == null || weights.Length != gachaPool.Length)
        {
            // Inspector에서 깜빡했을 때 자동으로 균등 확률 세팅
            weights = Enumerable.Repeat(1f, gachaPool.Length).ToArray();
            Debug.LogWarning("weights 배열 크기가 gachaPool과 달라서, 균등 확률(1:1:1:…)로 초기화합니다.");
        }

        // 3) 슬롯 초기화
        if (resultImages == null || resultImages.Length == 0)
            Debug.LogError("resultImages 배열 설정 필요");
        else
            foreach (var img in resultImages)
                if (img != null) img.enabled = false;
    }

    public void DrawTen()
    {
        // 10개 슬롯마다 (전역)weights 기반으로 랜덤 선택
        foreach (var img in resultImages)
        {
            if (img == null) continue;
            int idx = GetRandomIndexByWeight(weights);
            img.sprite = gachaPool[idx];
            img.enabled = true;
            Debug.Log($"뽑힌 인덱스 {idx} ({gachaPool[idx].name}), 확률 = {weights[idx] / weights.Sum():P1}");
        }
    }

    // 가중치 기반 랜덤 인덱스
    int GetRandomIndexByWeight(float[] w)
    {
        float total = w.Sum();
        float r = Random.value * total;
        float cum = 0f;
        for (int i = 0; i < w.Length; i++)
        {
            cum += w[i];
            if (r <= cum) return i;
        }
        return w.Length - 1;
    }
}
