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
    float _pitchAmount, _rollAmount, _yawAmount = 0f;

    [SerializeField]
    List<ShipEngine> _engines;

    [SerializeField]
    AnimateCockpitControls _cockpitControls;

    IMovementControls ControlInput => _movementInput.MovementControls;

    void Start()
    {
        foreach (var engine in _engines)
        {
            engine.Init(ControlInput, _rigidbody, _thrustForce/_engines.Count);
        }
        _cockpitControls.Init(ControlInput);
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
    }
}



