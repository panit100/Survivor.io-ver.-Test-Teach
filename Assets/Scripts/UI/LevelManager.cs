using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace SurvivorIO_Ver_Test
{    
    public class LevelManager : MonoBehaviour
    {
        public PlayerScript Refplayer;
        public TextMeshProUGUI leveltext;
        public Image levelbar;
        public int MaxLevelCap;
        public UpgradePanel upgradePanel;
        
        private void Start()
        {
            levelbar.fillAmount = 0;
        }

        private void Update()
        {
            leveltext.text = Refplayer.CurrentLevel.ToString();
            UpdateLevelBarMonitor();
        }

        private void UpdateLevelBarMonitor()
        {
        
            if (Refplayer.exp >= MaxLevelCap)
            {
                MaxLevelCap = Mathf.RoundToInt(MaxLevelCap*1.25f) ;
                upgradePanel.SetCard();
                Refplayer.exp = 0;
                Refplayer.CurrentLevel += 1;
                levelbar.fillAmount = 0;
            }
            else
            {
                float exp = Refplayer.exp;
                float fillamount = (exp / MaxLevelCap) ;
                levelbar.fillAmount = fillamount;
            }
            
        }
    }
}
