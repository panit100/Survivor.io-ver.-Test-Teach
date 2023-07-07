using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SurvivorIO_Ver_Test
{    
    public class PauseMenuScript : MonoBehaviour
    {
        public GameObject PauseGameUIGroup;        // หน้า pause game: พิมค้นหา "Pause Game UI Group" ในช่องค้นหาใน hierarchy
        public PlayerScript Player;

        void Start()
        {
            PauseGameUIGroup.SetActive(false);
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                CheckPauseGame();
            }
        }

        void CheckPauseGame()
        {
            if(Time.timeScale == 1 && Player.currentHealth > 0)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        void PauseGame()
        {
            PauseGameUIGroup.SetActive(true);
            Time.timeScale = 0;                     // Time ใช้จัดการเวลาใน Unity, timeScale ใช้กำหนดเวลาเกม 1 = เวลาปกติ, 0 = หยุดเวลา, 2 = เร็วขึ้นสองเท่า
        }
        public void ResumeGame()
        {
            PauseGameUIGroup.SetActive(false);
            Time.timeScale = 1;                     // Time ใช้จัดการเวลาใน Unity, timeScale ใช้กำหนดเวลาเกม 1 = เวลาปกติ, 0 = หยุดเวลา, 2 = เร็วขึ้นสองเท่า
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void QuitToMenu()
        {
            SceneManager.LoadScene("Main Menu");
            Time.timeScale = 1;
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
