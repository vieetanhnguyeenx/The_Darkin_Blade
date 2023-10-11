using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public string[] buttonNames = { "Start Game", "Option", "How to Play", "Credits", "Quit Game" };
    private VisualElement menu;
    enum buttonId
    {
        btnStartGame = 0,
        btnOption = 1,
        btnHowtoPlay = 2,
        btnCredits = 3,
        btnQuitGame = 4,
    }

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        menu = root.Q<VisualElement>("menu");
        CreateButtons();
    }

    void CreateButtons()
    {
        int i = 0;
        foreach (string buttonName in buttonNames)
        {
            Button button = new Button();
            button.name = i++.ToString();
            button.text = buttonName;
            button.AddToClassList("buttonTemplate");
            menu.Add(button);
            button.clicked += () =>
            {
                if (Enum.TryParse(button.name, out buttonId id))
                {
                    switch (id)
                    {
                        case buttonId.btnStartGame:
                            Debug.Log("Start Game");

                            break;
                        case buttonId.btnOption:
                            Debug.Log("Option");

                            break;
                        case buttonId.btnCredits:
                            Debug.Log("Credits");
                            SceneManager.LoadScene("CreditsScene");
                            break;
                        case buttonId.btnHowtoPlay:
                            Debug.Log("How to play");

                            break;
                        case buttonId.btnQuitGame:
                            Debug.Log("Quit Game");
                            // SaveChanges();
                            Application.Quit();
                            break;
                    }
                }
            };

        }
    }
}
