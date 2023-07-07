using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class EnemySkillShootProjectile : MonoBehaviour
    {
        EnemyScript enemyScript;

        public Projectile projectilePrefab;
        
        public float fireRate = 5;

        float tempTime = 0;
        
        void Start() 
        {
            enemyScript = GetComponent<EnemyScript>();
        }

        void FixedUpdate()
        {
            tempTime += Time.deltaTime;

            if(tempTime >= fireRate)
            {
                Shoot();
                tempTime = 0;
            }
        }

        void Shoot()
        {
            Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.damage = enemyScript.enemyDamage;
            projectile.direction = enemyScript.playerTransform.position - transform.position;
        }
    }
}
