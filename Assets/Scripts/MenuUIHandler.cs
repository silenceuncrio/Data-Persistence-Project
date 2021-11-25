using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif



public class MenuUIHandler : MonoBehaviour
{
    public Text BestScoreText;
    TMP_InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        playerNameInput = GameObject.Find("PlayerName").GetComponent<TMP_InputField>();
        BestScoreText.text = $"Best Score : {DataManager.Instance.BestPlayerName} : {DataManager.Instance.BestScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PlayerNameEndEdited()
    {
        DataManager.Instance.PlayerName = playerNameInput.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("Exit");
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }




}
