using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Controller : MonoBehaviour
{
    float maxDistance = 250f;
    private float currentDistances = 0f;

    // metodo simulacion comportamiento del agua(RayCast)
    public void waterByRaycast(bool shoot, Transform shootPoint)
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        if (shoot)
        {
            currentDistances += Time.deltaTime * 5f;
            if (currentDistances > maxDistance)
            {
                currentDistances = maxDistance;
            }


            Debug.DrawRay(ray.origin, ray.direction * currentDistances, Color.blue);

            // Detector del agua por raycast
            if (Physics.Raycast(ray, out RaycastHit hit, currentDistances))
            {
                Debug.Log("Agua golpeon con: " + hit.collider.name);
            }

        }
        else if (shoot == false)
        {
            currentDistances -= Time.deltaTime * 10f;
            if (currentDistances < 0f)
            {
                currentDistances = 0f;
            }

            Debug.DrawRay(ray.origin, ray.direction * currentDistances, Color.blue);
        }
    }

    public void WaterByBody(bool shoot)
    {

        Vector3 waterScale = transform.localScale;

        waterScale.x = 50f;
        waterScale.y = 50f;

        if (shoot)
        {
            waterScale.z += Time.deltaTime * 250f;


            if (waterScale.z >= maxDistance)
            {
                waterScale.z = maxDistance;
            }


        }
        else if (shoot == false)
        {
            waterScale.z -= Time.deltaTime * 500f;
            
            if (waterScale.z < 0f)
            {
                waterScale.z = 0f;
            }
            
        }

        transform.localScale = waterScale;
        // Debug.Log(transform.localScale.z);


    }



}

