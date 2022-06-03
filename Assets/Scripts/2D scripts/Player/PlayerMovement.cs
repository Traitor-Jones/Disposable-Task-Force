using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] public static bool game1_start;
    [SerializeField] public static bool movement;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCD;
    private float horizontalInput;

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        game1_start = false;
        movement = false;
    }

    private void Update()
    {
        if(game1_start && movement){
            horizontalInput = Input.GetAxis("Horizontal");

            //Flip player when moving left-right
            if (horizontalInput > 0.01f){
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (horizontalInput < -0.01f){
                transform.localScale = Vector3.one;
            }

            //Set animator parameters
            anim.SetBool("run", horizontalInput != 0);
            anim.SetBool("grounded", isGrounded());

            //Wall jump
            if (wallJumpCD > 0.2f){
                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

                if (onWall() && !isGrounded()){
                    body.gravityScale = 0;
                    body.velocity = Vector2.zero;
                }
                else{
                    body.gravityScale = 7;
                }

                if (Input.GetKey(KeyCode.Space)){
                    Jump();

                    if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
                    {
                        SoundManager.instance.PlaySound(jumpSound);
                    }
                }
            }
            else{
                wallJumpCD += Time.deltaTime;
            }
        }
    }

    private void Jump(){
        if (isGrounded()){
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded()){
            if (horizontalInput == 0){
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else{
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }

            wallJumpCD = 0;
        }
    }

    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

}

// Referenced Pandemonium - Unity2D Platformer guide on Youtube.
