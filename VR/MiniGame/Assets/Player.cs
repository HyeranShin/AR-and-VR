using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpPower;

	// Use this for initialization
	void Start () {
		
	}
	
    // Update: 화면을 구성할 때 마다 지속적으로 호출
    // 플레이어와 벽의 이동 -> 게임에서 항상 실행되어야 하므로 Update 함수 내에서 수정
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
        }
	}

    // 충돌 처리는 별개이므로 새로운 함수로 처리
    void OnCollisionEnter(Collision other)
    {
        // 씬을 불러오는 함수
        Application.LoadLevel(Application.loadedLevel);
    }
}
