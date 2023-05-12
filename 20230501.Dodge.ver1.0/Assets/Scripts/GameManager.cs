using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //UI관련 Library 들여오기
using UnityEngine.SceneManagement;      //SceneManager 관련 Library 들여오기



//게임 UI를 관리
// 1. 게임종료 상태
// 2. 생존 시간 갱신
// 3. UI를 갱신하고 표시 
// 4. 게임 오버시 게임 재시작


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;     //게임종료 글자  
    public Text timeText;               //생존시간 글자 (Text field 영역 내용 수정시 Text type으로 설정해야 함)
    public Text recordText;             //최고기록 글자

    private float surviveTime;          //생존시간
    private bool isGameover;            //게임종료 상태 
 
    void Start()  // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {
        //초깃값
        surviveTime = 0;                //생존시간 0으로 초기 설정
        isGameover = false;             //게임종료 아닌 상태로 설정


        
    }

 
    void Update()  // (5) - (script 활성화시) 매 프레임마다 아래 함수 호출(컴퓨터의 성능, 리소스·로직의 복잡성 등 불규칙 호출), 화면 rendering 주기(그래픽 카드 성능)와 일치하지 않을 수 있음. 가령 60FPS이면 1/60초마다 1프레임, 1/60초마다 아래 함수 호출, 1초에 60번 아래 함수 반복
    {


        //UI 글자 출력, 사망시 씬 전환 
        if (!isGameover)                                    //게임종료 상태가 아닐 경우에
        {
            surviveTime += Time.deltaTime;                  //생존시간 매 프레임마다 누적
            timeText.text = "시간 : " + (int)surviveTime + "초";   //해당 변수의 text 영역에 '시간 : ~초' 형식으로 표시
        }
        else                                                //게임종료 상태일 경우
        {
            if (Input.GetKeyDown(KeyCode.R))                //R키 입력시
            {
                SceneManager.LoadScene("SampleScene");      //File - BuildSetting - Scenes In Build 목록에 등록된 SampleScene 로드
            }
        }
    }


    public void EndGame() //게임종료 함수
    {
        isGameover = true;                                  //게임종료 상태이면
        gameoverText.SetActive(true);                       //gameoverText를 활성화

        float bestTime = PlayerPrefs.GetFloat("BestTime");  //플레이어 설정의 BestTime에 저장된 최고기록 가져오기

        if (surviveTime > bestTime)                         //생존시간 > 최고기록 이면
        {
            bestTime = surviveTime;                         //최고기록에 생존시간 값을 저장
            PlayerPrefs.SetFloat("BestTime",bestTime);      //변경된 최고기록을 저장
            recordText.text = "Best Time:" + (int)bestTime; //recordText의 text요소에 Best Time : bestTime값 을 표시
        }
    }





}
