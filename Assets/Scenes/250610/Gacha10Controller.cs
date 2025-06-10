using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Gacha10Controller : MonoBehaviour
{
    [Header("�̱� ��� ��������Ʈ Ǯ")]
    public Sprite[] gachaPool;

    [Header("�� ��������Ʈ�� ����ġ (�迭 ũ�� == gachaPool.Length)")]
    [Tooltip("��: 50, 30, 20 ���� ������ �Է��ϸ�, ��ü �� 100���� 50%, 30%, 20% Ȯ���� �����ϴ�.")]
    public float[] weights;

    [Header("��� Image ���� (10��)")]
    public Image[] resultImages;

    [Header("10ȸ �̱� ��ư")]
    public Button gachaButton;

    void Start()
    {
        // 1) ��ư ����
        if (gachaButton == null) Debug.LogError("GachaButton �Ҵ� �ʿ�");
        else gachaButton.onClick.AddListener(DrawTen);

        // 2) ��������Ʈ Ǯ�갡��ġ ���� �ڵ� üũ
        if (weights == null || weights.Length != gachaPool.Length)
        {
            // Inspector���� �������� �� �ڵ����� �յ� Ȯ�� ����
            weights = Enumerable.Repeat(1f, gachaPool.Length).ToArray();
            Debug.LogWarning("weights �迭 ũ�Ⱑ gachaPool�� �޶�, �յ� Ȯ��(1:1:1:��)�� �ʱ�ȭ�մϴ�.");
        }

        // 3) ���� �ʱ�ȭ
        if (resultImages == null || resultImages.Length == 0)
            Debug.LogError("resultImages �迭 ���� �ʿ�");
        else
            foreach (var img in resultImages)
                if (img != null) img.enabled = false;
    }

    public void DrawTen()
    {
        // 10�� ���Ը��� (����)weights ������� ���� ����
        foreach (var img in resultImages)
        {
            if (img == null) continue;
            int idx = GetRandomIndexByWeight(weights);
            img.sprite = gachaPool[idx];
            img.enabled = true;
            Debug.Log($"���� �ε��� {idx} ({gachaPool[idx].name}), Ȯ�� = {weights[idx] / weights.Sum():P1}");
        }
    }

    // ����ġ ��� ���� �ε���
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
