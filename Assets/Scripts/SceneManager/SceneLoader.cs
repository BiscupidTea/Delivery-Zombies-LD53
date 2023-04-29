using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [ContextMenu("Load Scene")]
    public void LoadLevel(int levelBuildIndex)
    {
        SceneManager.LoadScene(levelBuildIndex);
    }

    [ContextMenu("Load Scene Additive")]
    public void LoadLevelAdditive(int levelBuildIndex)
    {
        SceneManager.LoadScene(levelBuildIndex, LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
