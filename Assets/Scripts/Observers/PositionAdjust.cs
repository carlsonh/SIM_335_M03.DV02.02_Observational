using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAdjust : MonoBehaviour
{
    private void OnEnable()
    {
        player_movement.OnPlayerXUpdate += UpdateChevronHeight;

    }
    private void OnDisable()
    {
        player_movement.OnPlayerXUpdate -= UpdateChevronHeight;
    }


    void UpdateChevronHeight(float xPos)
    {
        float _fittedSpeed = Map(Mathf.Abs(xPos), 0, 20f, -4.01f, -7f);
        gameObject.transform.position = new Vector3(0, _fittedSpeed, 987); //987: magic for the position as laid out in scene
    }


    private float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
