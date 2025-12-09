using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Controller : MonoBehaviour
{
    [SerializeField] private GameObject _audSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_audSource.activeSelf)
        {
            _audSource.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0) && _audSource.activeSelf)
        {
            _audSource.SetActive(false);
        }
    }
}
