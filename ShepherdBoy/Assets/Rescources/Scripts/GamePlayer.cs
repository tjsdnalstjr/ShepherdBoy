using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GamePlayer : MonoBehaviour
{
    public string nickName;
    public int sheepCount = 5;
    public bool playedShepherd = false;
    public PhotonView photonView;

    public void InitializePlayer(string name)
    {
        nickName = name;
        sheepCount = 5;
        playedShepherd = false;
    }
    public bool IsEliminated()
    {
        return sheepCount <= 0;
    }

    public bool TellWolf(bool wolfCome)
    {
        return wolfCome;
    }
}
