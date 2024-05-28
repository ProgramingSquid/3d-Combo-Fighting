using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Menu : MonoBehaviour
{
    public void SwapMenuLevel(GameObject target)
    {
        gameObject.SetActive(false);
        target.SetActive(true);

    }

    public void LoadALevel(string Level)
    {
        SceneManager.LoadScene(Level, LoadSceneMode.Single);
    }

    public void Quit()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
