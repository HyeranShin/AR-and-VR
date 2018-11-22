using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCast_lancekun : MonoBehaviour {

    //Animator anim;

    // Use this for initialization
    void Start () {
        //anim = transform.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        // 부딪히는 물체의 정보를 담는 변수 hit

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        // forward라는 방향 변수 선언 및 대입

        Debug.DrawRay(transform.position, forward, Color.green);
        // 가상의 RayCast를 테스트 중에 보일 수 있도록 설정

        if(Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.Log("hit_lancekun");
            // 만일 RayCast가 어떤 물체에 맞는다면 hit라고 출력

            //anim.SetBool("isHit", true);
            // 충돌이 발생할 경우 parameter 값을 변경
        }
        else
        {
            //anim.SetBool("isHit", false);
        }
    }
}
