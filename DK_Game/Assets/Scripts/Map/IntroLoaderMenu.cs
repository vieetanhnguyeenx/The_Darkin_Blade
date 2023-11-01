using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroLoaderMenu : MonoBehaviour
{
    public Button btnPressAnyKey;
    public Button btnSkip;
    private void Update()
    {
        if (Input.anyKey) // 0 represents the left mouse button
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void LoadMainMenu()
    {
        btnPressAnyKey.gameObject.SetActive(true);
        btnSkip.gameObject.SetActive(false);
    }

    public void clickBtnPressAnykey()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
