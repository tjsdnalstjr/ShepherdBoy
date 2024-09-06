//using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public struct Card
{
    public enum Card_Type { WOLF, PEACE }
    public Card_Type type;
    public Card(Card_Type _type)
    {
        type = _type;
    }
}

public class GameMaster : MonoBehaviourPunCallbacks
{
    public enum Game_Phase { SELECTSHAPHERD, DRAWCARD, ASSERT, BETTING, CHECKRESULT }
    private bool isMaster = false;
    private List<Card> cardDeck = new List<Card>();
    public Card nowCard;
    public GamePlayer nowShapherd;
    void StartGame()
    {
        isMaster = PhotonNetwork.LocalPlayer.IsMasterClient;
        Hashtable data = new Hashtable();
        if(isMaster)
        {
            foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
            {
                data = new Hashtable() { { "PlayedShapherd", false }, { "SheepCount", 5 } , { "Name", GameManager.Instance.myName } };
                player.SetCustomProperties(data);
            }
        }
    }

    void InitializeCardDeck()
    {
        cardDeck.Clear();
        // ��ȭ ī�� 4��
        for (int i = 0; i < 4; i++)
        {
            cardDeck.Add(new Card(Card.Card_Type.PEACE));
        }
        // ���� ī�� 3��
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
        Hashtable props = new Hashtable() { { "DrawCard", drawCard } };
        PhotonNetwork.CurrentRoom.SetCustomProperties(props);
    }

    public void SelectShepherd()
    {
        int index;
        do
        {
            index = Random.Range(0, PhotonNetwork.CurrentRoom.PlayerCount);
        } while ((bool)PhotonNetwork.CurrentRoom.Players[index].CustomProperties["PlayedShapherd"] || ((int)PhotonNetwork.CurrentRoom.Players[index].CustomProperties["SheepCount"] <= 0));//���� �����ϰ� �ְ� ��ġ�� �ҳ��� �ѹ��� �غ��� ���� ������ �̱�
        Hashtable props = new Hashtable(){{"ShepherdPlayer", PhotonNetwork.CurrentRoom.Players[index].CustomProperties["Name"]}};
        PhotonNetwork.CurrentRoom.SetCustomProperties(props);
    }

    public void StartPhase()
    {
        SelectShepherd();
        InitializeCardDeck();
    }

    public void StartRound()
    {
        if (isMaster)
        {
            DrawCard();
        }
        if((string)PhotonNetwork.CurrentRoom.CustomProperties["ShepherdPlayer"] == GameManager.Instance.myName)
        {
            //ī�� �̹��� ����
        }
    }
}