using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackingObject : MonoBehaviour, ITrackableEventHandler {
    public TextMesh obj_text_mesh_;

    public string name_;    // 이름
    public int atk_;    // 공격력
    public int def_;    // 방어력
    public int hp_; // 체력

    //이벤트 처리를 위한 ITrackableEventHandler
    private TrackableBehaviour mTrackableBehaviour;
    public bool is_detected_ = false;
    public Animation obj_animation_;

    // Use this for initialization
    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
            // 상태가 변하는 것에 대해 인지
        }

        obj_text_mesh_.text = name + "\nHP: " + hp_;
        // 처음 설정된 이름과 hp를 text로 지정
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED)
        { // 새로운 상태가 DETECTED 또는 TRAKED 되면 is_detected를 true로 아니면 false로 하여 현재의 트래킹 상태를 알 수 있도록 함
            is_detected_ = true;
        }
        else
        {
            is_detected_ = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
