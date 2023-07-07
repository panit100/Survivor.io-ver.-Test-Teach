using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class EnemySkillDash : MonoBehaviour
    {
        public float skillCooldownTime = 5f;
        public float dashForce;
        
        Rigidbody2D Rigidbody2D;
        EnemyScript EnemyScript;

        void Start()
        {
            SetComponent();
            InvokeRepeating("EnemyActiveSkill", skillCooldownTime, skillCooldownTime);
        }
        void SetComponent()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            EnemyScript = GetComponent<EnemyScript>();
        }
        void EnemyActiveSkill()
        {
            EnemyDash();
        }

        void EnemyDash()
        {
            Vector2 dashDirection = EnemyScript.playerTransform.position - transform.position;
            Rigidbody2D.AddForce(dashDirection * dashForce);
        }
    }
}
