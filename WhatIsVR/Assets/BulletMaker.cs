using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMaker  : MonoBehaviour {
    public GameObject prefab_bullet_;
    private float spawn_time_ = 0.0f;

    public int max_bullets_count_ = 5;
    public int bullets_count_ = 0;

	// Use this for initialization
	void Start () {
        prefab_bullet_.SetActive(false);

 // '#'이 붙은건 제일 처음 수행되는 코드(전처리기)
#if UNITY_ANDROID
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
#elif UNITY_IOS
        iPhoneSettings.screenCanDarken = false;
#endif
    }
	
	// Update is called once per frame
	void Update () {

        // Spawn Bullets
        spawn_time_ += Time.deltaTime;

        if (spawn_time_ > 1.0f && max_bullets_count_ >= bullets_count_)
        {
            spawn_time_ = 0.0f;
            //Debug.Log("총알 발사~!");
            GameObject obj_bullet = GameObject.Instantiate(prefab_bullet_, this.transform) as GameObject;
            obj_bullet.SetActive(true);
            obj_bullet.transform.localPosition = new Vector3(Random.RandomRange(-2.0f, 2.0f), Random.RandomRange(0.5f, 3.0f), 30.0f);
            bullets_count_++;
        }

        // Move Bullets
        for(int i=0; i<transform.childCount; i++)
        {
            Transform child_bullet = transform.GetChild(i);
            child_bullet.Translate(new Vector3(0, 0, 1));

            if (child_bullet.localPosition.z < -5.0f)
                child_bullet.transform.localPosition = new Vector3(Random.RandomRange(-2.0f, 2.0f), Random.RandomRange(0.5f, 3.0f), 30.0f);
        }
    }
}
