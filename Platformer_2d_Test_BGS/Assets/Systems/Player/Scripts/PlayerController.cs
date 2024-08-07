using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Animator animator = null;
    [SerializeField] private Rigidbody2D rigidbody = null;
    [SerializeField] private Transform bodyTransform = null;
    [Space]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float circleGroundDetection = 0.2f;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    #endregion

    #region PRIVATE_FIELDS
    private float horizontal = 0f;
    private bool enableMovement = true;

    private Action<ItemConfig> onAddItemInInventory = null;
    #endregion

    #region CONSTANTS
    private const string jumpingTrigger = "Jumping";
    private const string moveTrigger = "Move";
    #endregion

    #region PROPERTIES
    public Action<ItemConfig> OnAddItemInInventory { get => onAddItemInInventory; }
    #endregion

    #region UNITY_METHODS
    private void Update()
    {
        if(!enableMovement)
        {
            return;
        }

        UpdateMovement();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(horizontal, rigidbody.velocity.y);
    }
    #endregion

    #region PUBLIC_METHODS
    public void Initialize(Action<ItemConfig> onAddItemInInventory)
    {
        this.onAddItemInInventory = onAddItemInInventory;
    }

    public void EnableMovement()
    {
        enableMovement = !enableMovement;
    }
    #endregion

    #region PRIVATE_METHODS
    private void UpdateMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * movementSpeed;

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }

        if(IsGrounded())
        {
            animator.SetFloat(moveTrigger, Math.Abs(horizontal));
        }

        Flip();
    }

    private bool IsGrounded()
    {
        bool result = Physics2D.OverlapCircle(transform.position, circleGroundDetection, groundLayer);
        
        animator.SetBool(jumpingTrigger, !result);

        return result;
    }

    private void Flip()
    {
        if(horizontal == 0)
        {
            return;
        }

        if(horizontal < 0)
        {
            bodyTransform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            bodyTransform.rotation = Quaternion.Euler(0,0,0);
        }
    }
    #endregion
}
