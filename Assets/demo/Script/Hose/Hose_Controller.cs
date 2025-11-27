using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose_Controller : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Water_Controller waterController;
    public Transform shootPoint;
    public Camera cameraPoint;

    private void Update()
    {
        HoseMovement();
    }

    void HoseMovement()
    {
        transform.rotation = cameraPoint.transform.rotation;
    }

    public void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))

            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

    public void ShootWater()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            waterController.waterByRaycast(true, shootPoint);
            Debug.Log("Disparando agua");
        }
        else
        {
            waterController.waterByRaycast(false, shootPoint);
            Debug.Log("No disparo agua");
        }
    }
}
