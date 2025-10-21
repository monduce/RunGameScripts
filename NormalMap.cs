using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMap : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public Transform playerTransform;
    public GameObject map;

    void Update()
    {
            map.transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime);

            if (map.transform.position.z < playerTransform.position.z - 500f)
            {
                Destroy(map);
            }
    }
}
