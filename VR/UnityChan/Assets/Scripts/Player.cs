using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpead = 5f;
    public float rotationSpeed = 360f;

    CharacterController characterController;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>(); // Animator 컴포넌트 가져옴
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // 좌우 방향키와 상향 방향키를 눌렀는지 판별
        if (direction.sqrMagnitude > 0.01f) // 메서드를 조합해 플레이어의 방향 변환
        {
            Vector3 forward = Vector3.Slerp(
                transform.forward,
                direction,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            transform.LookAt(transform.position + forward);
        }
        characterController.Move(direction * moveSpead * Time.deltaTime);
        // Move()를 이용해 이동, 충돌 처리를 할 수 있고 속도 값도 얻을 수 있다.

        animator.SetFloat("speed", characterController.velocity.magnitude);

        if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
        {
            Application.LoadLevel("Win");
        }
    }

    // 게임 오브젝트가 트리거와 충돌할 때 호출
    void OnTriggerEnter(Collider other) // other: Player와 충돌이 난 다른 object
    {

        if (other.tag == "Dot")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            Application.LoadLevel("Lose");
        }
    }

    /*
    
    void onTriggerEnter(Collider other) 
    {
        // Destroy(other.gameObject);  // 없애버린다
        if (other.tag == "Dot")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            Application.LoadLevel("Lose");
        }
    }*/
}