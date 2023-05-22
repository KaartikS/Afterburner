using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEngine : MonoBehaviour
{
    [SerializeField]
    GameObject _thruster;
    IMovementControls _shipMovementControls ;
    Rigidbody _rigidbody;
    float _thrustForce;
    float _thrustAmount = 0f;

    private void Update()
    {
        ActivateThrusters();
    }
    private void FixedUpdate()
    {
        if(!ThrustersEnabled) return;
        _rigidbody.AddForce(transform.forward * (_thrustAmount * Time.fixedDeltaTime));    
    }

    void ActivateThrusters()
    {
        _thruster.SetActive(ThrustersEnabled);
        if (!ThrustersEnabled) return;
        _thrustAmount = _thrustForce * _shipMovementControls.ThrustAmount;
    }

    public void Init(IMovementControls movementControls, Rigidbody rigidbody, float thrustForce)
    {
        _shipMovementControls = movementControls;
        _rigidbody = rigidbody;
        _thrustForce = thrustForce;
    }

    bool ThrustersEnabled => !Mathf.Approximately(0f, _shipMovementControls.ThrustAmount);

}
