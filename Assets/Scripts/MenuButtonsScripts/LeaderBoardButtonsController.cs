using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuButtonsScripts
{
    public class LeaderBoardButtonsController : MonoBehaviour
    {
        public void MainMenu()
        {
            SceneManager.LoadScene("Start");
        }
        
        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
