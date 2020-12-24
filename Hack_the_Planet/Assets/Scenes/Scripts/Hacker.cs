using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    int level ;
    string msg;
    string currentScreen = "MainMenu";

    string[] level1Password = { "Fire","Water","Air","Rock"};
    string[] level2Password = { "Sun", "Moon", "Mars", "Venus" };

    string password;

    // Start is called before the first frame update
    void Start()
    {
        msg = "Wecome to Terminal Hacking!";
        ShowMainMenu(msg);
    }

    void ShowMainMenu(string greeting) 
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("1 for: Nature");
        Terminal.WriteLine("2 for: Planet");
        Terminal.WriteLine("To Restart the Game Write: End Or Stop");
    }

    void SetLevel(string selectedLevel)
    {
        switch (selectedLevel)
        {
            case "1":
                level = 1; 
                StartGame();
                break;
            case "2":
                level = 2;
                StartGame();
                break;
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
                SetLevel(input);
                break;
            case "Password":
                CheckPassword(input);
                break;
            default:
                break;
        }
        if( input == "End"  || input == "Stop")
        {
            ShowMainMenu("The Game has restarted ,Welcome Back!");
            currentScreen = "MainMenu";
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("You got your password right!");
        }
        else
        {
            if (input == "End" || input == "Stop")
            {
                Terminal.ClearScreen();
            }
            else
            {
                if (input == "1")
                {
                    SetLevel(input);
                    //Terminal.WriteLine("You Have entered level 1 again");
                }else
                {
                    if(input == "2")
                    {
                        SetLevel(input);
                    }
                    else
                    {
                        Terminal.WriteLine("You got your password \"WRONG!\"");
                    }
                }
            }
        }
    }

    void StartGame()
    {
        currentScreen = "Password";
        Terminal.WriteLine("You have entered level " + level);
        SetRandomPassword();

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1: 
                password = level1Password[Random.Range(0,level1Password.Length)];
                break;
            case 2: 
                password = level2Password[Random.Range(0, level1Password.Length)];
                break;
            default:
                break;
        }
        Terminal.WriteLine("Figure out the password: "+password.Anagram());
    }
}
