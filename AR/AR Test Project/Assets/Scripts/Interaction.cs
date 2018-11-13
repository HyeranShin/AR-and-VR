using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour
{
    // defaultColor와 selectedColor 사이의 변환이 이루어짐
    public static Color defaultColor;
    public static Color selectedColor;
    public static Material mat;

    void Start()
    {

        mat = GetComponent<Renderer>().material;

        // 쉐이더(그래픽 카드가 실행하는 부분으로 머터리얼은 쉐이더를 참조하여 텍스처, 색상 등을 설정함) 설정 부분
        mat.SetFloat("_Mode", 2);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;

        // 색상 선언 부분
        defaultColor = new Color32(255, 255, 255, 255);
        selectedColor = new Color32(255, 0, 0, 255);

        mat.color = defaultColor;
    }

    // touch 상태에 따라 색상 전환
    void touchBegan()
    {
        mat.color = selectedColor;
    }

    void touchEnded()
    {
        mat.color = defaultColor;
    }

    void touchStay()
    {
        mat.color = selectedColor;
    }

    void touchExit()
    {
        mat.color = defaultColor;
    }
}