using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreText;


    private void OnEnable()
    {
        player_movement.OnPlayerZUpdate += UpdateScore;
    }

    private void OnDisable()
    {
        player_movement.OnPlayerZUpdate -= UpdateScore;
    }

    void UpdateScore(float zPos)
    {
        scoreText.text = zPos.ToString("0");
    }
}
