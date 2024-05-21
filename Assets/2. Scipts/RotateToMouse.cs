//마우스로 카메라 이동 코드
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public float rotCamXAxisSpeed = 0;
    public float rotCamYAxisSpeed = 0;

    /*
     y축의 회전방향이 + 일경우 오른쪽으로 회전 > 마우스를 오으로 하면 회전 값 +
     y축의 화전방향이 -일경우 왼쪽 회잔 > 마우스 왼쪽으로 회전
     x축의 회전 방향이 - 일경우 위를 봄 > 마우스 위로 이동값에 -  x 회전 값 -
     x축의 회전 방향이 + 일경우 아래를 봄 > 마우스 아래로 이동값에 +   x 회전 값 +
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
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX); // 위 아래로 볼수 있는 각도 제한

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
