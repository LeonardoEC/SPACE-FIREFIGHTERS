using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_LifeDisplay : MonoBehaviour
{
    public NPC_Controller npcController;
    public TextMeshProUGUI lifeText;

    private void Update()
    {
        if (npcController == null || lifeText == null) return;

        lifeText.text = $"Vida: {(int)npcController.NPCSalud}";

        if (npcController.order && npcController.NPCSalud >= 75 && !npcController.isSafe)
        {
            lifeText.color = Color.green;
        }
        else
        {
            lifeText.color = Color.white;
        }

        transform.LookAt(Camera.main.transform);
    }

}
