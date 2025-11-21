using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Controller : MonoBehaviour
{
    // Direccion del movimiento del fuego
    public float fireDirectionx;
    // Velocidad del fuego
    public float fireSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireMove();
    }

    // Logica de movimiento del fuego solo por transform
    // Usar solo para demo
    private void FireMove()
    {
        transform.Translate(fireDirectionx * fireSpeed * Time.deltaTime, 0, 0);
    }

}
