using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Controller : MonoBehaviour
{
    public float maxDistance = 10f;
    private float currentDistances = 0f;
    /* Variable de ejemplo para cuando tengamos el agua
    Transform transformEjemplo;
    */

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

    // Modificando el transform en z
    // Cambiar el TransofrmEjemplo por el Transform de este objeto
    // Recordar colocar el pivot en la cara que se quiera escalar
    /*
    public void WaterByBody(bool shoot, Transform shootPoint)
    {
        transformEjemplo.position = shootPoint.position;
        Vector 3 waterScale = transformEjemplo.localScale;

        if (shoot)
        {
            waterScale.z += Time.deltaTime * 5f;

            if (waterScale.z > maxDistance)
            {
                waterScale.z = maxDistance;
            }
        }
        else if (shoot == false)
        {
            waterScale.z -= Time.deltaTime * 5f;
            if(waterScale.z < 0f)
            {
                waterScale.z = 0f;
            }
        }
        transformEjemplo.localScale = waterScale;
    }
    */
}
