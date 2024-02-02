using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerPoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        text.text = Score.totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas"))
        {_audioSource.Play();
            Destroy(other.gameObject);
            Score.totalScore++;
            text.text = Score.totalScore.ToString();
        }
    }
}
