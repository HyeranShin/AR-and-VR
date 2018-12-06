using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBall : MonoBehaviour
{

    bool is_drag_now_ = false;
    float catch_ball_distance_;
    public float catch_ball_throw_speed_ = 120;
    public float catch_ball_arch_speed_ = 100;
    public float catch_ball_speed_ = 1000;

    //마우스 단추를 누르는 동안을 처리하는 내장 함수. Input.GetMouseButtonDown 함수로 대체 가능
    void OnMouseDown()
    {
        catch_ball_distance_ = Vector3.Distance(transform.position, Camera.main.transform.position);
        is_drag_now_ = true;
    }
    //마우스 클릭이 해제되거나 터치가 떨어지는 것을 인식하여 처리하는 내장 함수.
    void OnMouseUp()
    {
        //중력과 속도를 설정
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().velocity += transform.forward * catch_ball_throw_speed_;
        GetComponent<Rigidbody>().velocity += transform.up * catch_ball_arch_speed_;
        is_drag_now_ = false;
    }

    void Update()
    {
        if (is_drag_now_)
        {
            //카메라로부터 스크린의 점을 통해 레이를 반환. 즉, 마우스 또는 터치하는 위치로부터 카메라를 통해 광선을 쏨.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //광선을 따라 거리 단위로 가리킴. 교차 지점을 알아냄
            Vector3 ray_point = ray.GetPoint(catch_ball_distance_);
            //Vector3.Lerp : 오브젝트의 회전의 회전각을 주는 함수
            transform.position = Vector3.Lerp(transform.position, ray_point, catch_ball_speed_ * Time.deltaTime);
        }
    }
}









