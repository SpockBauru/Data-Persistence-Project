using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text TopScore;

    // Start is called before the first frame update
    public void Start()
    {
        TopScore.text = "Best Score: " + GameManager.TopPlayerName + " : " + GameManager.TopScore;
    }

}
