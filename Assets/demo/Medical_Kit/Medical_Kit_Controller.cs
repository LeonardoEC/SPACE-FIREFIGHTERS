using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medical_Kit_Controller : MonoBehaviour
{
    private NPC_Controller currentNPC; // referencia clara al NPC
    public bool playerOrder;
    private float curacion;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNPC = other.GetComponent<NPC_Controller>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC") && currentNPC == other.GetComponent<NPC_Controller>())
        {
            currentNPC = null; // salgo del rango, dejo de curar
        }
    }



    public void medic()
    {
        FollowMe();
        Healing();
    }

    void Healing()
    {
        if (currentNPC == null) return;

        if (Input.GetKey(KeyCode.Mouse0) && currentNPC.NPCSalud < 100)
        {
            Debug.Log("Player: Te estoy curando");
            curacion = 20 * Time.deltaTime;
            currentNPC.NPCSalud += curacion; // sumo salud
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("Player: He dejado de curar");
        }
    }

    void FollowMe()
    {
        if (currentNPC == null) return;

        // Solo puede dar la orden si está curado
        if (Input.GetKeyDown(KeyCode.F) && currentNPC.NPCSalud >= 75 && !currentNPC.isSafe)
        {
            playerOrder = !playerOrder; // toggle
            currentNPC.order = playerOrder;

            if (playerOrder)
                Debug.Log("Player: Sígueme");
            else
                Debug.Log("Player: Quédate");
        }
    }

    public void NotifyNPCSafe()
    {
        playerOrder = false;
        //Debug.Log("Player: El NPC ya está seguro, orden cancelada");
        //Debug.Log("Tienes 100p");
    }


}
