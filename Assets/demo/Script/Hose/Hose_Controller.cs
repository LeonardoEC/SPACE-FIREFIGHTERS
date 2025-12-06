using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Hose_Controller : MonoBehaviour, ITool
{

    // tag_gameObjectPadre Player_Tool_O
    public GameObject bulletPrefab;
    public Water_Controller water_Controller;
    public Transform shootPoint;
    public Camera cameraPoint;

    PhotonView _photonView;

    int poolSize = 10;
    List<GameObject> bulletPool;

    public ToolType ToolName => ToolType.Hose;


    public void UsePrimary()
    {
        ShootWater();
    }

    public void UseSecondary()
    {
        ShootBullet();
    }


    private void Awake()
    {
        BulletPoolStart();
        cameraPoint = GameObject.Find("Player_Camera").GetComponent<Camera>();
        _photonView = GetComponent<PhotonView>();


        if (cameraPoint == null)
        {
            GameObject camObj = GameObject.Find("Player_Camera");
            if (camObj != null)
            {
                cameraPoint = camObj.GetComponent<Camera>();
            }
            else
            {
                Debug.LogWarning("Player_Camera no encontrado. Asegúrate de que esté en escena antes de instanciar el Hose.");
            }
        }

    }

    private void Update()
    {
        HoseMovement();
    }

    // Terminado
    void HoseMovement()
    {
        Transform parent = transform.parent;
        if (parent != null && parent.CompareTag("Player_Tool_O"))
        {
            transform.rotation = cameraPoint.transform.rotation;
        }

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

    // 
    public void ShootBullet()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
        // dejo solo esto 
            GameObject bulletInPool = GetBullet();
            if (bulletInPool != null)
            {
                bulletInPool.transform.position = shootPoint.position;
                bulletInPool.transform.rotation = shootPoint.rotation;
                bulletInPool.SetActive(true);

                StartCoroutine(DisableAfterTime(bulletInPool, 3f));
            }
        }
    }






}
