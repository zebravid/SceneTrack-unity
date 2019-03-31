using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;


public class Third890PersonInput : MonoBehaviour
{
    public PlayerMovement Control;
    public float rotationSpeed ;
    public float speed;
    public float walkRun;
    // Use this for initialization
    void Start()
    {
        Control = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Networkmanger runs localy if it gets id from GuI it takes animation control
        //else it takes data from remote var m_HV...
        if (GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().localStrMsgId == "890")
        {
            Control.anim0 = Input.GetKey(KeyCode.J);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Control.Hinput = CrossPlatformInputManager.GetAxis("Horizontal") * walkRun * speed;
                Control.Vinput = CrossPlatformInputManager.GetAxis("Vertical") * walkRun * speed;
            }
            else
            {
                Control.Hinput = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
                Control.Vinput = CrossPlatformInputManager.GetAxis("Vertical") * speed;

            }
        }
        else
        {
            Control.Hinput = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_HVAxis890 * rotationSpeed;
            Control.Vinput = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_VVAxis890 * speed;
            Control.anim0 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim0ButtonDown890;
            Control.anim1 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim1ButtonDown890;
            Control.anim2 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim2ButtonDown890;
            Control.anim3 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim3ButtonDown890;
            Control.anim4 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim4ButtonDown890;
            Control.anim5 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim5ButtonDown890;
        }

#if !MOBILE_INPUT

#endif
    }
}
