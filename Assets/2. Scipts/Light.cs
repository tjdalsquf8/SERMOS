using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Transform playerHead; // 플레이어 머리의 Transform
    private Light flashlight; // 손전등 역할을 할 Light 컴포넌트

    void Start()
    {
        // 플레이어 머리의 자식 오브젝트 중에서 Light 컴포넌트를 찾습니다.
        flashlight = playerHead.GetComponentInChildren<Light>();

        if (flashlight == null)
        {
            Debug.LogError("Player head has no child with a Light component.");
        }
    }

    void Update()
    {
        if (flashlight != null)
        {
            // 손전등의 위치를 플레이어 머리 위치에 고정
            flashlight.transform.position = playerHead.position;

            // 손전등의 방향을 플레이어가 보는 방향으로 설정
            flashlight.transform.rotation = playerHead.rotation;
        }
    }
}
