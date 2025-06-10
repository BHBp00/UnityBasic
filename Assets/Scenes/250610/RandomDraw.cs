using UnityEngine;
using UnityEngine.UI;

public class RandomDraw : MonoBehaviour
{
    [Header("UI ���� (Inspector���� �Ҵ�)")]
    [SerializeField] private GameObject drawShop;          // ����(���) ȭ��
    [SerializeField] private GameObject drawWindow;        // �̱� ȭ��
    [SerializeField] private Image oneDrawImage;           // 1ȸ �̱� ��¿� Image ������Ʈ
    [SerializeField] private GameObject tenDrawContainer;  // 10ȸ �̱� ���Ե��� ����ִ� �θ� ������Ʈ

    [Header("Sprites (Inspector �Ҵ� �Ǵ� Resources)")]
    [SerializeField] private Sprite[] spr;                 // �̱�� ��������Ʈ��

    private Image[] tenSlotImages;
    private bool isDrawingOne = false;
    private bool isDrawingTen = false;
    private float timer = 0f;
    private int drawCount = 0;

    void Start()
    {
        // UI �ʱ� ����
        drawShop.SetActive(true);
        drawWindow.SetActive(false);
        oneDrawImage.gameObject.SetActive(false);
        tenDrawContainer.SetActive(false);

        // Sprites ���Ҵ� �� Resources���� �ε�
        if (spr == null || spr.Length == 0)
            spr = Resources.LoadAll<Sprite>("Image");

        // Ten ���� �̹��� �迭 ĳ��
        int childCount = tenDrawContainer.transform.childCount;
        tenSlotImages = new Image[childCount];
        for (int i = 0; i < childCount; i++)
            tenSlotImages[i] = tenDrawContainer.transform.GetChild(i).GetComponent<Image>();

        // ���� ��� ��Ȱ��ȭ
        foreach (var img in tenSlotImages)
            img.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isDrawingOne)
            HandleOneDraw();
        else if (isDrawingTen)
            HandleTenDraw();
    }

    // 1ȸ �̱� ����
    public void OneDraw()
    {
        isDrawingOne = true;
        timer = 0f;

        drawShop.SetActive(false);
        drawWindow.SetActive(true);
        oneDrawImage.gameObject.SetActive(true);

        // ��� ���� ��������Ʈ �Ҵ�
        int idx = Random.Range(0, spr.Length);
        oneDrawImage.sprite = spr[idx];
    }

    // 1ȸ �̱� ����
    private void HandleOneDraw()
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            isDrawingOne = false;
            CloseDraw();
        }
    }

    // 10ȸ �̱� ����
    public void TenDraw()
    {
        isDrawingTen = true;
        timer = 0f;
        drawCount = 0;

        drawShop.SetActive(false);
        drawWindow.SetActive(true);
        tenDrawContainer.SetActive(true);

        // ���� ����
        foreach (var img in tenSlotImages)
        {
            img.sprite = null;
            img.gameObject.SetActive(false);
        }
    }

    // 10ȸ �̱� ����
    private void HandleTenDraw()
    {
        timer += Time.deltaTime;

        // �� ���Դ� 1�� �������� ó��
        if (drawCount < tenSlotImages.Length && timer >= 1f)
        {
            int idx = Random.Range(0, spr.Length);
            tenSlotImages[drawCount].sprite = spr[idx];
            tenSlotImages[drawCount].gameObject.SetActive(true);

            drawCount++;
            timer = 0f;
        }

        // 10ȸ ��� ������ 3�� �� �ݱ�
        if (drawCount >= tenSlotImages.Length)
        {
            isDrawingTen = false;
            Invoke(nameof(CloseDraw), 3f);
        }
    }

    // �̱� ȭ�� �ݱ�
    private void CloseDraw()
    {
        drawShop.SetActive(true);
        drawWindow.SetActive(false);
        oneDrawImage.gameObject.SetActive(false);
        tenDrawContainer.SetActive(false);

        // �̹��� �ʱ�ȭ
        oneDrawImage.sprite = null;
        foreach (var img in tenSlotImages)
            img.sprite = null;
    }
}

