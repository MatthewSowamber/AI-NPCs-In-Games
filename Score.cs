using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public static Score instance;

    public TextMeshProUGUI Scoring;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Scoring.text = score.ToString();
    }

    public void AddScore()
    {
        score += 1;

        Scoring.text = score.ToString();
    }
}
