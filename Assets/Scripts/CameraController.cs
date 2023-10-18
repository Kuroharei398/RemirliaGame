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
        // Input Actionsアセットからアクションを取得
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
        // シーン内のオブジェクトからCinemachineFreeLookコンポーネントにアクセス
        CinemachineFreeLook freeLook = FindObjectOfType<CinemachineFreeLook>();

        if (freeLook != null)
        {
            // CinemachineFreeLookコンポーネントが見つかった場合の処理
            freeLookCamera = freeLook;
        }
        else
        {
            // CinemachineFreeLookコンポーネントが見つからなかった場合の処理
            Debug.LogError("CinemachineFreeLookコンポーネントが見つかりません。");
        }

    }

    void Update()
    {
        if (freeLookCamera != null)
        {
            // ゲームパッドの右スティック入力を取得
            Vector2 rotationInput = cameraRotationAction.ReadValue<Vector2>();

            // カメラの回転を制御
            freeLookCamera.m_XAxis.m_InputAxisValue = rotationInput.x;
            freeLookCamera.m_YAxis.m_InputAxisValue = rotationInput.y;
        }
    }
}