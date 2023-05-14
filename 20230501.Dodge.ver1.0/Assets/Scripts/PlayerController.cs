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
        // 1) Input.GetKey()는 키 입력값을 하나하나 바꿔서 수정해야하기에 자주 사용 X
        // 2) rigidbody변수.AddForce() : 물리엔진에 관성 적용. 방향 전환 늦어 자주 사용X
        //
        if (Input.GetKey(KeyCode.UpArrow) == true)       //↑키를 누르는 동안(273) true, 그 외엔 false 반환
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
        // 1) rigidbody변수.velocity() : 물리엔진의 현재 속도 (관성 무시, 이전 속도를 지우고 새 속도로 즉시 변경)
        //
        float xAxis = Input.GetAxis("Horizontal");     // x축 방향 =  -1 ~ 1  
        float zAxis = Input.GetAxis("Vertical");       // z축 방향 =  -1 ~ 1   

        float xSpeed = xAxis * speed;                  // x축 이동속도 = x축 방향 * 속력
        float zSpeed = zAxis * speed;                  // z축 이동속도 = z축 방향 * 속력 

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed); // newVelocity = Vector3 타입에 (x축 이동속도, 0, z축 이동속도) 저장
        playerRigidbody.velocity = newVelocity;                // 물리엔진의 현재 속도를 newVelocity 값으로 저장

    }



    public void Die()  //사망 함수
    {
        gameObject.SetActive(false);        //이 script가 달린 객체(플레이어)를 비활성화 (inspector에서 네모박스 체크 해제)

        GameManager gameManager = FindObjectOfType<GameManager>();  //Game Manager를 담을 변수 초깃값 설정
        gameManager.EndGame();                                      //Game Manager의 EndGame() 함수 호출

    }
}