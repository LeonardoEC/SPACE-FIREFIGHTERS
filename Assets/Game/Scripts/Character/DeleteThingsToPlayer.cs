using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeleteThingsToPlayer : MonoBehaviour
{
    public PhotonView _pho;
    public GameObject _bodyPlayer;

    [Space(10)]
    public List<GameObject> _listObj;
    public CapsuleCollider cap;
    public Rigidbody rg;
    public Player_Movement PM;
    public Player_Controller pm;


    // Start is called before the first frame update
    void Start()
    {
        if (!_pho.IsMine)
        {
            foreach (GameObject item in _listObj)
            {
                Destroy(item);
            }
            Destroy(cap);
            Destroy(rg);
            Destroy(PM);
            Destroy(pm);

            
        }
        else
        {
            Destroy(_bodyPlayer);
        }

        Destroy(this);
    }


}
