using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChangeScene : MonoBehaviour
{
    public Text highScoreText;
    public Text playerName;
    // Start is called before the first frame update

    private void Awake()
    {
     
    }
    void Start()
    {
        highScoreText.text = "High Score : " + ScoreManager.Instance.highScorePlayer + " " + ScoreManager.Instance.highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        ScoreManager.Instance.playerName = playerName.text; //This saves the inputted name to the ScoreManager player (says who is currently playing the game)
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        ScoreManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit(); //original code to quit Unity player
#endif
    }
}
