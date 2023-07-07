using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SurvivorIO_Ver_Test
{    
    public class GameOverMenuScript : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void QuitToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}