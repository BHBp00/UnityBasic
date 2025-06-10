using UnityEngine;
using UnityEngine.UI;

public class RandomDraw : MonoBehaviour
{
    [Header("UI 참조 (Inspector에서 할당)")]
    [SerializeField] private GameObject drawShop;          // 메인(대기) 화면
    [SerializeField] private GameObject drawWindow;        // 뽑기 화면
    [SerializeField] private Image oneDrawImage;           // 1회 뽑기 출력용 Image 컴포넌트
    [SerializeField] private GameObject tenDrawContainer;  // 10회 뽑기 슬롯들이 들어있는 부모 오브젝트

    [Header("Sprites (Inspector 할당 또는 Resources)")]
    [SerializeField] private Sprite[] spr;                 // 뽑기용 스프라이트들

    private Image[] tenSlotImages;
    private bool isDrawingOne = false;
    private bool isDrawingTen = false;
    private float timer = 0f;
    private int drawCount = 0;

    void Start()
    {
        // UI 초기 상태
        drawShop.SetActive(true);
        drawWindow.SetActive(false);
        oneDrawImage.gameObject.SetActive(false);
        tenDrawContainer.SetActive(false);

        // Sprites 미할당 시 Resources에서 로드
        if (spr == null || spr.Length == 0)
            spr = Resources.LoadAll<Sprite>("Image");

        // Ten 슬롯 이미지 배열 캐싱
        int childCount = tenDrawContainer.transform.childCount;
        tenSlotImages = new Image[childCount];
        for (int i = 0; i < childCount; i++)
            tenSlotImages[i] = tenDrawContainer.transform.GetChild(i).GetComponent<Image>();

        // 슬롯 모두 비활성화
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

    // 1회 뽑기 시작
    public void OneDraw()
    {
        isDrawingOne = true;
        timer = 0f;

        drawShop.SetActive(false);
        drawWindow.SetActive(true);
        oneDrawImage.gameObject.SetActive(true);

        // 즉시 랜덤 스프라이트 할당
        int idx = Random.Range(0, spr.Length);
        oneDrawImage.sprite = spr[idx];
    }

    // 1회 뽑기 진행
    private void HandleOneDraw()
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            isDrawingOne = false;
            CloseDraw();
        }
    }

    // 10회 뽑기 시작
    public void TenDraw()
    {
        isDrawingTen = true;
        timer = 0f;
        drawCount = 0;

        drawShop.SetActive(false);
        drawWindow.SetActive(true);
        tenDrawContainer.SetActive(true);

        // 슬롯 리셋
        foreach (var img in tenSlotImages)
        {
            img.sprite = null;
            img.gameObject.SetActive(false);
        }
    }

    // 10회 뽑기 진행
    private void HandleTenDraw()
    {
        timer += Time.deltaTime;

        // 한 슬롯당 1초 간격으로 처리
        if (drawCount < tenSlotImages.Length && timer >= 1f)
        {
            int idx = Random.Range(0, spr.Length);
            tenSlotImages[drawCount].sprite = spr[idx];
            tenSlotImages[drawCount].gameObject.SetActive(true);

            drawCount++;
            timer = 0f;
        }

        // 10회 모두 끝나면 3초 뒤 닫기
        if (drawCount >= tenSlotImages.Length)
        {
            isDrawingTen = false;
            Invoke(nameof(CloseDraw), 3f);
        }
    }

    // 뽑기 화면 닫기
    private void CloseDraw()
    {
        drawShop.SetActive(true);
        drawWindow.SetActive(false);
        oneDrawImage.gameObject.SetActive(false);
        tenDrawContainer.SetActive(false);

        // 이미지 초기화
        oneDrawImage.sprite = null;
        foreach (var img in tenSlotImages)
            img.sprite = null;
    }
}

