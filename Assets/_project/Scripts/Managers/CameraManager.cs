using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    enum VirtualCameras
    {
        NoCamera = -1,
        CockpitCamera = 0,
        FollowCamera
    }

    [SerializeField]
    List<GameObject> _virtualCameras;

    private void Start()
    {
        SetActiveCamera(VirtualCameras.CockpitCamera);
    }

    private void Update()
    {
        SetActiveCamera(CameraKeyPressed);
    }

    VirtualCameras CameraKeyPressed
    {
        get
        {
            for (int i = 0; i < _virtualCameras.Count; ++i)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    return (VirtualCameras)i;
                }
            }
            return VirtualCameras.NoCamera;
        }
    }

    private void SetActiveCamera(VirtualCameras activeCamera)
    {
        if (activeCamera == VirtualCameras.NoCamera)
        {
            Debug.Log("No camera");
            return;

        }


        foreach (GameObject camera in _virtualCameras)
        {

            camera.SetActive(camera.tag.Equals(activeCamera.ToString()));
            Debug.Log($"{activeCamera.ToString()}");

        }
    }
}





