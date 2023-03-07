using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    [SerializeField] InputField nameField;

    private void Start()
    {
        nameField.text = DataManager.Instance.playerName;
    }

    public void StartGame()
    {
        if (!nameField.text.Equals(string.Empty))
        {
            DataManager.Instance.playerName = nameField.text;
            DataManager.Instance.SaveBestScoreAndName();
            SceneManager.LoadScene("main");
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
