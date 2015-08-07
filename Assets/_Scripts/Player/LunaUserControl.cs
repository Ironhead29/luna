using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        public bool m_Jump;
		public float h;




        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {

			#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("xbox button a");
		     }
			#endif

        }




        private void FixedUpdate()
        {
            // Read the inputs.

			//Works for keyboards and joysticks
			#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
			h = CrossPlatformInputManager.GetAxis("Horizontal");
			// Pass all parameters to the character control script.
			m_Character.Move (h);
			m_Character.Jump (m_Jump);
			m_Jump = false;
			#else
			m_Character.Move (h);
			#endif				

            
        }

		public void leftbuttonpress()
		{
			h = -1;
		}

		public void rightbuttonpress()
		{
			h = 1;
		}

		public void buttonrelease()
		{
			h = 0;
		}


    }
}