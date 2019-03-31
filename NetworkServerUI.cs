using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class NetworkServerUI : MonoBehaviour {
	
	CrossPlatformInputManager.VirtualAxis m_HVAxis; 
	CrossPlatformInputManager.VirtualAxis m_VVAxis; 
	string horizontalAxisName = "Horizontal"; 
	string verticalAxisName = "Vertical";
    public string localStrMsgId;
    public Int32 localMsgId;
    //
    public float m_HVAxis888;
    public float m_VVAxis888;
    //
    public float m_HVAxis889;
    public float m_VVAxis889;
    //
    public float m_HVAxis890;
    public float m_VVAxis890;
    //
    public float m_HVAxis891;
    public float m_VVAxis891;
    //
    public bool m_anim0ButtonDown888;
    public bool m_anim1ButtonDown888;
    public bool m_anim2ButtonDown888;
    public bool m_anim3ButtonDown888;
    public bool m_anim4ButtonDown888;
    public bool m_anim5ButtonDown888;
    //
    public bool m_anim0ButtonDown889;
    public bool m_anim1ButtonDown889;
    public bool m_anim2ButtonDown889;
    public bool m_anim3ButtonDown889;
    public bool m_anim4ButtonDown889;
    public bool m_anim5ButtonDown889;
    //
    public bool m_anim0ButtonDown890;
    public bool m_anim1ButtonDown890;
    public bool m_anim2ButtonDown890;
    public bool m_anim3ButtonDown890;
    public bool m_anim4ButtonDown890;
    public bool m_anim5ButtonDown890;
    //
    public bool m_anim0ButtonDown891;
    public bool m_anim1ButtonDown891;
    public bool m_anim2ButtonDown891;
    public bool m_anim3ButtonDown891;
    public bool m_anim4ButtonDown891;
    public bool m_anim5ButtonDown891;
    //


    NetworkIdentity m_Identity;

    void OnGUI()
    {
        //string ipaddress = Network.player.ipAddress;
        string ipaddress = NetworkManager.singleton.networkAddress;
        GUI.Box(new Rect(10,Screen.height - 50, 100,50),ipaddress);
        GUI.Label(new Rect(20,Screen.height - 35, 100,20), "Status:" + NetworkServer.active);
        GUI.Label(new Rect(20,Screen.height - 20, 100,20), "Connected:" + NetworkServer.connections.Count);
        localStrMsgId = (GUI.TextField(new Rect(25, Screen.height - 140, 100, 30), localStrMsgId));
    }

	// Use this for initialization
	void Start () {
        //Fetch the NetworkIdentity component of the GameObject
        m_Identity = GetComponent<NetworkIdentity>();
        m_HVAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
		CrossPlatformInputManager.RegisterVirtualAxis(m_HVAxis);
		m_VVAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
		CrossPlatformInputManager.RegisterVirtualAxis(m_VVAxis);
		
		NetworkServer.Listen(25000);
		NetworkServer.RegisterHandler(888, ServerReceiveMessage888);
        NetworkServer.RegisterHandler(889, ServerReceiveMessage889);
        NetworkServer.RegisterHandler(890, ServerReceiveMessage890);
        NetworkServer.RegisterHandler(891, ServerReceiveMessage891);
    }

	private void ServerReceiveMessage888(NetworkMessage message)
	{
		StringMessage msg = new StringMessage ();
		msg.value = message.ReadMessage<StringMessage>().value;
   
		string[] deltas = msg.value.Split('|');
        m_HVAxis888 = (Convert.ToSingle(deltas[0]));
        m_VVAxis888 = (Convert.ToSingle(deltas[1]));

        m_anim0ButtonDown888 = (Convert.ToBoolean(deltas[2]));
        m_anim1ButtonDown888 = (Convert.ToBoolean(deltas[3]));
        m_anim2ButtonDown888 = (Convert.ToBoolean(deltas[4]));
        m_anim3ButtonDown888 = (Convert.ToBoolean(deltas[5]));
        m_anim4ButtonDown888 = (Convert.ToBoolean(deltas[6]));
        m_anim5ButtonDown888 = (Convert.ToBoolean(deltas[7]));
        Debug.Log("deltas" + deltas[0] + "    " + deltas[1]);
    }
   private void ServerReceiveMessage889(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
       msg.value = message.ReadMessage<StringMessage>().value;
   
        string[] deltas = msg.value.Split('|');
        //variables to control id 889 from PC localy
        m_HVAxis889=(Convert.ToSingle(deltas[0]));
        m_VVAxis889=(Convert.ToSingle(deltas[1]));
        m_anim0ButtonDown889 = (Convert.ToBoolean(deltas[2]));
        m_anim1ButtonDown889 = (Convert.ToBoolean(deltas[3]));
        m_anim2ButtonDown889 = (Convert.ToBoolean(deltas[4]));
        m_anim3ButtonDown889 = (Convert.ToBoolean(deltas[5]));
        m_anim4ButtonDown889 = (Convert.ToBoolean(deltas[6]));
        m_anim5ButtonDown889 = (Convert.ToBoolean(deltas[7]));

    }
    private void ServerReceiveMessage890(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message.ReadMessage<StringMessage>().value;

        string[] deltas = msg.value.Split('|');
        m_HVAxis890 = (Convert.ToSingle(deltas[0]));
        m_VVAxis890 = (Convert.ToSingle(deltas[1]));
        m_anim0ButtonDown890 = (Convert.ToBoolean(deltas[2]));
        m_anim1ButtonDown890 = (Convert.ToBoolean(deltas[3]));
        m_anim2ButtonDown890 = (Convert.ToBoolean(deltas[4]));
        m_anim3ButtonDown890 = (Convert.ToBoolean(deltas[5]));
        m_anim4ButtonDown890 = (Convert.ToBoolean(deltas[6]));
        m_anim5ButtonDown890 = (Convert.ToBoolean(deltas[7]));

    }
    private void ServerReceiveMessage891(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message.ReadMessage<StringMessage>().value;

        string[] deltas = msg.value.Split('|');
        m_HVAxis891 = (Convert.ToSingle(deltas[0]));
        m_VVAxis891 = (Convert.ToSingle(deltas[1]));
        m_anim0ButtonDown891 = (Convert.ToBoolean(deltas[2]));
        m_anim0ButtonDown891 = (Convert.ToBoolean(deltas[2]));
        m_anim1ButtonDown891 = (Convert.ToBoolean(deltas[3]));
        m_anim2ButtonDown891 = (Convert.ToBoolean(deltas[4]));
        m_anim3ButtonDown891 = (Convert.ToBoolean(deltas[5]));
        m_anim4ButtonDown891 = (Convert.ToBoolean(deltas[6]));
        m_anim5ButtonDown891 = (Convert.ToBoolean(deltas[7]));
    }

    // Update is called once per frame
    void Update () {
       

    }
}

