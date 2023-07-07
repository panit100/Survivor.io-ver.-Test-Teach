using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class EnemyScript : MonoBehaviour
    {
        public float enemyMoveSpeedDefault;
        float enemyMoveSpeedCurrent;
        public float enemyDamage;

        [HideInInspector] public Transform playerTransform;
        [SerializeField] GameObject expItem;
        [SerializeField] float health = 10;

        [SerializeField] float currentHealth = 10;

        [SerializeField] bool moveToPlayer = true;

        public EnemySpawnerPooling enemySpawner;
        SpriteRenderer Sprite;
        public bool flipModifier;

        void Start()
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
            enemyMoveSpeedCurrent = enemyMoveSpeedDefault;

            SetupComponent();
        }
        public void SetupComponent()
        {
            currentHealth = health;
            Sprite = GetComponent<SpriteRenderer>();
        }

        void FixedUpdate()
        {
            if(moveToPlayer)
                MoveToPlayer();
                CheckEnemyFacing();
        }

        void MoveToPlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, enemyMoveSpeedCurrent);
        }
        void CheckEnemyFacing()
        {
            if(transform.position.x > playerTransform.position.x)
            {
                Sprite.flipX = true;
            }
            else if(transform.position.x < playerTransform.position.x)
            {
                Sprite.flipX = false;
            }
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                Instantiate(expItem,transform.position,Quaternion.identity);
                if(LayerMask.LayerToName(gameObject.layer) != "Boss")
                {
                    enemySpawner.enemyContainer.Remove(this.gameObject);
                }
                gameObject.SetActive(false);
            }
        }

        void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag == "Player")
            {
                other.GetComponent<PlayerScript>().TakeDamage(enemyDamage);
                StopMove();
            }
        }
        void OnTriggerExit2D(Collider2D other) 
        {
            if(other.tag == "Player")
            {
                ContinueMove();
            }
        }

        void StopMove()
        {
            enemyMoveSpeedCurrent = 0;
        }
        void ContinueMove()
        {
            enemyMoveSpeedCurrent = enemyMoveSpeedDefault;
        }
    }
}