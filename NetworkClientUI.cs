using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine;

public class NetworkClientUI : MonoBehaviour {

    public static short msgID=888;
    public short msgIDGui;
    public string strMsgId ;
    static public bool anim0ButtonDown;
    static public bool anim1ButtonDown;
    static public bool anim2ButtonDown;
    static public bool anim3ButtonDown;
    static public bool anim4ButtonDown;
    static public bool anim5ButtonDown;

    static NetworkClient client;
    static public float hhDelta;
    static public float vvDelta;
    public string ipaddress;
    void OnGUI()
    {
        ipaddress = (GUI.TextField(new Rect(125, Screen.height - 50, 100, 30), ipaddress)); ;
        //string ipaddress = NetworkManager.singleton.networkAddress;
        //string ipaddress = Network.player.ipAddress;
        GUI.Box(new Rect(10, Screen.height - 50, 100, 50), ipaddress);
        GUI.Label(new Rect(20, Screen.height - 30, 100, 20), "Status:" + client.isConnected);

        if (!client.isConnected)
        {
            strMsgId = (GUI.TextField(new Rect(25, Screen.height - 140, 100, 30), strMsgId));
            if (GUI.Button(new Rect(10, 10, 60, 50), "Connect"))
            {
               
                Connect();
            }
        }
        if (client.isConnected)
        {
            
        }
    }
	// Use this for initialization
	void Start () {
		client = new NetworkClient();
	}

	void Connect()
	{
        //gets an player ID from GUI
        msgID = short.Parse(strMsgId);

        client.Connect(ipaddress, 25000);

	}




    static public void SendInfo()
    {
        if (client.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = hhDelta + "|" + vvDelta + "|" + Convert.ToString(anim0ButtonDown)+"|" + Convert.ToString(anim1ButtonDown)+
                "|" + Convert.ToString(anim2ButtonDown)+"|" + Convert.ToString(anim3ButtonDown)+"|" + Convert.ToString(anim4ButtonDown)
                +"|" + Convert.ToString(anim5ButtonDown);
            client.Send(msgID, msg);
        }
    }

    // Update is called once per frame
    void Update () {

	}
}

