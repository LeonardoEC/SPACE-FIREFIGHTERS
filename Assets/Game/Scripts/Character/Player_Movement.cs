using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script va al cuerpo del personaje
/// Controla los movimientos del personaje
/// </summary>

public class Player_Movement : MonoBehaviour
{
    // consumir vida

    /* ------------------------ Variables ----------------------- */
    // Velocidad de movimiento del jugador
    public float playerSpeed = 10f;
    float playerDirectionHorizontal;
    float playerDirectionVertical;

    private bool isJumping = false;
    public bool inAir = false;
    public bool isPlayerGrounded = false;
    float playerJumpForece = 6f;

    /* Obsoleto
    private bool isAscending = false;
    private float jumpHeight = 2f;
    private float jumpSpeed = 5f;
    private float startY;
    */

    Rigidbody playerRigidBody;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    /* ------------------------ Tiempo de ejecusion ----------------------- */
    void Update()
    {
        HandleInput();
        PlayerSprint();
    }

    private void FixedUpdate()
    {
        PlayerWalkin();
        PlayerJump();
    }

    public void HandleInput()
    {
        playerDirectionHorizontal = Input.GetAxisRaw("Horizontal");
        playerDirectionVertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && inAir == false)
        {
            isJumping = true;
        }
    }


    /* ------------------------ Movimiento por Caminar ----------------------- */
    // Metodo para el movimiento del jugador por transform.Translate
    /* Obsoleto
    private void PlayerWalkin()
    {
        // Movimiento del jugador con las teclas WASD o las flechas del teclado
        Vector3 playerDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        // Normalizar la direccion del jugador para evitar que se mueva mas rapido en diagonal
        if (playerDirection.magnitude > 1f)
        {
            playerDirection.Normalize();
        }
        // Mover al jugador
        transform.Translate(playerDirection * playerSpeed * Time.deltaTime);
    }
    */

    public void PlayerWalkin()
    {

        // Dirección relativa al transform del jugador
        Vector3 moveDirection = (transform.forward * playerDirectionVertical + transform.right * playerDirectionHorizontal).normalized;

        // Aplicar velocidad manteniendo la gravedad
        Vector3 velocity = moveDirection * playerSpeed;
        velocity.y = playerRigidBody.velocity.y; // conservar componente vertical

        playerRigidBody.velocity = velocity;
    }

    /* ------------------------ Movimiento por Correr ----------------------- */

    // Metodo para que el juegador pueda correr al presionar la tecla Shift
    private void PlayerSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed = 20f;
        }
        else
        {
            playerSpeed = 10f;
        }
    }

    /* ------------------------ Movimiento por Saltar ----------------------- */


    public void PlayerJump()
    {

        if (isPlayerGrounded && isJumping)
        {
            playerRigidBody.AddForce(Vector3.up * playerJumpForece, ForceMode.Impulse);

            isJumping = false;
        }
    }



    /* obsoleto
    private void PlayerJum()
    {
        // Iniciar salto
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            isAscending = true;
            startY = transform.position.y;
        }

        if (!isJumping) return;

        if (isAscending)
        {
            float newY = transform.position.y + (jumpSpeed * Time.deltaTime);

            if (newY < startY + jumpHeight)
            {
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, startY + jumpHeight, transform.position.z);
                isAscending = false;
            }
        }
        else
        {
            float newY = transform.position.y - (jumpSpeed * Time.deltaTime);
            newY = Mathf.Max(newY, startY); // evita pasar el suelo

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            if (newY <= startY)
            {
                isJumping = false;
                isAscending = false;
            }
        }
    }
    */


}
