using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _distanceFromTarget = 15f;

    private float sensitivity = 1000f;

    private float _yaw = 0f;
    private float _pitch = 0f;

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        
        Quaternion yawRotation = Quaternion.Euler(_pitch , _yaw , 0f);

        RotateCamera(yawRotation);
    }

    public void HandleInput()
    {
        Vector2 input_delta = Vector2.zero;
        
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            input_delta = touch.deltaPosition;
        }
        else if (Input.GetMouseButton(0))
        {
            input_delta = new Vector2(Input.GetAxis("Mouse X") , Input.GetAxis("Mouse Y"));
        }

        _yaw += input_delta.x * sensitivity * Time.deltaTime;
        _pitch -= input_delta.y * sensitivity * Time.deltaTime;
    }

    void RotateCamera(Quaternion rotation)
    {
        Vector3 poistion_offset = rotation * new Vector3(0,0, -_distanceFromTarget);
        transform.position = _target.position + poistion_offset;
        Vector3 newPosition = transform.position;
        newPosition.y = _target.position.y + 5;
        transform.position = newPosition;
        transform.rotation = rotation;
    }

}