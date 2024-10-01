using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
     public TMPro.TMP_Text scoretext;
    private GameManager gameManager;
   [TextArea] public string format;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.SetText(string.Format(format, gameManager.score, PlayerPrefs.GetInt("HighScore")));
    }
}
