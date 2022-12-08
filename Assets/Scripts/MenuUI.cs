using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private InputField playerName;
    [SerializeField] private Button button;
    [SerializeField] private Text InsertName;


    // Start is called before the first frame update
    void Start()
    {
        playerName.text = GameManager.TopPlayerName;
        button.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        string name = playerName.text;

        if (name.Length > 0)
        {
            GameManager.Instance.SetPlayerName(playerName.text);
            SceneManager.LoadScene("Game");
        }
        else
        {
            InsertName.gameObject.SetActive(true);
        }
    }
}
