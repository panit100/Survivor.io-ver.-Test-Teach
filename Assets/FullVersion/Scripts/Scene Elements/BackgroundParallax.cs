using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class BackgroundParallax : MonoBehaviour
    {
        private float length;
        private float startPos;
        public GameObject camera;
        public float parallaxEffectValue;

        void Start()
        {
            SetupComponent();
        }
        void SetupComponent()
        {
            startPos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void FixedUpdate() 
        {
            float temp = (camera.transform.position.x * (1 - parallaxEffectValue));
            float distance = (camera.transform.position.x * parallaxEffectValue);

            transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

            if (temp > startPos + length)
            {
                startPos += length;
            }
            else if (temp < startPos - length)
            {
                startPos -= length;
            }
        }
    }
}
