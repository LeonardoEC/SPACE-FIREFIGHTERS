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
    public delegate void ResetPlayer();
    ResetPlayer resetPlayer;

    private Player_Tool_Detector Player_Tool_Detector;

    // public Transform[] starPosition;

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

        // Delegados
        resetPlayer += resetLifePlayer;
        resetPlayer += starPlayerPosition;



    }

    void Update()
    {
        Player_Tool_Detector.UseTool();
        PlayerlifeController();
    }

    void PlayerlifeController()
    {
        if(playerInfo != null)
        {
            playerInfo._lifePlayer = player_Life;
        }
    }

    void resetLifePlayer()
    {
        player_Life = 100;
    }


    void starPlayerPosition()
    {
        if (SpawnPointManager.instance == null)
        {
            Debug.LogWarning("No hay posiciones definidas en starPosition.");
            return;
        }

        switch (playerInfo.rollPlayer)
        {
            case RollDropDown.Bombero:
                transform.position = SpawnPointManager.instance.playerSpawnPoints[0].position;
                break;

            case RollDropDown.Medico:
                transform.position = SpawnPointManager.instance.playerSpawnPoints[1].position;
                break;

            case RollDropDown.Ingeniero:
                transform.position = SpawnPointManager.instance.playerSpawnPoints[2].position;
                break;

        }
    }


    public void ResetPlayerState()
    {
        resetPlayer?.Invoke();
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
