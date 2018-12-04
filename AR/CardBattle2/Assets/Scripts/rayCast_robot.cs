using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCast_robot : MonoBehaviour {

    Animator anim;

    public int atkPnt;  // 공격력
    public int hltPnt;  // 체력
    float timeElapsed;

	// Use this for initialization
	void Start () {
        anim = transform.GetComponent<Animator>();

        atkPnt = 200;
        hltPnt = 1000;
        timeElapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        // 부딪히는 물체의 정보를 담는 변수 hit

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        // forward라는 방향 변수 선언 및 대입
     
        Debug.DrawRay(transform.position, forward, Color.red);
        // 가상의 RayCast를 테스트 중에 보일 수 있도록 설정

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.Log("hit_robot");
            // 만일 RayCast가 어떤 물체에 맞는다면 hit라고 출력

            anim.SetBool("isHit", true);
            // 충돌이 발생할 경우 parameter 값을 변경

            timeElapsed = timeElapsed + Time.deltaTime; // 초 단위로 지나가는 시간을 체크
            Debug.Log("로봇의 체력: " + hltPnt);
            if (timeElapsed >= 3)    // 3초에 한번씩 공격
            {
                hit.transform.GetComponent<rayCast_robot>().hltPnt =
                    hit.transform.GetComponent<rayCast_robot>().hltPnt - atkPnt;
                //Debug.Log("로봇의 체력: " + hltPnt);
                timeElapsed = 0;
            }
        } 
        else
        {
            anim.SetBool("isHit", false);
        }

        if(hltPnt <= 0)
        {
            anim.SetBool("isDead", true);
        }
    }
}
