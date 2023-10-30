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
    public float time;

    void Start()
    {
        LoadSceneWithDelay(sceneName, time); 
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

        
        while (timer < delay)
        {
            timer += Time.deltaTime;
            float progress = timer / delay;
            progressSlider.value = progress;
            yield return null;
        }

        progressSlider.value = 1;

        
        yield return new WaitForSeconds(0f);

       
        SceneManager.LoadScene(sceneName);
    }
}
