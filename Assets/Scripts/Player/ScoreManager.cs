using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerScore;
    [SerializeField] TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + playerScore;
    }
}
