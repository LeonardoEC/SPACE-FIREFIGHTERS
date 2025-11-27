using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Water_Bullet_Controller : MonoBehaviour
{
    void Update()
    {
        BulletDirection();
    }

    // Limitador de disparos de waterballs
    void BulletDirection()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 50f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WallFire") && other.gameObject.name == "WallFire")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Fire_Balls") && other.gameObject.name == "Fire_Balls(Clone)")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }
}
