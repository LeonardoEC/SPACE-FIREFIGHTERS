using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Balls_Controller : MonoBehaviour
{
    void Update()
    {
        minifireMovement();
    }

    private void OnDisable()
    {

        if (UIPoints.Instance != null)
        {
            UIPoints.Instance.AddPoints(100);
        }

        Debug.Log("Ganasta 100pts por destruir bola de fuego");
    }

    void minifireMovement()
    {
        transform.Translate(new Vector3(0, 0, 1f) * 4f * Time.deltaTime);
    }

}
