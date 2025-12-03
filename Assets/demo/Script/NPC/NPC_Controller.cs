using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float stopDistance = 2f;
    public float NPCSalud = 0f;

    public string contraseña;
    public bool order = false;
    public bool isSafe = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stopDistance;
    }

    void Update()
    {
        NPCState();
        FollowPlayer();
        onSafe();
    }

    void FollowPlayer()
    {
        if (target == null) return;

        if (order && NPCSalud < 100)
        {
            Debug.Log("No puedo seguirte, estoy herido");
        }
        else if (order && NPCSalud >= 100 && !isSafe)
        {
            agent.SetDestination(target.position);
            transform.LookAt(target.position);
        }
        else if (isSafe)
        {
            order = false; // asegura que no siga más
            target = null;
        }
    }

    void NPCState()
    {
        if (NPCSalud < 100f)
        {
            // Enviar aviso por UI que el NPC esta herido
        }
        else
        {
            NPCSalud = 100;
        }
    }

    void onSafe()
    {
        if (isSafe)
        {

            Medical_Kit_Controller mk = FindObjectOfType<Medical_Kit_Controller>();
            if (mk != null)
            {
                mk.NotifyNPCSafe();
            }
        }
    }


}
