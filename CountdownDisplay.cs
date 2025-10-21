using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CountdownDisplay : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  
    public float countdownTime = 3f;

    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        countdownText.gameObject.SetActive(true);

        int count = (int)countdownTime;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }

        countdownText.text = "START";
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }
}

