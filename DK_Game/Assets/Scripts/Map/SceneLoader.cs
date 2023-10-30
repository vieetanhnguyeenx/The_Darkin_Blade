using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public GameObject loaderUI;
    public Slider progressSlider;

    private bool loadFinished = false;
    public string sceneName;

    void Start()
    {
        LoadSceneWithDelay(sceneName, 10f); // Load scene after 10 seconds
    }

    public void LoadSceneWithDelay(string sceneName, float delay)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName, delay));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        float timer = 0f;
        progressSlider.value = 0;
        loaderUI.SetActive(true);

        // Fill progress bar over a specified delay time
        while (timer < delay)
        {
            timer += Time.deltaTime;
            float progress = timer / delay;
            progressSlider.value = progress;
            yield return null;
        }

        progressSlider.value = 1;

        // Wait for a short moment for the progress bar to show completion (optional)
        yield return new WaitForSeconds(1f);

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }
}
