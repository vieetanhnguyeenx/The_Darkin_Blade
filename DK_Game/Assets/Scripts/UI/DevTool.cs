using UnityEngine;
using UnityEngine.SceneManagement;

public class DevTool : MonoBehaviour
{

    public void LoadSceneIntro()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSceneDraft()
    {
        SceneManager.LoadScene(18);
    }
    public void LoadSceneMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSceneMap1()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadSceneMap1Boss()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadSceneMap2()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadSceneMap2Boss()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadSceneMap3()
    {
        SceneManager.LoadScene(11);
    }
    public void LoadSceneMap3Boss()
    {
        SceneManager.LoadScene(13);
    }
    public void LoadSceneCredits()
    {
        SceneManager.LoadScene(14);
    }
    public void LoadSceneHowtoPlay()
    {
        SceneManager.LoadScene(15);
    }
    public void LoadSceneInvenroty()
    {
        SceneManager.LoadScene(17);
    }
    public void LoadSceneMapTest()
    {
        SceneManager.LoadScene(19);
    }
}
