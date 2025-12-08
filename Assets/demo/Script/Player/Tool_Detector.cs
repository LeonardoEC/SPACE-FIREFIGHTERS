using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ToolType
{
    None,
    Hose,
    MedicalKit,
    ToolKit

}

// Interfaces
public interface ITool
{
    ToolType ToolName { get;  }
    void UsePrimary();
    void UseSecondary();

}

// Funcion de accion 
public class Tool_Detector : MonoBehaviour
{

    public Transform[] toolPosition;

    private ITool currentTool;


    private void OnTransformChildrenChanged()
    {
        DetectorTool();
        ToolTransformsPosition();
    }




    public void DetectorTool()
    {
        Debug.Log($"Child count: {transform.childCount}");

        ITool tool = GetComponentInChildren<ITool>();
        if (tool != null)
        {
            currentTool = tool;
            Debug.Log($"Tool detectada: {currentTool.ToolName}");
        }
        else
        {
            Debug.LogError("No se detectó ninguna herramienta válida.");
        }

    }

    void ToolTransformsPosition()
    {
        if(currentTool.ToolName == ToolType.Hose)
        {
            (currentTool as MonoBehaviour).transform.position = toolPosition[0].position;
        }
        else if(currentTool.ToolName == ToolType.MedicalKit)
        {
            (currentTool as MonoBehaviour).transform.position = toolPosition[1].position;
        }
    }

    public void UseTool()
    {
        currentTool?.UsePrimary();
        currentTool?.UseSecondary();
    }
}
