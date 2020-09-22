using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChevronAdjust : MonoBehaviour
{
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        player_movement.OnPlayerSpeedUpdate += UpdateChevron;
    }

    private void OnDisable()
    {
        player_movement.OnPlayerSpeedUpdate -= UpdateChevron;
    }



    Material material;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;//Uniques the mat, which is fine here
    }

    void UpdateChevron(float speed)
    {
        //Debug.Log("FixedUpdate kinda sucks");

        float _speed = Mathf.Min(1, speed / 150f);//Roughly remap speed to 0-1 range
        material.SetFloat("chevron_size", _speed);
    }
}
