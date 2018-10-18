using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public GameObject target;   // Public 변수는 inspector에서 값을 지정하거나 수정할 수 있음
    NavMeshAgent agent;
    Animator animator;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.destination = target.transform.position;
        animator.SetFloat("speed", agent.velocity.magnitude);
    }
}
