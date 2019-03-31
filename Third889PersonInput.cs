using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;

public class Third889PersonInput : MonoBehaviour
{
    public PlayerMovement Control;
    public float rotationSpeed;
    public float speed;
    public float walkRun;
    public FixedTouchField TouchField;
    // Use this for initialization
    void Start()
    {
        Control = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //TODO add item in the hand, pick up.
        //TODO add different walk stiles wounded, happy, sad
        if (GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().localStrMsgId == "889")
        {
            Control.anim0 = Input.GetKey(KeyCode.J);
            //if left shift pressed switches to run as the total speed value incresesCheck in player movement script
            if (Input.GetKey(KeyCode.LeftShift))
            { 
            Control.Hinput = CrossPlatformInputManager.GetAxis("Horizontal") * walkRun*speed;
            Control.Vinput = CrossPlatformInputManager.GetAxis("Vertical") * walkRun*speed;
            }
            else
            {
                Control.Hinput = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
                Control.Vinput = CrossPlatformInputManager.GetAxis("Vertical") * speed;

            }
        }
        else
        {
            Control.Hinput = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_HVAxis889 * rotationSpeed;
            Control.Vinput = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_VVAxis889 * speed;
            Control.anim0 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim0ButtonDown889;
            Control.anim1 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim1ButtonDown889;
            Control.anim2 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim2ButtonDown889;
            Control.anim3 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim3ButtonDown889;
            Control.anim4 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim4ButtonDown889;
            Control.anim5 = GameObject.Find("NetworkManager").GetComponent<NetworkServerUI>().m_anim5ButtonDown889;
        }

#if !MOBILE_INPUT

#endif
    }
}
