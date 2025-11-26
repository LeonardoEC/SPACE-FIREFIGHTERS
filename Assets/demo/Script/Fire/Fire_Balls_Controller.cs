using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Balls_Controller : MonoBehaviour
{
    void Update()
    {
        minifireMovement();
    }

    void minifireMovement()
    {
        transform.Translate(new Vector3(0, 0, 1f) * 4f * Time.deltaTime);
    }
}
