using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasUIController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
