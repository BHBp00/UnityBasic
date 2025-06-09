using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    // 1. 이름 
    public string Name = "박성빈";

    // 2. 나이 
    public int age = 24;

    // 3. 키 
    public float height = 178f;

    // 4. MBTI
    public string mbti = "INTP";

    // 5. 좋아하는 음식 
    public string favoriteFood = "돈까스, 초밥";

    // 6. 혈액형 
    public char bloodType = 'A';

    // 7. 취미 
    public string[] hobbies = { "게임", "산책" };

    // 8. 좋아하는 게임 목록
    public List<string> favoriteGames = new List<string> { "발로란트", "이터널 리턴", "림버스 컴퍼니" };

    // 9. 좋아하는 노래 
    public string[] favoriteSongs = { "나는 아픈 건 딱 질색이니까", "Architect", "ヨルシカ - 晴る" };

    // 10. 좋아하는 계절 
    public string favoriteSeason = "겨울";

    private void PrintMyInfo()
    {
        Debug.Log($"1. 저의 이름 {Name}임니다");
        Debug.Log($"2. 저의 나이는 {age}세입니다");
        Debug.Log($"3. 저의 키는 {height}Cm입니다");
        Debug.Log($"4. 저의 MBTI는 {mbti}입니다");
        Debug.Log($"5. 제가 좋아하는 음식은 {favoriteFood}입니다");
        Debug.Log($"6. 저의 혈액형은 {bloodType}형입니다");
        
        string hobbyList = string.Join(", ", hobbies);
        Debug.Log($"7. 저의 취미는 {hobbyList}입니다");
       
        string gameList = string.Join(", ", favoriteGames);
        Debug.Log($"8. 제가 좋아하는 게임은 {gameList}입니다");
      
        string songList = string.Join(", ", favoriteSongs);
        Debug.Log($"9. 제가 좋아하는 노래는 {songList}입니다");

        Debug.Log($"10. 제가 좋아하는 계절은 {favoriteSeason}입니다");

    }
    private void Start()
    {
        PrintMyInfo();
    }
}