using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class Projectile : MonoBehaviour
    {   
        public float speed = 10;
        [HideInInspector]
        public float damage;

        [HideInInspector]
        public Vector3 direction;

        void Start() 
        {
            StartCoroutine(DestroyProjectile());    
        }

        void FixedUpdate() 
        {
            transform.position = transform.position + (direction.normalized * speed * Time.deltaTime) ;
        }

        IEnumerator DestroyProjectile()
        {
            yield return new WaitForSeconds(5f);
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
                other.GetComponent<PlayerScript>().TakeDamage(damage);
                Destroy(this.gameObject);
            }    
        }
    }
}
