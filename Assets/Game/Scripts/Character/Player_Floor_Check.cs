using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Floor_Check : MonoBehaviour
{
    Player_Movement player_Movement;
    private void Awake()
    {
        player_Movement = GetComponentInParent<Player_Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Environment"))
        {
            player_Movement.isPlayerGrounded = true;
            player_Movement.inAir = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            player_Movement.isPlayerGrounded = false;
            player_Movement.inAir = true;
        }
    }
}
