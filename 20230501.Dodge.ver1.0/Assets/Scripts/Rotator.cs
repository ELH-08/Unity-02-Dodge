using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//바닥 회전
public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;           //회전속도 60 설정



    void Start() // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {

    }


    void Update() // (5) - (script 활성화시) 매 프레임마다 아래 함수 호출(컴퓨터의 성능, 리소스·로직의 복잡성 등 불규칙 호출), 화면 rendering 주기(그래픽 카드 성능)와 일치하지 않을 수 있음. 가령 60FPS이면 1/60초마다 1프레임, 1/60초마다 아래 함수 호출, 1초에 60번 아래 함수 반복
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);       // Y축 기준으로 매 프레임당 60  ex)1프레임에 60도 회전, 1초에 360도 회전

    }
}
