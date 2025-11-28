using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float stopDinstance = 2f;
    public float NPCSalud = 0f;

    public bool order = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stopDinstance;
    }

    // Update is called once per frame
    void Update()
    {
        SiguiendoOrdene();
        NPCState();
    }

    void SiguiendoOrdene()
    {
        FollowPlayer(order);
    }

    void FollowPlayer(bool order)
    {
        if (target != null && order && NPCSalud < 100)
        {

            Debug.Log("No puedo seguirte estoy herido");

        }
        else if (NPCSalud >= 100)
        {
            agent.SetDestination(target.position);
        }
    }

    void NPCState()
    {
        if (NPCSalud < 100f)
        {
            Debug.Log("Estoy herido");
        }
        else
        {
            NPCSalud = 100;
            Debug.Log("Estoy curado");
        }
    }
}
