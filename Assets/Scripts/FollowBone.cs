using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBone : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform rightHandBone; // 右手ボーンを指定
    public GameObject swordToFollow; // 追従する剣のオブジェクトをインスペクターで指定

    private bool isFollowing = false;

    private void Start()
    {
        // イベントの検出を設定
        AnimationClip animationClip = GetComponent<Animation>().GetClip("Sword_Draw");
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = "StartFollowingSword"; // 関数名と一致する文字列
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
            // 剣の位置と回転を更新
            swordToFollow.transform.position = rightHandBone.position;
            swordToFollow.transform.rotation = rightHandBone.rotation;
        }
    }
}
