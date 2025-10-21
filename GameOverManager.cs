using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject target;
    public GameObject _gameObject;
    public TextMeshProUGUI gameOverText;
    public float waitTime;

    private bool isDestroyed = false;

    void Start()
    {
        _gameObject.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isDestroyed && target == null)
        {
            isDestroyed = true;
            StartCoroutine(GameOver(waitTime));
        }
    }

    IEnumerator GameOver(float seconds)
    {
        float startTime = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < startTime + seconds)
        {
            yield return null;
        }

        _gameObject.gameObject.SetActive(true);
        gameOverText.text = "GameOver";
    }
}
