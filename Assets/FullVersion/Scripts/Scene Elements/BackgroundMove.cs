using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class BackgroundMove : MonoBehaviour
    {
        public float speed;

        void FixedUpdate()
        {
            MoveBackground();
        }
        void MoveBackground()
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
