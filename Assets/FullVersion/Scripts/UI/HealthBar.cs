using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SurvivorIO_Ver_Test
{    
    public class HealthBar : MonoBehaviour
    {
        public Image healthBarImage;

        PlayerScript player;

        void Start()
        {
            player = GetComponent<PlayerScript>();
        }

        void Update()
        {
            if(player.currentHealth > 0)
                healthBarImage.fillAmount = player.currentHealth / player.maxHealth;
            else
                healthBarImage.fillAmount = 0;
        }
    }
}
