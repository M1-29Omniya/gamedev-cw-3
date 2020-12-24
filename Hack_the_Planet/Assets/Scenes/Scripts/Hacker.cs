using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    int level ;
    string msg;
    string currentScreen = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        msg = "Wecome to Terminal Hacking!";
        ShowMainMenu(msg);
    }

    void ShowMainMenu(string greeting) 
    {
        Terminal.WriteLine(greeting);
    }

    void SetLevel(string selectedLevel)
    {
        switch (selectedLevel)
        {
            case "1":
                level = 1; 
                Terminal.WriteLine("You have selected level " + level); break;
            case "2":
                level = 2;
                Terminal.WriteLine("You have selected level " + level); break;
            default:
                Terminal.WriteLine("You have selected an \"INVALID\" level");break;
        }
        print(level);
    }

    void OnUserInput(string input)
    {
        switch (currentScreen)
        {
            case "MainMenu":
                SetLevel(input);break;
            case "Password":
                break;
        }
    }

    void StartGame()
    {
        currentScreen = "Password";
        Terminal.WriteLine("You have entered level " + level);
    }

}
