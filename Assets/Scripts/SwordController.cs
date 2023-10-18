using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject sheath; // 鞘のゲームオブジェクト
    private Animator animator;
    public GameObject swordObject;

    // 剣を鞘から取り出すアクション

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void DrawSword()
    {
        animator.Play("Sword_Draw");
        

        // アニメーションのブレンドモードを「Additive」に設定する
        //animator.SetFloat("BlendMode", 1);

        Debug.Log("DrawSword アクションがトリガーされました");
        // 剣を表示
        //gameObject.SetActive(true);
        //animator.SetBool("isSheathed", false);


    }

    // 剣を鞘に収納するアクション
    public void SheathSword()
    {
        animator.Play("Sheach_Sword");
        //animator.SetTrigger("Sheath_Sword");

        // アニメーションのブレンドモードを「Additive」に設定する
        //animator.SetFloat("BlendMode", 1);

        Debug.Log("SheathSword アクションがトリガーされました");
        // 剣を非表示
        //gameObject.SetActive(false);
        //animator.SetBool("isSheathed", true);

        
    }

    // 剣の攻撃アクション
    /*public void Attack()
    {
        if (!isSheathed)
        {
            // 剣の攻撃アニメーションを再生する（アニメーションの名前や方法はプロジェクトに応じて調整）
            // 例: GetComponent<Animator>().SetTrigger("Attack");

            // 攻撃の処理をここに追加
        }
    }*/
}
