using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    [SerializeField]
    ShipMovementInput _movementInput;

    [SerializeField]
    [Range(1000f, 30000f)]
    float _thrustForce = 7500f, _pitchForce = 20000f, _rollForce = 5000f, _yawForce = 5000f;

    Rigidbody _rigidbody;

    [SerializeField]
    float _thrustAmount, _pitchAmount, _rollAmount, _yawAmount;

    IMovementControls ControlInput => _movementInput.MovementControls;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _thrustAmount = ControlInput.ThrustAmount;
        _rollAmount = ControlInput.RollAmount;
        _yawAmount = ControlInput.YawAmount;
        _pitchAmount = ControlInput.PitchAmount;
    }

    private void FixedUpdate()
    {
        // pitch 
        if(!Mathf.Approximately(0f, _pitchAmount))
        {
            _rigidbody.AddTorque(transform.right * (_pitchForce * _pitchAmount * Time.fixedDeltaTime));
        }

        // roll
        if (!Mathf.Approximately(0f, _rollAmount))
        {
            _rigidbody.AddTorque(transform.forward * (_rollForce * _rollAmount * Time.fixedDeltaTime));
        }

        // yaw
        if (!Mathf.Approximately(0f, _yawAmount))
        {
            _rigidbody.AddTorque(transform.up * (_yawForce * _yawAmount * Time.fixedDeltaTime));
        }

        // pitch 
        if (!Mathf.Approximately(0f, _thrustAmount))
        {
            _rigidbody.AddForce(transform.forward * (_thrustForce + _thrustAmount * Time.fixedDeltaTime));
        }
    }
}



