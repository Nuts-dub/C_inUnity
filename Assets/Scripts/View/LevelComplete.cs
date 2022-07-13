using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class LevelComplete : MonoBehaviour
    {
       [SerializeField] public GameObject completLevelUI;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Pause();
            }
        }

        public void Pause()
        {
            completLevelUI.SetActive(true);
            Time.timeScale = 0f;
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
            completLevelUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}