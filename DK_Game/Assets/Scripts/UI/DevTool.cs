using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DevTool : MonoBehaviour
{
    [SerializeField]
    private Text tbPassCode;
    [SerializeField]
    private GameObject DevToolContent;
    [SerializeField]
    private GameObject txtMessage;
    [SerializeField]
    private GameObject? PassCodePanel;

    private string passcode = "PRU_Fall23_VietAnh_Nghia_Khang";

    private void Start()
    {
        DevToolContent.SetActive(false);
        PassCodePanel.SetActive(true);
    }
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
    public void btnOkClicked()
    {

        Debug.Log(tbPassCode);
        if (tbPassCode.text == passcode)
        {
            DevToolContent.SetActive(true);

            PassCodePanel.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        }
        else
        {
            txtMessage.GetComponent<Text>().text = "Incorrect Passcode";
            txtMessage.SetActive(true);
        }

    }
}
