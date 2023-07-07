using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class MagnetItemScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
            EXPItemScript[] expItems = FindObjectsOfType<EXPItemScript>();
            
            foreach(EXPItemScript n in expItems)
            {
                n.GetComponent<EXPItemScript>().isMoveToPlayer = true;
            }

                Destroy(this.gameObject);
            }
        }
    }
}
