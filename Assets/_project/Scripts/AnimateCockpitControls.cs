using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCockpitControls : MonoBehaviour
{
    [SerializeField] 
    Transform _joystick;

    [SerializeField]
    Vector3 _joystickRange = Vector3.zero;

    [SerializeField]
    List<Transform> _throttles;

    [SerializeField]
    float _throttleRange = 35f;

    [SerializeField]
    ShipMovementInput _movementInput;

    IMovementControls ControlInput => _movementInput.MovementControls;

    private void Start()
    {
        _movementInput = GameObject.Find("ShipMovementInput").GetComponent<ShipMovementInput>();
    }
    private void Update()
    {
        _joystick.localRotation = Quaternion.Euler(
            ControlInput.PitchAmount * _joystickRange.x,
            ControlInput.YawAmount * _joystickRange.y,
            ControlInput.RollAmount * _joystickRange.z
            );

        Vector3 throttleRorattion = _throttles[0].localRotation.eulerAngles;
        throttleRorattion.x = -ControlInput.ThrustAmount * _throttleRange;

        foreach(Transform throttle in _throttles)
        {
            throttle.localRotation = Quaternion.Euler(throttleRorattion);
        }
    }
}
