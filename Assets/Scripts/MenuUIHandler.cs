using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text highScoreText;
    public InputField playerNameField;
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance != null)
        {
            highScoreText.text = "High Score: " + DataManager.Instance.highScorePlayerName + ": " + DataManager.Instance.highScore;
            playerNameField.text = DataManager.Instance.currentPlayerName;
        }
    }

    public void StartNew()
    {
        DataManager.Instance.currentPlayerName = playerNameField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
