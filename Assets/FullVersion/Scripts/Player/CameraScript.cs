using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class CameraScript : MonoBehaviour
    {   
        public PlayerScript player;
        
        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
        }
    }
}
