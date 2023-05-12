using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//rigidbody - gravity false
//collider - isTrigger true

public class Bullet : MonoBehaviour
{

    public float speed = 8f;              //탄알 속력
    private Rigidbody bulletRigidbody;    //탄알 물리엔진


 
    void Start()   // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {
        //탄알 스크립트 활성화시 최초 실행
        bulletRigidbody= GetComponent<Rigidbody>();         //탄알 물리엔진 변수
        bulletRigidbody.velocity = transform.forward*speed; //탄알 물리엔진 현재속도 = 앞 방향 * 속력 으로 저장
        Destroy(gameObject, 3f);                            //3초뒤 이 스크립트가 적용된 게임객체 파괴
    }

   
    void Update()  // (5) - (script 활성화시) 매 프레임마다 아래 함수 호출(컴퓨터의 성능, 리소스·로직의 복잡성 등 불규칙 호출), 화면 rendering 주기(그래픽 카드 성능)와 일치하지 않을 수 있음. 가령 60FPS이면 1/60초마다 1프레임, 1/60초마다 아래 함수 감지
    {
        
    }


    private void OnTriggerEnter(Collider other)      //충돌 감지 함수 - isTrigger
    {
        if (other.tag == "Player")                  //충돌한 객체의 태그가 플레이어면
        {
            PlayerController playerController = other.GetComponent<PlayerController>();  //변수에 충돌한 객체의 PlayerController 컴포넌트(스크립트)를 가져와 저장

            if (playerController != null)           // PlayerController 컴퍼넌트(스크립트)를 가져오는데 성공하면
            {
                playerController.Die();             // PlayerController 스크립트의 Die() 함수 실행
            }
        }




    }


}
