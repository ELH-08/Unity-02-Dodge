using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //UI관련 Library 들여오기
using UnityEngine.SceneManagement;      //SceneManager 관련 Library 들여오기



 public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;     //게임종료 글자 (GameObject -> 상태 활성화,비활성화만 변경)
    public Text survivalTimeText;       //생존시간 글자 (Text -> text 컴퍼넌트에 접근해 실시간 글자 변경을 위함)
    public Text bestRecordText;         //최고기록 글자

    private float survivalTime;          //생존시간
    private bool isGameover;            //게임종료 상태여부 
 

    void Start()  // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {
        //초깃값 설정
        survivalTime = 0;                //생존시간 0으로 초기 설정
        isGameover = false;             //게임종료 아닌 상태로 설정
        
    }

 
    void Update()  // (5) - (script 활성화시) 매 프레임마다 아래 함수 호출(컴퓨터의 성능, 리소스·로직의 복잡성 등 불규칙 호출), 화면 rendering 주기(그래픽 카드 성능)와 일치하지 않을 수 있음. 가령 60FPS이면 1/60초마다 1프레임, 1/60초마다 아래 함수 호출, 1초에 60번 아래 함수 반복
    {

        // 게임 종료시 장면 불러오기, timeText 표시
        if (!isGameover)                                    //게임종료 상태가 아닐 경우에
        {
            survivalTime += Time.deltaTime;                  //생존시간 매 프레임마다 누적
            survivalTimeText.text = "시간 : " + (int)survivalTime + "초";   //해당 변수의 text 영역에 '시간 : ~초' 형식으로 표시
        }
        else                                                //게임종료 상태일 경우 
        {
            //게임 재시작
            if (Input.GetKeyDown(KeyCode.R))                //R키 입력시
            {
                SceneManager.LoadScene(0);                  //Scenes In Build 목록에 등록된 Main 장면으로 불러오기
                //SceneManager.LoadScene(Scenes/Main);  
            }
        }
    }


    public void EndGame() //게임종료 함수       (외부에서 접근 가능)
    {

        //게임 종료시 (현 생존 시간과 비교 후) 최고 기록 표시
        isGameover = true;                                  //게임종료 상태이면 (surviveTime 비갱신,비누적)
        gameoverText.SetActive(true);                       //gameoverText를 활성화

        float bestTime = PlayerPrefs.GetFloat("BestTime");  //PlayerPrefs에 설정된 BestTime에 저장된 기록(최고기록) 가져오기

        if (survivalTime > bestTime)                         //생존시간 > 최고기록이면
        {
            bestTime = survivalTime;                         //최고기록에 생존시간 값을 저장
            PlayerPrefs.SetFloat("BestTime",bestTime);      //PlayerPrefs의 BestTime에 수정된 bestTime 기록 값을 저장하기
            bestRecordText.text = "최고 기록 : " + (int)bestTime + "초"; //recordText의 text 란에 'Best Time : bestTime(int형식으로 수정) 초'로 덮어씌우기
        }
    }





 }
