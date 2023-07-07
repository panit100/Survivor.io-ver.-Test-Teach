using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class BasicBullet : MonoBehaviour
    {
        public float BulletSpeed;

        public GameObject Target;
        private Vector2 direction;

        [SerializeField] float damage = 5;
        private void Update()
        {
            LeapToEnemy();
        }

        public void LeapToEnemy()
        {
            if (Target != null)
            {
                direction = Target.transform.position - transform.position;
                transform.Translate((direction * BulletSpeed) * Time.deltaTime);
            }
            else
            {
                transform.Translate((direction * BulletSpeed) * Time.deltaTime);
                DestroyThis();
            }
            ;
        }

        void DestroyThis()
        {
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                //Implement Enemy Taken Damage from player
                col.GetComponent<EnemyScript>().TakeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}
