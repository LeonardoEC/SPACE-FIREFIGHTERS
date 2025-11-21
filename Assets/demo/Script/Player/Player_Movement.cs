using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    /* -----------------------Movimiento por Transform------------------------ */
    // Velocidad de movimiento del jugador
    public float playerSpeed = 10f;


    Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalkin();
        PlayerSprint();

    }
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

    // Metodo para que el juegador pueda correr al presionar la tecla Shift
    private void PlayerSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 20f;
        }
        else
        {
            playerSpeed = 10f;
        }
    }

    /* ------------------------ Movimiento por fisica ----------------------- */




}
