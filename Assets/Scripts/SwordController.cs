using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject sheath; // ��̃Q�[���I�u�W�F�N�g
    private Animator animator;
    public GameObject swordObject;

    // �����₩����o���A�N�V����

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void DrawSword()
    {
        animator.Play("Sword_Draw");
        

        // �A�j���[�V�����̃u�����h���[�h���uAdditive�v�ɐݒ肷��
        //animator.SetFloat("BlendMode", 1);

        Debug.Log("DrawSword �A�N�V�������g���K�[����܂���");
        // ����\��
        //gameObject.SetActive(true);
        //animator.SetBool("isSheathed", false);


    }

    // ������Ɏ��[����A�N�V����
    public void SheathSword()
    {
        animator.Play("Sheach_Sword");
        //animator.SetTrigger("Sheath_Sword");

        // �A�j���[�V�����̃u�����h���[�h���uAdditive�v�ɐݒ肷��
        //animator.SetFloat("BlendMode", 1);

        Debug.Log("SheathSword �A�N�V�������g���K�[����܂���");
        // �����\��
        //gameObject.SetActive(false);
        //animator.SetBool("isSheathed", true);

        
    }

    // ���̍U���A�N�V����
    /*public void Attack()
    {
        if (!isSheathed)
        {
            // ���̍U���A�j���[�V�������Đ�����i�A�j���[�V�����̖��O����@�̓v���W�F�N�g�ɉ����Ē����j
            // ��: GetComponent<Animator>().SetTrigger("Attack");

            // �U���̏����������ɒǉ�
        }
    }*/
}
