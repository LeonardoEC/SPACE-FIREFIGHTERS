using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe_Area : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            NPC_Controller npc_Controller = other.GetComponent<NPC_Controller>();
            npc_Controller.isSafe = true;
            npc_Controller.order = false;
            Debug.Log("NPC: la contraseña del primer servidor es: " + npc_Controller.contraseña);
        }


    }
}
