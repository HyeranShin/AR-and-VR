using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject wallPrefab;
    public float interval;
    public float range = 3.0f;

    // Use this for initialization
    // IEnumerator: 열거자
    IEnumerator Start () {
		while(true)
        {
            transform.position = new Vector3(transform.position.x, Random.Range(-range, range), transform.position.z);
            Instantiate(wallPrefab, transform.position, transform.rotation);
            // interval만큼 기다렸다가 return
            yield return new WaitForSeconds(interval);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
