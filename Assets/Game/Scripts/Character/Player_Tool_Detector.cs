using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script debe de ser colocado en el GameObject que tendra a las armas de hijos
/// Este script detecta que a traves de su hijo que arma fue instanciada y asigna un rol
/// 
/// Requisitos:
/// -- GameObject hijo
/// -- Tag "Tool"
/// 
/// Instrucciones:
/// 1_ Asegurate que el GameObject tenga solo un GameObject hijo
/// 2_ Si este Script solo toma el primer GameObject si hay mas de una te dara un error
/// 3_ Asegurate de que el GameObejct hijo tenga la tag Tool
/// 4_ Una vez que las detecciones sean dadas como positivas podras implementar el metodo UseTool para usar los prefab hijos
/// 
/// </summary>

public class Player_Tool_Detector : MonoBehaviour
{

    private GameObject toolDetector;
    public string rol;

    Vector3 hosePosition = new Vector3(-0.2629998f, -0.423f, 0.262f);
    Vector3 medicalKitPosition = new Vector3(0.353f, -0.565f, 0.267f);
    // Proximamente
    Vector3 toolKitPosition = new Vector3(0, 0, 0);
    private void Awake()
    {
        ToolDectertor();
    }

    private void ToolDectertor()
    {
        // Detecta si hay un hijo
        if (transform.childCount == 0)
        {
            Debug.Log("Sigue las instrucciones del Script Player_Tool_Detector.cs");
            Debug.LogError("No tool detected | Herramienta no detectada");
        }
        else if (transform.childCount > 1)
        {
            Debug.LogError("Multiple tools detected, only one tool is allowed | Se detectaron varias herramientas, solo se permite una herramienta");
        }
        else
        {
            toolDetector = transform.GetChild(0).gameObject;

            if (!toolDetector.activeSelf)
            {
                Debug.LogWarning("The tool is not active | La herramienta no está activa");
            }
            else
            {
                if(toolDetector.name == "Hose" && toolDetector.tag == "Tool")
                {
                    rol = "Firefighter";
                    toolDetector.transform.localPosition = hosePosition;
                    Debug.Log("Firefighter role assigned");
                }
                else if(toolDetector.name == "MedicalKit" && toolDetector.tag == "Tool")
                {
                    rol = "Doctor";
                    Debug.Log("Doctor role assigned");
                    toolDetector.transform.localPosition = medicalKitPosition;
                }
                else if(toolDetector.name == "ToolKit" && toolDetector.tag == "Tool")
                {
                    rol = "Engineer";
                    Debug.Log("Engineer role assigned");
                    toolDetector.transform.localPosition = toolKitPosition;
                }
                else
                {
                    Debug.LogWarning("No valid tool detected | No se detectó ninguna herramienta válida");
                }
            }
        }
    }

    /* Funcion que usa los elementos instanciados aun falta pulir y mejorar 
    public void UseTool()
    {
        if (rol == "shooter")
        {
            // Debug.Log("Shooting action performed");
            Hose_Controller hose = toolDetector.GetComponent<Hose_Controller>();
            if (hose != null)
            {
                // Funciones de Hose
            }
            else
            {
                Debug.LogError("No Hose_Controller component found on the tool");
            }
        }
        else if (rol == "healer")
        {
            // Debug.Log("Healing action performed");
            MedicalKit_Controller medicalKit = toolDetector.GetComponent<MedicalKit_Controller>();
            if (medicalKit != null)
            {
                // Funciones de MedicalKit
            }
            else
            {
                Debug.LogError("No MedicalKit_Controller component found on the tool");
            }
        }
        else
        {
            Debug.LogError("No role assigned, cannot use tool");
        }
    }
    */
}
