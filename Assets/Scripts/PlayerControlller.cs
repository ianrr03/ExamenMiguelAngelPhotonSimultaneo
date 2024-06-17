using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerControlller : MonoBehaviour
{
    public float velocity = 5f;

   private Rigidbody _rigidbody;
   private PhotonView _photonView;
   
   
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_photonView.IsMine)
        {
            float movH = Input.GetAxis("Horizontal");
            float movV = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(-movH * velocity, 0, -movV * velocity);

            _rigidbody.AddForce(movimiento);
        }
    }
}
