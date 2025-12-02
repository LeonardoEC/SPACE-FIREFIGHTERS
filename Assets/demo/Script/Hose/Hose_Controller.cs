using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose_Controller : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Water_Controller water_Controller;
    public Transform shootPoint;
    public Camera cameraPoint;

    /*
    public Transform waterPoint;
    private GameObject currentWater;
    private Water_Controller currentWaterController;
    */


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

            water_Controller.WaterByBody(true);

        }
        else
        {
            water_Controller.WaterByBody(false);

        }
    }



}
