using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player; // �v���C���[�L�����N�^�[��Transform
    public float sensitivity = 1.0f; // ���̃��b�V���̓����̊��x

    private CharacterController playerController; // �v���C���[�L�����N�^�[��CharacterController
    private Vector3 previousPlayerPosition; // �O�̃t���[���ł̃v���C���[�ʒu

    void Start()
    {
        playerController = player.GetComponent<CharacterController>();
        previousPlayerPosition = player.position;
    }

    void Update()
    {
        Vector3 playerDeltaPosition = player.position - previousPlayerPosition;
        Vector3 hairMovement = playerDeltaPosition * sensitivity;
        transform.position += hairMovement;

        previousPlayerPosition = player.position;
        Debug.Log("�X�V������");
    }
}
