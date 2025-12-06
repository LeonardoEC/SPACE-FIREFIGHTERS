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
    // Dani
    public int progressPercent ;



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
    private void Update()
    {
        FinalMovement();
        progressPercent = AdvanceProgress();

        //Debug.Log("Avance del fuego: " + progressPercent + "%");
        UIMapManager.Instance._currentLevel = progressPercent;
    }

    

    int AdvanceProgress()
    {
        float traveled = Vector3.Distance(startPoint, transform.position);
        float progress = (traveled / totalDistance);
        int segmentReached = Mathf.FloorToInt(progress * 100f);
        

        return segmentReached;
    }

    void FireMovement()
    {
        if (isPaused) return;

        float traveled = Vector3.Distance(startPoint, transform.position);
        float progress = (traveled / totalDistance);
        int segmentReached = Mathf.FloorToInt(progress * 10f);

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
        yield return new WaitForSeconds(Random.Range(2f, 3.5f));
        isPaused = false;
    }

    void FinalMovement()
    {
        if (Vector3.Distance(transform.position, limitTransform.position) < 0.1f)
        {
            fire_Advances_Force = 0f;
            Debug.Log("El fuego llegó al límite y se detuvo.");
        }
    }


}
