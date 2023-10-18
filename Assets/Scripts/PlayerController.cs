using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction toggleSwordAction;

    private CharacterController controller;
    private Animator animator; // アニメーターコンポーネントを保持

    [SerializeField] private float moveSpeed = 5.0f;
    private Vector3 moveDirection;

    public Transform rightHandBone; // 右手ボーンを指定
    public GameObject swordToFollow; // 追従する剣のオブジェクトをインスペクターで指定

    private bool swordDrawn = false; // 剣の状態を保持するフラグ
    private bool isFollowing = false;

    private void Awake()
    {
        moveAction = new InputAction("Move");
        toggleSwordAction = new InputAction("ToggleSword");

        // アクションにバインディングを追加
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
        animator = GetComponent<Animator>(); // アニメーターコンポーネントを取得
    }

    private void Update()
    {
            // 入力ベクトルを取得
            Vector2 inputVector = moveAction.ReadValue<Vector2>();

            // 移動ベクトルを計算
            moveDirection = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

            // キャラクターの向きを変更
            if (moveDirection != Vector3.zero)
            {
               transform.rotation = Quaternion.LookRotation(moveDirection);
            }

            // キャラクターを移動させる
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);

            // アニメーションを制御
            float moveMagnitude = inputVector.magnitude;
            moveMagnitude = Mathf.Clamp01(moveMagnitude);
            animator.SetFloat("PlayerSpeed", moveMagnitude);

        if (toggleSwordAction.triggered)
        {
            swordDrawn = !swordDrawn; // 状態をトグル
            if (swordDrawn)
            {
                animator.Play("Sword_Draw");

                // 剣を追従するコードを追加
                StartFollowingSword();
                return;
            }
            else
            {
                animator.Play("Sheach_Sword");

                // 剣の追従を停止
                isFollowing = false;
                return;
            }
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

    public void StartFollowingSword()
    {
        if (swordToFollow != null && rightHandBone != null)
        {
            isFollowing = true;
        }
    }
}