using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterWalking : MonoBehaviour
{
    [SerializeField] private GameObject _audSource;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Player_Movement _playerMov;

    [SerializeField] private bool isMoving;

    public Rigidbody rb;

    public float threshold = 0.01f;

    void Start()
    {
        _audSource.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (_audSource.activeSelf && _playerMov.inAir)
        //{
        //    _audSource.SetActive(false);
        //}


        //if (!_audSource.activeSelf && isMoving) {
        //    if (_playerMov.isPlayerGrounded)
        //    {
        //        _audSource.SetActive(true);
        //    }            
        //}
        //else if (_audSource.activeSelf && !isMoving){

        //    _audSource.SetActive(false);
        //}

        if (!_photonView.IsMine)
        {
            if (!_audSource.activeSelf && isMoving)
            {
                _audSource.SetActive(true);
            }
            else if (_audSource.activeSelf && !isMoving)
            {
                _audSource.SetActive(false);
            }
        }
       


        if (_photonView.IsMine)
        {
            bool currentlyMoving = rb.velocity.sqrMagnitude > threshold;

            if (currentlyMoving != isMoving)
            {
                isMoving = currentlyMoving;

            }

            if (_audSource.activeSelf && _playerMov.inAir)
            {
                _audSource.SetActive(false);
            }


            if (!_audSource.activeSelf && isMoving)
            {
                if (_playerMov.isPlayerGrounded)
                {
                    _audSource.SetActive(true);
                }
            }
            else if (_audSource.activeSelf && !isMoving)
            {

                _audSource.SetActive(false);
            }

            _photonView.RPC("RPC_SetIsWalking", RpcTarget.Others, isMoving);
        }

       
    }


    [PunRPC]
    void RPC_SetIsWalking(bool value)
    {
        isMoving = value;
    }
}
