using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DesktopMovementControls : MovementControlsBase
{
    [SerializeField]
    float _deadZoneRadius = 0.1f;
    Vector2 ScreenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    private float _rollAmount = 0f;

    public override float YawAmount
    {
        get
        {
            Vector3 mousePosition = Input.mousePosition;
            float yaw = (mousePosition.x - ScreenCenter.x)/ScreenCenter.x;
            return Mathf.Abs(yaw) > _deadZoneRadius ? yaw:0f;
        }
    }
    public override float PitchAmount
    {
        get
        {
            Vector3 mousePosition = Input.mousePosition;
            float pitch = (mousePosition.y - ScreenCenter.y) / ScreenCenter.x;
            return Mathf.Abs(pitch) > _deadZoneRadius ? pitch * -1 : 0f;
        }
    }

    public override float RollAmount
    {
        get
        {
            float roll;
            if(Input.GetKey(KeyCode.Q))
            {
                roll =  1f;
            }
            else
            {
                roll = Input.GetKey(KeyCode.E) ? -1f : 0f;
            }
            return _rollAmount = Mathf.Lerp(_rollAmount, roll, Time.deltaTime * 3f);
        }
    }

    public override float ThrustAmount => Input.GetAxis("Vertical");
}
