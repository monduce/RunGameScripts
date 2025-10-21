using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float W_moveSpeed;
    public float S_moveSpeed;
    public float A_moveSpeed;
    public float D_moveSpeed;

    public float minX, maxX, minY, maxY;

    void Update()
    {
        float InputX = 0, InputY = 0;

        if (Input.GetKey(KeyCode.W))
        {
            InputY = W_moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            InputY = S_moveSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            InputX = D_moveSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            InputX = A_moveSpeed;
        }

        Vector3 newPosition = transform.position + new Vector3(InputX, InputY, 0f);

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }

    
}
