using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirectionX;
    private Vector2 playerDirectionY;
    public static bool ship_move;
    // Start is called before the first frame update
    
    void Awake(){
        ship_move = false;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ship_move){
            float directionX = Input.GetAxisRaw("Horizontal");
            float directionY = Input.GetAxisRaw("Vertical");
            playerDirectionY = new Vector2(0, directionY).normalized;
            playerDirectionX = new Vector2(directionX, 0).normalized;
        }
    }

    void FixedUpdate()
    {
        if(ship_move)
            rb.velocity = new Vector2(playerDirectionX.x * playerSpeed, playerDirectionY.y * playerSpeed);
    }
}
