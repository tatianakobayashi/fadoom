using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text message;
    public Text healthText;
    public Text gameOverText;

    float timer = 0;
    float timeToLive = 5;

    bool dead;
    bool win;

    void Start()
    {
        message.text = "";
        dead = false;
        win = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToLive)
        {
            message.text = "";
        }

        if (dead)
        {
            gameOverText.text = "Game Over!\n Aperte Ctrl+R para reiniciar";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (win)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void PlayerDied()
    {
        dead = true;
    }

    public void setMessage(string text)
    {
        message.text = text;
        timer = 0;
    }

    public void setHealth(string text)
    {
        healthText.text = text;
    }

    public void Victory()
    {
        gameOverText.color = new Color(0, 1, 0, 1);
        gameOverText.text = "Vitória!\n Aperte Ctrl+R para voltar ao menu";
        win = true;
    }

    public bool hasWon()
    {
        return win;
    }

    public void NextScene()
    {
        if(ApplicationModel.currentFloor == 0 && ApplicationModel.cutscene)
        {
            Debug.Log("loading FirstFloorScene");
            SceneManager.LoadScene("FirstFloorScene");
            ApplicationModel.cutscene = false;
        }
        else if (ApplicationModel.currentFloor == 0 && !ApplicationModel.cutscene)
        {
            Debug.Log("loading Cutscene2");
            ApplicationModel.currentFloor = 1;
            SceneManager.LoadScene("Cutscene2");
            ApplicationModel.cutscene = true;
        }
        else if(ApplicationModel.currentFloor == 1 && ApplicationModel.cutscene)
        {
            Debug.Log("loading SecondFloorScene");
            SceneManager.LoadScene("SecondFloorScene");
            ApplicationModel.cutscene = false;
        }
        else if (ApplicationModel.currentFloor == 1 && !ApplicationModel.cutscene)
        {
            Debug.Log("loading Cutscene3");
            ApplicationModel.currentFloor = 2;
            SceneManager.LoadScene("Cutscene3");
            ApplicationModel.cutscene = true;
        }
        else if (ApplicationModel.currentFloor == 2 && ApplicationModel.cutscene)
        {
            Debug.Log("loading BossScene");
            SceneManager.LoadScene("BossScene");
            ApplicationModel.cutscene = false;
        }
        else
        {
            Debug.Log("Already in the last floor");
        }
    }
}
