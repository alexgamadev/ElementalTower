using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerHUD : MonoBehaviour
{
    public TMP_Text _timerText;

    // Start is called before the first frame update
    void Start()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _timerText.text = $"Time: {GameManager.Instance.GetTimer().GetTimeFormatted()}";
    }
}
