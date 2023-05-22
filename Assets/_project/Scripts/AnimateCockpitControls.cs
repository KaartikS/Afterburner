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

    IMovementControls _movementControls;

    private void Start()
    {
        _movementControls = GameObject.Find("ShipMovementInput").GetComponent<IMovementControls>();
    }

    private void Update()
    {
        if (_movementControls == null) return;
        _joystick.localRotation = Quaternion.Euler(
            _movementControls.PitchAmount * _joystickRange.x,
            _movementControls.YawAmount * _joystickRange.y,
            _movementControls.RollAmount * _joystickRange.z
            );

        Vector3 throttleRorattion = _throttles[0].localRotation.eulerAngles;
        throttleRorattion.x = -_movementControls.ThrustAmount * _throttleRange;

        foreach(Transform throttle in _throttles)
        {
            throttle.localRotation = Quaternion.Euler(throttleRorattion);
        }
    }

    public void Init(IMovementControls movementControls)
    {
        _movementControls = movementControls;   
    }
}
