using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MultiplayerTest : MonoBehaviour
{
    public Transform spawnTransform;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InicializarEscena();
    }

    private void InicializarEscena()
    {
        PhotonNetwork.Instantiate("CharacterBase_Variant", spawnTransform.position, spawnTransform.rotation);
    }
}


