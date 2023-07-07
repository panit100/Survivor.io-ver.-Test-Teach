using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class UpgradePanel : MonoBehaviour
    {
        [SerializeField] List<UpgradeCard> cards = new List<UpgradeCard>();
        [SerializeField] PlayerWeapon playerWeapon;

        List<BaseAttack> tempRandomAttacks;

        public void SetCard()
        {
            gameObject.SetActive(true);

            RandomUpgradeWeapon();
            
            for(int i = 0; i < cards.Count; i++)
            {
                cards[i].SetCardInfo(tempRandomAttacks[i]);
            }
        }

        void RandomUpgradeWeapon()
        {
            tempRandomAttacks = new List<BaseAttack>();

            for(int i = 0; i < cards.Count; i++)
            {
                BaseAttack randomAttack = playerWeapon.attacks[Random.Range(0,playerWeapon.attacks.Count)];
                
                while(tempRandomAttacks.Count < cards.Count)
                {
                    if(!tempRandomAttacks.Contains(randomAttack))
                        tempRandomAttacks.Add(randomAttack);
                    else
                        randomAttack = playerWeapon.attacks[Random.Range(0,playerWeapon.attacks.Count)];
                }
            }
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }
    }
}
