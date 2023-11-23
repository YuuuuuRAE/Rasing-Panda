using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConvertScene : MonoBehaviour
{
   public void SceneMove(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
    