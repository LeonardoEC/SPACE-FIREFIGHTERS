using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeleteThingsToPlayer : MonoBehaviour
{
    public PhotonView _pho;

    [Space(10)]
    public GameObject _ownerObj;
    public GameObject _otherObj;

    [Space(10)]
    public Rigidbody rg;
    public CapsuleCollider cc;
    public Player_Movement pm;
    public Player_Controller pc;

    // Start is called before the first frame update
    void Start()
    {
        if (!_pho.IsMine)
        {
            Destroy(rg);
            Destroy(cc);
            Destroy(pm);
            Destroy(pc);

            Destroy(_ownerObj);

        }
        else
        {
            Destroy(_otherObj);
        }

        Destroy(this);
    }


}
