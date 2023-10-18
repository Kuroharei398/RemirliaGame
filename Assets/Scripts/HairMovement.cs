using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player; // プレイヤーキャラクターのTransform
    public float sensitivity = 1.0f; // 髪のメッシュの動きの感度

    private CharacterController playerController; // プレイヤーキャラクターのCharacterController
    private Vector3 previousPlayerPosition; // 前のフレームでのプレイヤー位置

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
        Debug.Log("更新したよ");
    }
}
