using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    //public Rigidbody playerRigidbody;     //물리엔진 (public 설정시 inspector 창에서 rigidbody를 끌어서 저장할 수 있음)
    private Rigidbody playerRigidbody;      //물리엔진
    public float speed = 8f;                //이동 속력 변수


    void Start() // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {
        //초깃값 설정
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update() // (5) - (script 활성화시) 매 프레임마다 아래 함수 호출(컴퓨터의 성능, 리소스·로직의 복잡성 등 불규칙 호출), 화면 rendering 주기(그래픽 카드 성능)와 일치하지 않을 수 있음. 가령 60FPS이면 1/60초마다 1프레임, 1/60초마다 아래 함수 감지
    {
        /*
        // 이동함수        
        // 1) Input.GetKey() : 키를 하나하나 바꿔서 수정해야하기에 자주 사용 X
        // 2) Rigidbody의 AddForce() : 누적 힘 추가 -> 방향 전환 늦음
        //
        if (Input.GetKey(KeyCode.UpArrow) == true)       //↑키를 누르는 동안 true, 그 외엔 false 반환
        {
            playerRigidbody.AddForce(0f,0f,speed);       // z축 방향으로 물리력 추가
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)     // ↓키를 누르는 동안 true, 그 외엔 false 반환
        {
            playerRigidbody.AddForce(0f,0f,-speed);      // -z축 방향으로 물리력 추가
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)    // →키를 누르는 동안 true, 그 외엔 false 반환
        {
            playerRigidbody.AddForce(speed, 0f, 0f);     // x축 방향으로 물리력 추가
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)     // ←키를 누르는 동안 true, 그 외엔 false 반환
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);    // -x축 방향으로 물리력 추가
        }
        */


        // 이동함수 
        float xInput = Input.GetAxis("Horizontal");     // x축 값 = 연속 수평 값 저장
        float zInput = Input.GetAxis("Vertical");       // y축 값 = 연속 수직 값 저장

        float xSpeed = xInput * speed;                  // x축 이동 = x축 값 * 속력
        float zSpeed = zInput * speed;                  // y축 이동 = y축 값 * 속력 

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed); // newVelocity에 Vector3 타입의 위 방향 정보 값 저장
        playerRigidbody.velocity = newVelocity;                // 객체(플레이어)의 물리력 속도를 newVelocity 값으로 할당
    
    }



    public void Die()     //캐릭터 사망 함수
    {
 
        gameObject.SetActive(false);        //이 스크립트 객체(플레이어)를 비활성화 (inspector에서 네모박스 체크 해제)

        GameManager gameManager = FindObjectOfType<GameManager>();  //Game Manager를 담을 변수 초깃값 설정
        gameManager.EndGame();                                      //Game Manager의 EndGame() 함수 호출

    }
}