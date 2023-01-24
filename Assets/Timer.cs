using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject successText;
    [SerializeField] float maxTime = 5f;
    public float timeLeft;
    public Image timeBar;
    // Start is called before the first frame update
    void Start()
    {
        successText.SetActive(false);
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }
        else {
            successText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
