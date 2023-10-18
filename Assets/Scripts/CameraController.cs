using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private CinemachineFreeLook freeLookCamera;
    private InputAction cameraRotationAction;

    private void Awake()
    {
        // Input Actions�A�Z�b�g����A�N�V�������擾
        cameraRotationAction = new InputAction("CameraRotation");
        cameraRotationAction.AddBinding("<Gamepad>/rightStick");
        cameraRotationAction.Enable();
    }

    private void OnEnable()
    {
        cameraRotationAction.Enable();
    }

    private void OnDisable()
    {
        cameraRotationAction.Disable();
    }

    void Start()
    {
        // �V�[�����̃I�u�W�F�N�g����CinemachineFreeLook�R���|�[�l���g�ɃA�N�Z�X
        CinemachineFreeLook freeLook = FindObjectOfType<CinemachineFreeLook>();

        if (freeLook != null)
        {
            // CinemachineFreeLook�R���|�[�l���g�����������ꍇ�̏���
            freeLookCamera = freeLook;
        }
        else
        {
            // CinemachineFreeLook�R���|�[�l���g��������Ȃ������ꍇ�̏���
            Debug.LogError("CinemachineFreeLook�R���|�[�l���g��������܂���B");
        }

    }

    void Update()
    {
        if (freeLookCamera != null)
        {
            // �Q�[���p�b�h�̉E�X�e�B�b�N���͂��擾
            Vector2 rotationInput = cameraRotationAction.ReadValue<Vector2>();

            // �J�����̉�]�𐧌�
            freeLookCamera.m_XAxis.m_InputAxisValue = rotationInput.x;
            freeLookCamera.m_YAxis.m_InputAxisValue = rotationInput.y;
        }
    }
}