using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    internal class GameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject Panel;
        [SerializeField]
        private GameObject PanelGameOver;
        private GameObject player;
        private void Start()
        {
            Panel.SetActive(false);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                Panel.SetActive(true);
            }
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                PanelGameOver.SetActive(true);
            }
        }
        public void btnYesClicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }

        public void btnNoClicked()
        {
            Panel.SetActive(false);
            Time.timeScale = 1;
        }

        public void ReloadScene()
        {
            PanelGameOver.SetActive(false);
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
