using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _distanceFromTarget = 15f;

    private float sensitivity = 1000f;

    private float _yaw = 0f; //มุมการหมุนกล้อง y
    private float _pitch = 0f; //มุมการหมุนกล้อง x

    // Update is called once per frame
    void Update()
    {
        //จัดการ input
        HandleInput();
        
        //การหมุน
        Quaternion yawRotation = Quaternion.Euler(_pitch , _yaw , 0f);

        // หมุนกล้อง
        RotateCamera(yawRotation);
    }

    public void HandleInput()
    {
        Vector2 input_delta = Vector2.zero;
        
        // เช็คการสัมผัสเมาส์
        if(Input.touchCount > 0)
        {
            // เช็คคลิกซ้ายค้าง
            Touch touch = Input.GetTouch(0);
            input_delta = touch.deltaPosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // ขยับเมาส์
            input_delta = new Vector2(Input.GetAxis("Mouse X") , Input.GetAxis("Mouse Y"));
        }

        // เปลี่ยนค่ามุม x y
        _yaw += input_delta.x * sensitivity * Time.deltaTime;
        _pitch -= input_delta.y * sensitivity * Time.deltaTime;
    }

    void RotateCamera(Quaternion rotation)
    {
        // ส่วนคำนวณตำแหน่งการหมุนของกล้อง

        // ระยะห่างจากลูกบอล
        Vector3 poistion_offset = rotation * new Vector3(0,0, -_distanceFromTarget);
        // ตั้งค่าตำแหน่ง
        transform.position = _target.position + poistion_offset;
        Vector3 newPosition = transform.position;
        // เพิ่มค่า แกน y
        newPosition.y = _target.position.y + 5;
        transform.position = newPosition;
        // ตั้งค่าการหมุน
        transform.rotation = rotation;
    }

}