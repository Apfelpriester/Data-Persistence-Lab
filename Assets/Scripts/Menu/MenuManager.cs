using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highscoreTMP;
    public TMP_InputField playerNameInput;

    public void Start()
    {
        if (PersistenceManager.Instance.highPlayer != "")
        {
            highscoreTMP.text = "Best Score : " + PersistenceManager.Instance.highPlayer + " : " + PersistenceManager.Instance.highScore;
        }
        else
        {
            highscoreTMP.text = "Best Score :" + " No High Score Yet!";
        }
    }

    public void GoToGameScene()
    {
        if(playerNameInput.GetComponentInChildren<TMP_InputField>().text != "")
        {
            SceneManager.LoadScene(1);
            PersistenceManager.Instance.newPlayer = playerNameInput.GetComponentInChildren<TMP_InputField>().text;
        }
        else
        {
            playerNameInput.GetComponentInChildren<TMP_Text>().color = Color.red;
        }
        
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        PersistenceManager.Instance.SaveHighscore();
#else
        Application.Quit();
        PersistenceManager.Instance.SaveHighscore();
#endif
    }
}
