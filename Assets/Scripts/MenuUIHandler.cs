using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        bestScoreText.text = "Best Score: " + SaveDataManager.Instance.BestScoreName + " " + SaveDataManager.Instance.BestScore;
    }
 

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        SaveDataManager.Instance.CurrentName = playerName.text;
    }

    public void ExitGame()
    {
        SaveDataManager.Instance.SaveBestScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
