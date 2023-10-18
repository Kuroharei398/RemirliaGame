using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBone : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform rightHandBone; // �E��{�[�����w��
    public GameObject swordToFollow; // �Ǐ]���錕�̃I�u�W�F�N�g���C���X�y�N�^�[�Ŏw��

    private bool isFollowing = false;

    private void Start()
    {
        // �C�x���g�̌��o��ݒ�
        AnimationClip animationClip = GetComponent<Animation>().GetClip("Sword_Draw");
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = "StartFollowingSword"; // �֐����ƈ�v���镶����
        animationClip.AddEvent(animationEvent);
    }
    public void StartFollowingSword()
    {
        if (swordToFollow != null && rightHandBone != null)
        {
            isFollowing = true;
        }
    }

    void LateUpdate()
    {
        if (isFollowing)
        {
            // ���̈ʒu�Ɖ�]���X�V
            swordToFollow.transform.position = rightHandBone.position;
            swordToFollow.transform.rotation = rightHandBone.rotation;
        }
    }
}
