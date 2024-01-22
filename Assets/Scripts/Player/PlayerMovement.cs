using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerModelPos;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private Animator animator;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float crouchHeightPos = -0.2481f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Update()
    {
        Jump();
        Crouch();
    }

    #region Jumping
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                animator.SetBool("isJumping", isJumping);
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
                animator.SetBool("isJumping", isJumping);
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
            jumpTimer = 0f;
        }
    }
    #endregion

    #region Crouching

    private void Crouch()
    {
        if(isGrounded && Input.GetButton("Fire3"))
        {
            SetScaleAndPos(crouchHeight, crouchHeightPos);

            if (isJumping)
            {
                SetScaleAndPos(1f, 0f);
            }
        }
        if(Input.GetButtonUp("Fire3"))
        {
            SetScaleAndPos(1f, 0f);
        }
    }

    private void SetScaleAndPos(float scale, float pos)
    {
        playerModelPos.localScale = new Vector3(playerModelPos.localScale.x, scale, playerModelPos.localScale.z);
        playerModelPos.localPosition = new Vector3(playerModelPos.localPosition.x, pos, playerModelPos.localPosition.z);
    }
    #endregion
}
