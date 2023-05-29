using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YeniUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI newScoreText;
    // Update is called once per frame
    private void Start()
    {
        newScoreText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        newScoreText.text ="Best Score: "+ NewScoreScript.instance.GetHighestScore().ToString() + " made by " + NewScoreScript.instance.GetHighestScorePlayerName();
    }
}
