using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medical_Kit_Controller : MonoBehaviour
{
    public bool followMe = false;
    public bool curando = false;

    bool PlayerOrder;
    float stateNPCSalud;
    float curacion;

    private void OnTriggerStay(Collider other)
    {
        if (other != null)
        {

            if (other.CompareTag("NPC"))
            {

                NPC_Controller npcCotroller = other.GetComponent<NPC_Controller>();

                if (npcCotroller != null)
                {
                    npcCotroller.order = PlayerOrder;

                    // Salud actual del personaje
                    stateNPCSalud = npcCotroller.NPCSalud;
                    // Curando al personaje
                    npcCotroller.NPCSalud = curacion;
                }
            }
        }
    }

    public void medic()
    {
        FollowMe();
        Healing();
    }

    void Healing()
    {
        if (Input.GetKey(KeyCode.Mouse0) && stateNPCSalud >= 0 && stateNPCSalud <= 100)
        {
            Debug.Log("Player: Te estoy curando");
            curacion += 20 * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && stateNPCSalud >= 100)
        {
            Debug.Log("Player: He dejado de curar");
        }
        else if (Input.GetKey(KeyCode.Mouse0) && stateNPCSalud <= 100)
        {
            Debug.Log("Player: Ya estas curado");
        }

    }

    void FollowMe()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerOrder = !PlayerOrder;
            Debug.Log("Orden enviada: " + PlayerOrder);
        }
    }
}
