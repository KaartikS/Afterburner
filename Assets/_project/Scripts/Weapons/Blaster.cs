using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField]
    Projectile _projectilePrefab;

    [SerializeField]
    Transform _muzzle;

    [SerializeField]
    [Range(0f,10f)]
    float _coolDownTime = 0.25f;
    float _coolDown;

    bool CanFire
    {
        get
        {
            _coolDown -= Time.deltaTime;
            return _coolDown <= 0f;
        }
    }

    void Update()
    {
        if(CanFire && Input.GetMouseButton(0))
        {
            FireProjectile();
        }   
    }

    private void FireProjectile()
    {
        _coolDown = _coolDownTime;
        Instantiate(_projectilePrefab, _muzzle.position, transform.rotation);
    }
}
