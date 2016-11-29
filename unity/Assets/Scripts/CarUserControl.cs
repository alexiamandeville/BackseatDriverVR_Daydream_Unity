using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.VR;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
		float v;
		float h;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();


        }


        private void FixedUpdate()
        {

			// pass the input to the car!
			//if (h >= 0.5 && h <= 0.7 || h >= -0.5 && h <= -0.7 ) {
				//h = CrossPlatformInputManager.GetAxis ("Horizontal");
			//}

			//if (h >= 0.5 && h <= 0.7 || h >= -0.5 && h <= -0.7 ) {
				h = GvrController.Orientation.y;
			//}

			v = CrossPlatformInputManager.GetAxis("Vertical");

			if (GvrController.IsTouching) {
				v = 1;
			}

#if !MOBILE_INPUT


            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
