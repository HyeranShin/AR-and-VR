using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tracer : MonoBehaviour
{

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchPrev;
    private RaycastHit hit;


    void Update()
    {

#if UNITY_EDITOR

        // GetMouseButton: 마우스 버튼을 누르는 동안
        // GetMouseButtonDown: 마우스 버튼을 누른 순간
        // GetMouseButtonUp: 마우스 버튼을 떼는 순간
        // 0은 마우스 왼쪽 버튼, 1은 오른쪽 버튼, 2는 가운데 버튼을 의미
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {

            touchPrev = new GameObject[touchList.Count];
            touchList.CopyTo(touchPrev);
            touchList.Clear();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Ray Cast: 3차원 공간에서 어느 점에서 Ray(광선)을 정해진 방향으로 쏴 Ray와 충돌되는 객체를 구하는 방법
            // Physics.Raycast: Raycast를 실행하여 Ray와 객체가 충돌하는지 체크하는 메소드로 충돌 시 true 반환
            if (Physics.Raycast(ray, out hit))
            {

                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);

                if (Input.GetMouseButtonDown(0))
                {
                    recipient.SendMessage("touchBegan", hit.point, SendMessageOptions.DontRequireReceiver);

                }
                if (Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("touchEnded", hit.point, SendMessageOptions.DontRequireReceiver);

                }
                if (Input.GetMouseButton(0))
                {
                    recipient.SendMessage("touchStay", hit.point, SendMessageOptions.DontRequireReceiver);

                }
            }

            foreach (GameObject g in touchPrev)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("touchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }

#endif

        // touch 처리를 위해 touchList를 생성하고 초기화시킴
        if (Input.touchCount > 0)
        {

            touchPrev = new GameObject[touchList.Count];
            touchList.CopyTo(touchPrev);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {

                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                // 마찬가지로 터치 감지를 위해 Raycast 사용
                if (Physics.Raycast(ray, out hit))
                {

                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if (touch.phase == TouchPhase.Began)    // 터치가 시작되었을 때
                    {
                        recipient.SendMessage("touchBegan", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                    if (touch.phase == TouchPhase.Ended)    // 터치된 손가락이 스크린에서 떨어질 때
                    {
                        recipient.SendMessage("touchEnded", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                        // 터치된 손가락이 그 자리에 가만히 있을 때 || 터치된 손가락이 움직일 때
                    {
                        recipient.SendMessage("touchStay", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                    if (touch.phase == TouchPhase.Canceled)     // 핸드폰을 귀에 대거나 tracking을 중지해야 할 때 
                    {
                        recipient.SendMessage("touchExit", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                }
            }

            foreach (GameObject g in touchPrev)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("touchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}