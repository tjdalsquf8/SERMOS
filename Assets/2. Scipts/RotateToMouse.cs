//���콺�� ī�޶� �̵� �ڵ�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public float rotCamXAxisSpeed = 0;
    public float rotCamYAxisSpeed = 0;

    /*
     y���� ȸ�������� + �ϰ�� ���������� ȸ�� > ���콺�� ������ �ϸ� ȸ�� �� +
     y���� ȭ�������� -�ϰ�� ���� ȸ�� > ���콺 �������� ȸ��
     x���� ȸ�� ������ - �ϰ�� ���� �� > ���콺 ���� �̵����� -  x ȸ�� �� -
     x���� ȸ�� ������ + �ϰ�� �Ʒ��� �� > ���콺 �Ʒ��� �̵����� +   x ȸ�� �� +
     */
    public float limitMinX = -80;
    private float limitMaxX = 53;
    private float eulerAngleX;
    private float eulerAngleY;
    // Update is called once per frame
    [SerializeField]
    private Camera mainCamera;
    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleX -= mouseY * rotCamYAxisSpeed;
        eulerAngleY += mouseX * rotCamXAxisSpeed;
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX); // �� �Ʒ��� ���� �ִ� ���� ����

        mainCamera.transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
        this.transform.rotation = Quaternion.Euler(0, eulerAngleY, 0);
    }
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f) { angle += 360.0f; }
        if (angle > 360.0f) { angle -= 360.0f; }

        return Mathf.Clamp(angle, min, max);
    }
}
