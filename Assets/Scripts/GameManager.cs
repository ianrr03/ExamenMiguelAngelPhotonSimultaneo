using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InstatiatePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void InstatiatePlayers()
    {
        
        int playerNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        switch(playerNumber)
        {
            case 1:                
                PhotonNetwork.Instantiate("Player1", new Vector3(0, -0.5f, 2f), Quaternion.identity);
                break;
            case 2:
                PhotonNetwork.Instantiate("Player2", new Vector3(0, -0.5f, -2f), Quaternion.identity);
                break;
        }
    }
}
