using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose_Controller : MonoBehaviour
{
    // Distancia maxima del rayo
    public float MaxDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HoseDirectionAction();
    }

    private void HoseDirectionAction()
    {
        // Crear rayo desde la posicion de la manguera en la direccion que apunta
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue);

        // Almacenar informacion del rayo
        RaycastHit raycastHit;

        // Disparar rayo y comprobar si golpea algo
        if (Physics.Raycast(ray, out raycastHit, MaxDistance))
        {
            // Muestra la informacion del objeto golpeado
            Debug.Log("Hose hit: " + raycastHit.collider.name);
            Debug.DrawRay(transform.position, transform.forward * raycastHit.distance, Color.red);

            // Comprobar si el objeto golpeado es fuego y aplicarle la logica correspondiente
            // Interaciones con el fuego describir aqui
            if (raycastHit.collider.CompareTag("Fire"))
            {
                // Atemcion, mecanica opsoleta, solo para demo

                Fire_Controller fire_Controller = raycastHit.collider.GetComponent<Fire_Controller>();
                raycastHit.transform.Translate( new Vector3(0, 0, fire_Controller.fireDirectionx + ray.direction.z) * (fire_Controller.fireSpeed + 7f) * Time.deltaTime);
            }




        }

    }
}
