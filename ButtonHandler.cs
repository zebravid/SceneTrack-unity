using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {

        public string Name;

        void OnEnable()
        {

        }

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);
            //sends button information to NetwClient
            switch (Name)
            {
                case "anim0":
                    NetworkClientUI.anim0ButtonDown = true;
                    NetworkClientUI.anim1ButtonDown = false;
                    NetworkClientUI.anim2ButtonDown = false;
                    NetworkClientUI.anim3ButtonDown = false;
                    NetworkClientUI.anim4ButtonDown = false;
                    NetworkClientUI.anim5ButtonDown = false;

                    Debug.Log("Anim 0 Pressed");
                    break;
                case "anim1":
                    NetworkClientUI.anim0ButtonDown = false;
                    NetworkClientUI.anim1ButtonDown = true;
                    NetworkClientUI.anim2ButtonDown = false;
                    NetworkClientUI.anim3ButtonDown = false;
                    NetworkClientUI.anim4ButtonDown = false;
                    NetworkClientUI.anim5ButtonDown = false;

                    Debug.Log("Anim 1 Pressed");
                    break;
                case "anim2":
                    NetworkClientUI.anim0ButtonDown = false;
                    NetworkClientUI.anim1ButtonDown = false;
                    NetworkClientUI.anim2ButtonDown = true;
                    NetworkClientUI.anim3ButtonDown = false;
                    NetworkClientUI.anim4ButtonDown = false;
                    NetworkClientUI.anim5ButtonDown = false;
                    break;
                    //TODO fill the rest so different animations do not interlaps
                case "anim3":
                    NetworkClientUI.anim3ButtonDown = true;
                    break;
                case "anim4":
                    NetworkClientUI.anim4ButtonDown = true;
                    break;
                case "anim5":
                    NetworkClientUI.anim5ButtonDown = true;
                    break;

            }
            NetworkClientUI.SendInfo();
            Debug.Log("Info send Down State");
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
            //sends button information to NetwClient
            switch (Name)
            {
                case "anim0":
                    NetworkClientUI.anim0ButtonDown = false;
                    Debug.Log("Anim 0 unPressed");
                    break;
                case "anim1":
                    NetworkClientUI.anim1ButtonDown = false;
                    Debug.Log("Anim 1 unPressed");
                    break;
                case "anim2":
                    NetworkClientUI.anim2ButtonDown = false;
                    break;
                case "anim3":
                    NetworkClientUI.anim3ButtonDown = false;
                    break;
                case "anim4":
                    NetworkClientUI.anim4ButtonDown = false;
                    break;
                case "anim5":
                    NetworkClientUI.anim5ButtonDown = false;
                    break;

            }
            NetworkClientUI.SendInfo();
            Debug.Log("Info send Up State");
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
