using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    // 1. �̸� 
    public string Name = "�ڼ���";

    // 2. ���� 
    public int age = 24;

    // 3. Ű 
    public float height = 178f;

    // 4. MBTI
    public string mbti = "INTP";

    // 5. �����ϴ� ���� 
    public string favoriteFood = "���, �ʹ�";

    // 6. ������ 
    public char bloodType = 'A';

    // 7. ��� 
    public string[] hobbies = { "����", "��å" };

    // 8. �����ϴ� ���� ���
    public List<string> favoriteGames = new List<string> { "�߷ζ�Ʈ", "���ͳ� ����", "������ ���۴�" };

    // 9. �����ϴ� �뷡 
    public string[] favoriteSongs = { "���� ���� �� �� �����̴ϱ�", "Architect", "��뫷�� - ���" };

    // 10. �����ϴ� ���� 
    public string favoriteSeason = "�ܿ�";

    private void PrintMyInfo()
    {
        Debug.Log($"1. ���� �̸� {Name}�Ӵϴ�");
        Debug.Log($"2. ���� ���̴� {age}���Դϴ�");
        Debug.Log($"3. ���� Ű�� {height}Cm�Դϴ�");
        Debug.Log($"4. ���� MBTI�� {mbti}�Դϴ�");
        Debug.Log($"5. ���� �����ϴ� ������ {favoriteFood}�Դϴ�");
        Debug.Log($"6. ���� �������� {bloodType}���Դϴ�");
        
        string hobbyList = string.Join(", ", hobbies);
        Debug.Log($"7. ���� ��̴� {hobbyList}�Դϴ�");
       
        string gameList = string.Join(", ", favoriteGames);
        Debug.Log($"8. ���� �����ϴ� ������ {gameList}�Դϴ�");
      
        string songList = string.Join(", ", favoriteSongs);
        Debug.Log($"9. ���� �����ϴ� �뷡�� {songList}�Դϴ�");

        Debug.Log($"10. ���� �����ϴ� ������ {favoriteSeason}�Դϴ�");

    }
    private void Start()
    {
        PrintMyInfo();
    }
}