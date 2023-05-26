using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    public static string playerName;


    private void Awake()
    {
        bestScoreText.text = "Best Score: " + ScoreController.Instance.GetPlayerName() + " " + ScoreController.Instance.GetHighScore();
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void SetPlayerName(string playername)
    {
        playerName = playername;
        Debug.Log(playerName);
    }
}
