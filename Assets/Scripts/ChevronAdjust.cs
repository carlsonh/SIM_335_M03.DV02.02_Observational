using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChevronAdjust : MonoBehaviour
{


    public bool bUpdateShutter = true;
    public bool bUpdateAngle = false;

    public float maxSpeed = 150f;
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


        float _speedShutter = Mathf.Min(1, (speed / maxSpeed) + 0.3f);//Roughly remap speed to 0-1 range //and subtract an epsilon to fix FXAA issues
        float _speedAngle = speed - 80f;


        if (bUpdateShutter)
        {
            material.SetFloat("chevron_size", _speedShutter);
        }
        if (bUpdateAngle)
        {
            material.SetFloat("chevron_angle", _speedAngle);
        }
    }
}
