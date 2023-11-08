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
        [SerializeField]
        private GameObject? Passcode;
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
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (player == null && currentSceneName != "DevToolScene")
            {
                PanelGameOver.SetActive(true);
            }
            if (player == null && currentSceneName == "DevToolScene")
            {
                PanelGameOver.SetActive(false);
                Passcode.SetActive(true);
            }
            if (currentSceneName == "Map03 Boss")
            {
                GameObject Boss = GameObject.FindGameObjectWithTag("Enemy");
                if (Boss == null)
                {
                    Passcode.SetActive(true);
                    GameObject.FindGameObjectWithTag("Victory").GetComponentInChildren<VictoryController>().VictorySound();
                }
            }
        }
        public void btnYesClicked()
        {
            PanelGameOver.SetActive(false);
            if (Passcode != null)
                Passcode.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }

        public void btnNoClicked()
        {
            Panel.SetActive(false);
            if (Passcode != null)
                Passcode.SetActive(false);
        }

        public void ReloadScene()
        {
            PanelGameOver.SetActive(false);
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
