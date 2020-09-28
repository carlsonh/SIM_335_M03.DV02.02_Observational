using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPos : MonoBehaviour
{

    public float zOffset = 0;
    public float xOffset = 0;

    public bool bUpdateZ = true;
    public bool bUpdateX = false;


    private void OnEnable()
    {
        if (bUpdateZ)
            player_movement.OnPlayerZUpdate += UpdateZPos;

        if (bUpdateX)
            player_movement.OnPlayerXUpdate += UpdateXPos;
    }

    private void OnDisable()
    {
        if (bUpdateZ)
            player_movement.OnPlayerZUpdate -= UpdateZPos;

        if (bUpdateX)
            player_movement.OnPlayerXUpdate -= UpdateXPos;
    }



    void UpdateZPos(float zPos)
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, zPos + zOffset);

    }

    void UpdateXPos(float xPos)
    {
        transform.position = new Vector3(xPos + xOffset, transform.position.y, transform.position.z);
    }
}
