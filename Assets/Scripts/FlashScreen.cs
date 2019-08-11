using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashScreen : MonoBehaviour
{
    Image flashScreen;
    bool isAlive;
    bool win;

    void Start()
    {
        flashScreen = GetComponent<Image>();
        isAlive = true;
        win = false;
    }

    void Update()
    {
        if (flashScreen.color.a > 0 && isAlive && !win)
        {
            Color invisible = new Color(flashScreen.color.r, flashScreen.color.g, flashScreen.color.b, 0);
            flashScreen.color = Color.Lerp(flashScreen.color, invisible, 5 * Time.deltaTime);
        }
    }

    public void hasWon()
    {
        win = true;
        flashScreen.color = new Color(0, 0, 0, 0.7f);
    }

    public void RevivePlayer()
    {
        isAlive = true;
    }

    public void TookDamage()
    {
        flashScreen.color = new Color(1, 0, 0, 0.8f);
    }

    public void PlayerDied()
    {
        isAlive = false;
        flashScreen.color = new Color(0, 0, 0, 0.8f);
    }

    public void TakeHeal()
    {
        flashScreen.color = new Color(0, 1, 0, 0.8f);
    }
}
