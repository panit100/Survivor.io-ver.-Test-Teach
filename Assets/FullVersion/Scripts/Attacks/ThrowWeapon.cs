using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class ThrowWeapon : MonoBehaviour
    {
        public float KillTime;
        private Rigidbody2D thisRigidBody;
        [SerializeField] float damage = 5;
        void Start()
        {
            thisRigidBody = GetComponent<Rigidbody2D>();
            thisRigidBody.AddForce(new Vector2(Random.Range(-1f,1f),1f) * Random.Range(2f,10f),ForceMode2D.Impulse);
        }

        // Update is called once per frame
        void Update()
        {
            KillTime -= Time.deltaTime;
            if (KillTime < 0)
            {
                Destroy(this.gameObject);
            }
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
