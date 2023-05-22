using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    [Range(5000f, 25000f)]
    float _launchForce = 10000f;

    Rigidbody _rigidbody;
    float _duration;

    [SerializeField]
    [Range(2f, 10f)]
    float _range = 5f;

    bool OutOfFuel
    {
        get
        {
            _duration = Time.deltaTime;
            return _duration <= 0f;
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.AddForce(_launchForce * transform.forward);
        _duration = _range;
    }

    private void Update()
    {
        if (OutOfFuel)
        {
            DestroyObject(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Projectile collided with {collision.collider.name}");
    }

}
