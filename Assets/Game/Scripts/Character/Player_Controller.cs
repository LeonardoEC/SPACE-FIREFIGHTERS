using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/// <summary>
/// Este script sirve para que el personaje pueda usar las herramientas
/// Va al cuerpo de personaje
/// </summary>

public class Player_Controller : MonoBehaviour
{


    private Player_Tool_Detector Player_Tool_Detector;
    private PlayerInfo playerInfo;
    string rol;

    public int player_Life = 100;
    

    private void OnEnable()
    {
        if (Player_Tool_Detector == null)
        {
            Player_Tool_Detector = GetComponentInChildren<Player_Tool_Detector>();
            rol = Player_Tool_Detector.rol;
        }
        playerInfo = GetComponent<PlayerInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        Player_Tool_Detector.UseTool();
        PlayerlifeController();

        Debug.Log("Player Salud: " + player_Life);
    }

    void PlayerlifeController()
    {
        if(playerInfo != null)
        {
            playerInfo._lifePlayer = player_Life;
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("WallFire"))
        {
            player_Life -= 2;
        }

        if (collision.gameObject.CompareTag("Fire_Balls"))
        {
            player_Life -= 1;
        }
    }


}
