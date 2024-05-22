using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Transform playerHead; // �÷��̾� �Ӹ��� Transform
    private Light flashlight; // ������ ������ �� Light ������Ʈ

    void Start()
    {
        // �÷��̾� �Ӹ��� �ڽ� ������Ʈ �߿��� Light ������Ʈ�� ã���ϴ�.
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
            // �������� ��ġ�� �÷��̾� �Ӹ� ��ġ�� ����
            flashlight.transform.position = playerHead.position;

            // �������� ������ �÷��̾ ���� �������� ����
            flashlight.transform.rotation = playerHead.rotation;
        }
    }
}
