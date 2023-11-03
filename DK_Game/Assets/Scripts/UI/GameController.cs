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
            PanelGameOver.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }

        public void btnNoClicked()
        {
            Panel.SetActive(false);
        }

        public void ReloadScene()
        {
            PanelGameOver.SetActive(false);
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
