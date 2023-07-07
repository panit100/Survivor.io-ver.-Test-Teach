using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class PlayerScript : MonoBehaviour
    {
        [Header("Movement")]
        public float speed = 10f;
        Vector3 direction;

        [Header("HP")]
        public float maxHealth = 10f;
        public float currentHealth = 0f;

        [Header("LEVEL")]
        public int exp = 0;
        public int CurrentLevel = 1;

        [Header("GameOver")]
        public GameObject canvasGameOver;
        bool isPlayerGameOver = false;
        
        [Header("PlayerComponent")]
        public Animator animator;
        public AudioSource audio;

        void Start()
        {
            Time.timeScale = 1;

            currentHealth = maxHealth;
        }

        void FixedUpdate()
        {
            Move();
            MoveAnimation();
            MoveSound();
            CheckHP();
        }

        void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            direction = new Vector2(horizontal,vertical).normalized;

            transform.Translate(direction * speed * Time.deltaTime);
        }

        void MoveSound()
        {
            if(direction == Vector3.zero)
            {
                animator.Play("Idle");
                audio.Stop();
                return;
            }

            if(!audio.isPlaying)
                audio.Play();
        }

        void MoveAnimation()
        {
            if(direction.x > 0)
                animator.Play("WalkRight");
            else if(direction.x < 0)
                animator.Play("WalkLeft");
            else
                animator.Play("WalkDown");
        }

        public void Heal(float amount)
        {
            currentHealth += amount;

            if(currentHealth > maxHealth)
                currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
        }

        void CheckHP()
        {
            if(isPlayerGameOver == false && currentHealth <= 0)
            {
                GameOver();
            }
        }

        void GameOver()
        {
            isPlayerGameOver = true;
            Instantiate(canvasGameOver);
            Time.timeScale = 0;
        }
    }
}
