using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public void level1()
    {
        SceneManager.LoadScene("Level1");
        gagahgah();
    }
    public void level2()
    {
        SceneManager.LoadScene("Level2");
        gagahgah();
    }
    public void level3()
    {
        SceneManager.LoadScene("Level3");
        gagahgah();
    }
    public void level4()
    {
        SceneManager.LoadScene("Level4");
        gagahgah();
    }
    public void gagahgah()
    {
        Time.timeScale = 1;
        Builder.builder = false;
        Escape.isInSettings = false;
        Upgrader.IsUpgrading = false;
    }

}
