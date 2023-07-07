using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class EXPItemScript : MonoBehaviour
    {
        int expAmount = 10;
        PlayerScript player;

        public bool isMoveToPlayer = false; 

        void Start() 
        {
            player = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();    
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
                player.exp += expAmount;

                Destroy(this.gameObject);
            }
        }

        private void FixedUpdate() 
        {
            if(isMoveToPlayer)
                LeapToPlayer();
        }

        public void LeapToPlayer()
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position,0.1f);
        }
    }
}
