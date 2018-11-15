using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float degreePerSeconds;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float speed = degreePerSeconds * Time.deltaTime;
        transform.Rotate(Vector3.up * speed);
	}
}
