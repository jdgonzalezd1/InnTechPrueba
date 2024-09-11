using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineFirstPersonExt : CinemachineExtension
{
    [SerializeField]
    private float maxAngle = 80f;

    [SerializeField]
    private float horizontalSpeed = 10f;

    [SerializeField]
    private float verticalSpeed = 10f;

    private Vector3 startingRotation;

    protected override void Awake()
    {        
        base.Awake();
        if (startingRotation == null)
        {
            startingRotation = transform.localRotation.eulerAngles;
        }
    }


    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                Vector2 mouseInput = InputManager.Instance.GetMouseDelta();
                startingRotation.x += mouseInput.x * verticalSpeed * Time.deltaTime;
                startingRotation.y += mouseInput.y * horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -maxAngle, maxAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }

}
