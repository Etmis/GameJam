using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private List<string> count = new List<string>();

    [SerializeField]
    private GameObject btn;

    [SerializeField]
    private GameObject panel;

    void Start()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            if (sceneName.Contains("Level"))
            {
                Scene scene = SceneManager.GetSceneByBuildIndex(i);
                count.Add(scene.ToString());
            }
        }
        for (int i = 0; i < count.Count; i++)
        {
            var name = GetLevelName(i);
            GameObject newButton = Instantiate(btn, panel.transform);
            newButton.GetComponent<LevelButton>().SetData(name);
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private string GetLevelName(int i)
    {
        string name = "Level " + (i + 1).ToString();
        return name;
    }

    private void Update()
    {

    }
}
