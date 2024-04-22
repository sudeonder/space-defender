using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    // since enemies also have health, we need to assign the player's health from inspector
    [SerializeField] private Health health;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper scoreKeeper;

    void Awake()
    {
        // since only one scorekeeper exists in the scene, we can use FindObjectOfType
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = health.GetHealth();
    }

    void Update()
    {
        healthSlider.value = health.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
