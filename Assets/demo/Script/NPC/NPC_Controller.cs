using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float stopDistance = 2f;
    // disminuir vida

    public float NPCSalud = 100f;
    float damageRate = 1f;

    public string contraseña;
    public bool order = false;
    public bool isSafe = false;

    public int indexNPC;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stopDistance;
    }

    private void Start()
    {
        StartCoroutine(DamageOverTime());
    }

    void Update()
    {
        FollowPlayer();
        onSafe();
    }


    IEnumerator DamageOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            NPCSalud -= damageRate;
            NPCSalud = Mathf.Clamp(NPCSalud, 0, 100);

            

            if (UICharacterToRescue.Instance != null)
                UICharacterToRescue.Instance.SendlifeCharacteToRescue(indexNPC, (int)NPCSalud);
        }
    }


    void FollowPlayer()
    {
        if (target == null) return;

        if (order && NPCSalud < 75)
        {
            Debug.Log("No puedo seguirte, estoy herido");
        }
        else if (order && NPCSalud >= 75 && !isSafe)
        {
            agent.SetDestination(target.position);
            transform.LookAt(target.position);
        }
        else if (isSafe)
        {
            order = false;
            target = null;
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

            if (UIPoints.Instance != null)
            {
                UIPoints.Instance.AddPoints(100);
            }
            NPCSalud = 100;
            if (UICharacterToRescue.Instance != null)
            {
                UICharacterToRescue.Instance.SendlifeCharacteToRescue(indexNPC, (int)NPCSalud);
            }


        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("WallFire") || collision.gameObject.CompareTag("Fire_Balls"))
        {
            damageRate = 3;
            Debug.Log("Me quemo¡¡¡¡¡¡");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallFire") || collision.gameObject.CompareTag("Fire_Balls"))
        {
            damageRate = 1;
            Debug.Log("Necesito curacion");
        }
    }

}
