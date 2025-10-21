using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> mapPrefabs;
    public Transform playerTransform;
    public Vector3 spawnOffset = new Vector3(0, 0, 50);
    public float spawnInterval = 5f;
    public float scrollSpeed = 5f;

    public TextMeshProUGUI distanceText;

    private List<GameObject> activeMaps = new List<GameObject>();
    private float traveledDistance = 0f;

    void Start()
    {
        StartCoroutine(SpawnMapRoutine());
    }

    IEnumerator SpawnMapRoutine()
    {
        while (true)
        {
            SpawnMap();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnMap()
    {
        int index = Random.Range(0, mapPrefabs.Count);
        Vector3 spawnPosition = playerTransform.position + spawnOffset;
        GameObject map = Instantiate(mapPrefabs[index], spawnPosition, Quaternion.identity);
        activeMaps.Add(map);
    }

    void Update()
    {
        float frameDistance = scrollSpeed * Time.deltaTime;
        traveledDistance += frameDistance;

        for (int i = activeMaps.Count - 1; i >= 0; i--)
        {
            GameObject map = activeMaps[i];
            map.transform.Translate(Vector3.back * frameDistance);

            if (map.transform.position.z < playerTransform.position.z - 500f)
            {
                Destroy(map);
                activeMaps.RemoveAt(i);
            }
        }

        
        if (distanceText != null)
        {
            distanceText.text = Mathf.FloorToInt(traveledDistance).ToString() + " m";
        }
    }
}
