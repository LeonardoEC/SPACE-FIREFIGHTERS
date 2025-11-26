using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script va al cuerpo del personaje
/// Controla los movimientos del personaje
/// </summary>

public class Player_Movement : MonoBehaviour
{

    /* ------------------------ Variables ----------------------- */
    // Velocidad de movimiento del jugador
    public float playerSpeed = 10f;
    public float playerJumFoces = 15f;
    Rigidbody playerRigidBody;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    /* ------------------------ Tiempo de ejecusion ----------------------- */
    void Update()
    {
        PlayerWalkin();
        PlayerSprint();
        PlayerJum();
    }

    /* ------------------------ Movimiento por Caminar ----------------------- */
    // Metodo para el movimiento del jugador por transform.Translate
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

    private void PlayerJum()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(Vector3.up * playerJumFoces, ForceMode.Impulse); 
        }
    }


}
