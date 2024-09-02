using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public struct Card
{
    public enum Card_Type { WOLF, PEACE }
    public Card_Type type;
    public Card(Card_Type _type)
    {
        type = _type;
    }
}

public class GameMaster : MonoBehaviour
{
    private bool isMaster;
    private List<Card> cardDeck = new List<Card>();
    public List<Player> playerList = new List<Player>();
    public Card nowCard;
    public PhotonView photonView;
    public bool wolfCome;
    public Player nowShapherd;
    void GameStart()
    {
        isMaster = PhotonNetwork.LocalPlayer.IsMasterClient;
        if(isMaster)
        {
            InitializeCardDeck();
        }
    }

    void InitializeCardDeck()
    {
        cardDeck.Clear();
        // 평화 카드 4장
        for (int i = 0; i < 4; i++)
        {
            cardDeck.Add(new Card(Card.Card_Type.PEACE));
        }
        // 늑대 카드 3장
        for (int i = 0; i < 3; i++)
        {
            cardDeck.Add(new Card(Card.Card_Type.WOLF));
        }
    }

    public void DrawCard()
    {
        int cardIndex = Random.Range(0, cardDeck.Count);
        Card drawCard = cardDeck[cardIndex];
        cardDeck.Remove(drawCard);
        photonView.RPC("SetCard", RpcTarget.All, drawCard.type);
    }

    public void SelectShepherd()
    {
        int index;
        do
        {
            index = Random.Range(0, playerList.Count);
        } while (playerList[index].playedShepherd || playerList[index].IsEliminated());//탈락하지 않고 양치기 소년을 한번더 해보지 못한 유저를 뽑기
        photonView.RPC("SetShepherd", RpcTarget.All, index);
    }

    [PunRPC]
    public void SetCard(Card.Card_Type type)
    {
        nowCard = new Card(type);
    }

    [PunRPC]
    public void SetShepherd(int index)
    {
        nowShapherd = playerList[index];
        nowShapherd.playedShepherd = true;
    }
}