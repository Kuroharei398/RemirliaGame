using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction toggleSwordAction;

    private CharacterController controller;
    private Animator animator; // �A�j���[�^�[�R���|�[�l���g��ێ�

    [SerializeField] private float moveSpeed = 5.0f;
    private Vector3 moveDirection;

    public Transform rightHandBone; // �E��{�[�����w��
    public GameObject swordToFollow; // �Ǐ]���錕�̃I�u�W�F�N�g���C���X�y�N�^�[�Ŏw��

    private bool swordDrawn = false; // ���̏�Ԃ�ێ�����t���O
    private bool isFollowing = false;

    private void Awake()
    {
        moveAction = new InputAction("Move");
        toggleSwordAction = new InputAction("ToggleSword");

        // �A�N�V�����Ƀo�C���f�B���O��ǉ�
        moveAction.AddBinding("<Gamepad>/leftStick");
        toggleSwordAction.AddBinding("<Gamepad>/buttonWest");
    }

    private void OnEnable()
    {
        moveAction.Enable();
        toggleSwordAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        toggleSwordAction.Disable();
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // �A�j���[�^�[�R���|�[�l���g���擾
    }

    private void Update()
    {
            // ���̓x�N�g�����擾
            Vector2 inputVector = moveAction.ReadValue<Vector2>();

            // �ړ��x�N�g�����v�Z
            moveDirection = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

            // �L�����N�^�[�̌�����ύX
            if (moveDirection != Vector3.zero)
            {
               transform.rotation = Quaternion.LookRotation(moveDirection);
            }

            // �L�����N�^�[���ړ�������
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);

            // �A�j���[�V�����𐧌�
            float moveMagnitude = inputVector.magnitude;
            moveMagnitude = Mathf.Clamp01(moveMagnitude);
            animator.SetFloat("PlayerSpeed", moveMagnitude);

        if (toggleSwordAction.triggered)
        {
            swordDrawn = !swordDrawn; // ��Ԃ��g�O��
            if (swordDrawn)
            {
                animator.Play("Sword_Draw");

                // ����Ǐ]����R�[�h��ǉ�
                StartFollowingSword();
                return;
            }
            else
            {
                animator.Play("Sheach_Sword");

                // ���̒Ǐ]���~
                isFollowing = false;
                return;
            }
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

    public void StartFollowingSword()
    {
        if (swordToFollow != null && rightHandBone != null)
        {
            isFollowing = true;
        }
    }
}