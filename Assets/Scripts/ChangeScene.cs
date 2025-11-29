using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int Scene_Index;

    public void LoadScene()
    {
        if (Scene_Index >= 0 && Scene_Index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(Scene_Index);
        }
    }
}
