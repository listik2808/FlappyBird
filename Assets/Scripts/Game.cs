using Palmmedia.ReportGenerator.Core;
using Scripts;
using Scripts.Berd;
using Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _generator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClic += OnPlayButtonClic;
        _gameOverScreen.RestartButtonClic += OnRestartButtonClic;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClic -= OnPlayButtonClic;
        _gameOverScreen.RestartButtonClic -= OnRestartButtonClic;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {

        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClic()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClic()
    {
        _gameOverScreen.Close();
        _generator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
