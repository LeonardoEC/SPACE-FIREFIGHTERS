using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
    public RollDropDown rol;
    public PlayerInfo playerInfo;

    public PhotonView _PlayerView;
    // Manos del personaje

    public Transform[] toolposition;

    private void OnEnable()
    {
        rol = playerInfo.rollPlayer;
        
    }

    private void Start()
    {
        ToolDectertor();
    }

    /*
    void PositionTool()
    {
        if (toolDetector == null)
        {
            Debug.LogError("toolDetector es NULL. Revisa que exista un hijo con tag 'Tool'.");
            return;
        }

        if (toolposition == null || toolposition.Length == 0)
        {
            Debug.LogError("toolposition no está asignado en el Inspector o está vacío.");
            return;
        }

        if (!_PlayerView.IsMine)
        {
            if (toolDetector.name == "Hose" && toolDetector.tag == "Tool")
            {
                if (toolposition.Length > 1)
                    toolDetector.transform.localPosition = toolposition[0].transform.position;
            }
            else if (toolDetector.name == "Medical_kit" && toolDetector.tag == "Tool")
            {
                if (toolposition.Length > 4)
                    toolDetector.transform.localPosition = toolposition[1].transform.position;
            }
        }
        else if (_PlayerView.IsMine)
        {
            if (toolDetector.name == "Hose" && toolDetector.tag == "Tool")
            {
                if (toolposition.Length > 0)
                    toolDetector.transform.localPosition = toolposition[0].transform.position;
            }
            else if (toolDetector.name == "Medical_kit" && toolDetector.tag == "Tool")
            {
                if (toolposition.Length > 2)
                    toolDetector.transform.localPosition = toolposition[1].transform.position;
            }
        }
    }
    */

    private void ToolDectertor()
    {

        toolDetector = transform.GetChild(0).gameObject;
        /*
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
            

            if (!toolDetector.activeSelf)
            {
                Debug.LogWarning("The tool is not active | La herramienta no está activa");
            }
            else
            {
                if(toolDetector.name == "Hose(Clone)" && toolDetector.tag == "Tool")
                {
                    //
                    rol = "Firefighter";
                    // toolDetector.transform.localPosition = hosePosition;
                    Debug.Log("Firefighter role assigned");

                    // Agregar funcionalidad

                }
                else if(toolDetector.name == "Medical_kit(Clone)" && toolDetector.tag == "Tool")
                {
                    rol = "Doctor";
                    Debug.Log("Doctor role assigned");
                    // toolDetector.transform.localPosition = medicalKitPosition;
                }
                else if(toolDetector.name == "ToolKit(Clone)" && toolDetector.tag == "Tool")
                {
                    rol = "Engineer";
                    Debug.Log("Engineer role assigned");
                    // toolDetector.transform.localPosition = toolKitPosition;
                }
                else
                {
                    Debug.LogWarning("No valid tool detected | No se detectó ninguna herramienta válida");
                }
            }
        }*/
    }

    

    // Funcion que usa los elementos instanciados aun falta pulir y mejorar //
    public void UseTool()
    {
        if (rol == RollDropDown.Bombero)
        {
            // Debug.Log("Shooting action performed");
            Hose_Controller hose = toolDetector.GetComponent<Hose_Controller>();
            Debug.Log(hose);

            //Tomar los inputs 
            if (hose != null)
            {
                // Funciones de Hose
                //hose.ShootBullet();
                //hose.ShootWater();

            }
            else
            {
                Debug.LogError("No Hose_Controller component found on the tool");
            }
        }
    
        else if (rol == RollDropDown.Medico)
        {
            // Debug.Log("Healing action performed");
            Medical_Kit_Controller medicalKit = toolDetector.GetComponent<Medical_Kit_Controller>();
            if (medicalKit != null)
            {
                //medicalKit.medic();
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
    
}
