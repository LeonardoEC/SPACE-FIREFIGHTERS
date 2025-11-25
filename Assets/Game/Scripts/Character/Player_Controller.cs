using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/// <summary>
/// Este script sirve para que el personaje pueda usar las herramientas
/// Va al cuerpo de personaje
/// </summary>

public class Player_Controller : MonoBehaviour
{


    public Player_Tool_Detector Player_Tool_Detector;
    public string rol;

    private void OnEnable()
    {
        if (Player_Tool_Detector == null)
        {
            Player_Tool_Detector = GetComponentInChildren<Player_Tool_Detector>();
            rol = Player_Tool_Detector.rol;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Usa las herramientas "pronta actualizacion"
        // Player_Tool_Detector.UseTool();
    }
}
