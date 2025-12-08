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

    private Tool_Detector Player_Tool_Detector;

    // public Transform[] starPosition;

    private PlayerInfo playerInfo;
    string rol;

    public int player_Life = 100;
    

    private void OnEnable()
    {
        if (Player_Tool_Detector == null)
        {
            Player_Tool_Detector = GetComponentInChildren<Tool_Detector>();
        }
        playerInfo = GetComponent<PlayerInfo>();


        UIGameOver.Instance.resetAction += resetLifePlayer;
        UIGameOver.Instance.resetAction += starPlayerPosition;


    }

    private void OnDestroy()
    {

        UIGameOver.Instance.resetAction -= resetLifePlayer;
        UIGameOver.Instance.resetAction -= starPlayerPosition;
    }

    private void OnDisable()
    {

        UIGameOver.Instance.resetAction -= resetLifePlayer;
        UIGameOver.Instance.resetAction -= starPlayerPosition;
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






    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("WallFire"))
        {
            player_Life -= 2;

            Debug.Log("Player Salud: "+ player_Life + "muro de fuego");
        }

        if (collision.gameObject.CompareTag("Fire_Balls"))
        {
            player_Life -= 1;
            Debug.Log("Player Salud: " + player_Life + "Bola de fuego");
        }
    }


}
