using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float MostEnemies{ get; set; }
    public static float MostTime { get; set; }

    public static float EnemyScore;

    public Text ScoreText;
    private void Update()
    {
        VisualizeScore(EnemyScore);
    }

    private void VisualizeScore(float currentScore)
    {

        string text = "Score: " + currentScore;
        ScoreText.text = text;
    }
}
