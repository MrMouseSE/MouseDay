using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuButtonsScripts
{
    public class LeaderBoardButtonsController : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
