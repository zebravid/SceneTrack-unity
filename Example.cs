//Create a GameObject and attach this script
//Create two buttons. To do this, go to Create>UI>Button for each.
//Click each Button in the Hierarchy, and navigate to the Inspector window. Scroll down to the On Click() section and press the + button to add an action
//Attach your GameObject to access the appropriate function you want your Button to do.

using UnityEngine;
using UnityEngine.Networking;

public class Example : NetworkManager
{
    public void StartHostButton()
    {
        singleton.StartHost();
    }

    //Press the "Disconnect" Button to stop the Host
    public void StopHostButton()
    {
        singleton.StopHost();
    }
}