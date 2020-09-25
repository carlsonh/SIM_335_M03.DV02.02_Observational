using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeAdjust : MonoBehaviour
{
    private void OnEnable()
    {
        player_movement.OnPlayerZUpdate += UpdatePipePos;
    }

    private void OnDisable()
    {
        player_movement.OnPlayerZUpdate -= UpdatePipePos;
    }



    void UpdatePipePos(float zPos)
    {


        transform.position = new Vector3(0, 0, zPos + 50);
    }
}
