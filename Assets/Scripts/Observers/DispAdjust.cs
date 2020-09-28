using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispAdjust : MonoBehaviour
{
    public float maxSpeed = 150f;
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        player_movement.OnPlayerSpeedUpdate += UpdateDisp;
    }

    private void OnDisable()
    {
        player_movement.OnPlayerSpeedUpdate -= UpdateDisp;
    }


    Material material;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;//Uniques the mat, which is fine here
    }


    void UpdateDisp(float speed)
    {

        float _speedShutter = Map(speed, 0f, maxSpeed, 1, 0);


        material.SetFloat("Frequency_Div", _speedShutter);


    }





    private float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
