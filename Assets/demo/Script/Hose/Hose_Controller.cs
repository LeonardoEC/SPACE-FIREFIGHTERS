using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose_Controller : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Water_Controller water_Controller;
    public Transform shootPoint;
    public Camera cameraPoint;

    int poolSize = 10;
    List<GameObject> bulletPool;

    private void Awake()
    {
        BulletPoolStart();
    }

    private void Update()
    {
        HoseMovement();
    }

    // Terminado
    void HoseMovement()
    {
        transform.rotation = cameraPoint.transform.rotation;
    }

    // Terminado
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

    /* **************************************************************************************************** */ 

    // Terminado
    void BulletPoolStart()
    {
        bulletPool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    GameObject GetBullet()
    {
        foreach(var bullet in bulletPool)
        {
            if(!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }

    IEnumerator DisableAfterTime(GameObject bullet, float tiem)
    {
        yield return new WaitForSeconds(tiem);
        if(bullet.activeInHierarchy)
        {
            bullet.SetActive(false);
        }
    }

    public void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject bulletInPool = GetBullet();
            if(bulletInPool != null)
            {
                bulletInPool.transform.position = shootPoint.position;
                bulletInPool.transform.rotation = shootPoint.rotation;
                bulletInPool.SetActive(true);

                StartCoroutine(DisableAfterTime(bulletInPool, 3f));

            }
        }

    }






}
