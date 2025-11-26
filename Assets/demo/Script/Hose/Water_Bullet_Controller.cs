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

    void BulletDirection()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5f);
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
    }
}
