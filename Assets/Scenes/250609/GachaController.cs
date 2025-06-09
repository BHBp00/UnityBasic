using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GachaController : MonoBehaviour
{
    // A) �̱� Ǯ & ��������Ʈ
    [SerializeField] private string[] characterNames;
    [SerializeField] private Sprite[] characterSprites;

    // B) ��Ƽ ī����
    private int pityCount = 0;

    // C) UI ����
    [SerializeField] private Button gachaButton;
    [SerializeField] private Image[] resultImages; // ���� 10

    void Start()
    {
        // ��ư�� �޼��� ����
        gachaButton.onClick.AddListener(OnGachaButtonClicked);
    }

    // D) �ܹ� �̱� (�ε��� ��ȯ)
    private int PerformSinglePull()
    {
        int rv = Random.Range(1, 101);
        if (pityCount >= 8)
        {
            pityCount = 0;
            return 0;              // �� Ǯ[0] Ȯ��
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

    // E) 10���� �޼���
    public void OnGachaButtonClicked()
    {
        pityCount = 0;                             // ���� ���� �� �ʱ�ȭ
        List<int> results = new List<int>(10);

        for (int i = 0; i < 10; i++)
        {
            results.Add(PerformSinglePull());
        }

        DisplayResults(results);
    }

    // F) UI�� ����
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
