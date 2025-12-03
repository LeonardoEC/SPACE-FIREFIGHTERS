using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Wall_Controller : MonoBehaviour
{
    public Rigidbody fire_RigidBody;
    public float fire_Advances_Force = 25f;
    public float fire_Retroced_Force = 1f;

    // Limite de retroceso del fuego
    public Transform limitTransform;
    Vector3 startPoint;

    // % de avance del fuego

    // agregar un trigger que le quite vide al player

    float totalDistance;
    int currentSegment = 0;
    public bool isPaused = false;

    private void Awake()
    {
        fire_RigidBody = GetComponent<Rigidbody>();
        startPoint = transform.position;
        totalDistance = Vector3.Distance(transform.position, limitTransform.position);
    }

    private void FixedUpdate()
    {
        FireMovement();
    }

    void FireMovement()
    {
        if (isPaused) return;
        float traveled = Vector3.Distance(startPoint, transform.position);
        float progress = (traveled / totalDistance);
        int segmentReached = Mathf.FloorToInt(progress * 10f);

        Debug.Log("Avance: " + segmentReached + "%");

        if (segmentReached > currentSegment)
        {
            Debug.Log("Llegue al objetivo y estoy en pausa");
            currentSegment = segmentReached;
            StartCoroutine(PauseFire());
            return;
        }

        FireAvances();
    }

    private void FireAvances()
    {


        float noise = Mathf.PerlinNoise(Time.time, 0f); // valor entre 0 y 1
        float variableForce = Mathf.Lerp(fire_Advances_Force * 0.5f, fire_Advances_Force * 1.2f, noise);
        fire_RigidBody.AddForce(transform.forward * variableForce, ForceMode.Impulse);

    }


    IEnumerator PauseFire()
    {
        isPaused = true;
        yield return new WaitForSeconds(Random.Range(1.5f, 3f));
        isPaused = false;
    }





    /*
    private void OnCollisionStay(Collision collision)
    {
        if (collision != null)
        {
            Debug.Log("No esta pasando nada");
        }

        if (collision.gameObject.CompareTag("Water") && collision.gameObject.name == "Water")
        {
            FireRetroced();
            Debug.Log("Estoy tocando: " + collision.gameObject.name);
        }

    }
    */
}
