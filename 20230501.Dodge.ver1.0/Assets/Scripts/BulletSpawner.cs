using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;     //탄알 프리팹
    private Transform target;           //조준할 대상 (의 위치)

    private float spawnRate;            //탄알 생성 주기
    public float spawnRateMin = 0.5f;   //새 탄알 생성시 걸리는 최소 시간
    public float spawnRateMax = 3f;     //새 탄알 생성시 걸리는 최대 시간
    private float timeAfterSpawn;       //마지막 탄알생성 후 누적시간 (타이머)

 
    void Start() // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {
        //초깃값 
        timeAfterSpawn = 0;                                      //초깃값 0
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);    //탄알 생성 주기 랜덤으로 설정
        target = FindObjectOfType<PlayerController>().transform; //target = <> 요소(PlayerController script)를 가진 객체의 위치 저장
   
    }

 
    void Update() // (5) - (script 활성화시) 매 프레임마다 아래 함수 호출(컴퓨터의 성능, 리소스·로직의 복잡성 등 불규칙 호출), 화면 rendering 주기(그래픽 카드 성능)와 일치하지 않을 수 있음. 가령 60FPS이면 1/60초마다 1프레임, 1/60초마다 아래 함수 감지
    {

        //총알 스포너(생성기) - 매 프레임마다 총알 생성되는 걸 방지하기 위해 타이머 설정
        timeAfterSpawn += Time.deltaTime;   //timeAfterSpawn에 시간 누적 

        if (timeAfterSpawn >= spawnRate)    //'마지막 탄알생성 후 누적시간 >= spawnRate에서 설정한 최대 시간' 이면
        {
            timeAfterSpawn= 0f;             //timeAfterSpawn = 0으로 리셋

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);  //탄알 복제본을 이 객체(스포너)의 transform.position 위치와 transform.rotation 회전에서 생성
            bullet.transform.LookAt(target);                                                        //탄알 복제본의 위치가 target을 향하도록

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);   //탄알 생성 주기 랜덤으로 설정 - update()에서 매회 반복되기 전 설정
        }
    }
}
