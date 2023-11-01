using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLoaderMenu : MonoBehaviour
{

    void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
