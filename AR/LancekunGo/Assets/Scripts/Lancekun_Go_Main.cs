using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kudan.AR;

public class Lancekun_Go_Main : MonoBehaviour {

    public KudanTracker kudan_tracker_;

	IEnumerable Start()
    {
        // 1초간 대기 시킴
        yield return new WaitForSeconds(1.0f);

        // 바닥의 위치 값과 바닥의 회전 값을 저장할 변수 선언. Quaternion(사원수)
        Vector3 floor_position;
        Quaternion floor_orientation;

        // 현재 바닥의 위치와 방위 값을 얻어옴
        kudan_tracker_.FloorPlaceGetPose(out floor_position, out floor_orientation);

        // 얻어온 값을 이용하여 트래킹 시작함
        kudan_tracker_.ArbiTrackStart(floor_position, floor_orientation);
    }
}
