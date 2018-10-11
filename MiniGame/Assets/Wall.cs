using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        // 씬 안의 오브젝트 개수 제한하도록
        // 일정 시간이 지나면 씬에서 게임 오브젝트가 제거되도록 함
       
        Destroy(gameObject, 4f);   // 5초 마다 제거

	}

    // Update: 화면을 구성할 때 마다 지속적으로 호출
    // 플레이어와 벽의 이동 -> 게임에서 항상 실행되어야 하므로 Update 함수 내에서 수정
    // Update is called once per frame
    void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);
	}
}
