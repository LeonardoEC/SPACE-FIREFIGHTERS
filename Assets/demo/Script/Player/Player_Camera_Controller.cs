using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Controller : MonoBehaviour
{
    // Sensibilidad del mouse
    [Header("Mouse Settings")]
    public float mouseSensitivity = 250f;

    // Referencia al cuerpo del jugador
    [Header("Player Body")]
    public Transform playerBody;

    // Variable para la rotacion en el eje X
    private float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraPlayer();
    }

    // Metodo para controlar la camara del jugador
    private void CameraPlayer()
    {
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // Rotar la camara y el cuerpo del jugador
        xRotation -= mouseY;
        // Limitar la rotacion en el eje X
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        // Aplicar la rotacion a la camara y al cuerpo del jugador
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Rotar el cuerpo del jugador en el eje Y
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
