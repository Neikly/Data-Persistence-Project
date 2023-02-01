using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class StartMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    
    private void Start()
    {
        bestScoreText.text = "Best Score: " + DataPersistence.Instance.PlayerRecordName + " : " + DataPersistence.Instance.Record;
    }

    public void TakeName(string s)
    {
        DataPersistence.Instance.PlayerName = inputField.text;
        Debug.Log(DataPersistence.Instance.PlayerName);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }
}
