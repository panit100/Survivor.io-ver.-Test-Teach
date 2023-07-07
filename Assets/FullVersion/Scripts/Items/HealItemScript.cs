using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class HealItemScript : MonoBehaviour
    {
        int healAmount = 10;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
                PlayerScript player = other.GetComponent<PlayerScript>();
                
                player.Heal(healAmount);
                Destroy(this.gameObject);
            }
        }
    }
}
