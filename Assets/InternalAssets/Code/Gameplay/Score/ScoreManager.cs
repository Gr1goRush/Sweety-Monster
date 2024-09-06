using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bestScoreText;

    [SerializeField] private Text _endScoreText;
    [SerializeField] private Text _endBestScoreText;

    private float _score;
    private float _bestScore;

    private bool _isRecording;

    public float chachedBestScore
    {
        get { return PlayerPrefs.GetFloat("BestScore"); }
        set { PlayerPrefs.SetFloat("BestScore", value); }
    }

    private void Start()
    {
        _bestScore = chachedBestScore;
        _bestScoreText.text = $"Best: {Convert.ToInt16(_bestScore)}";
        _endBestScoreText.text = $"Best: {Convert.ToInt16(chachedBestScore)}";
    }

    public void StartRecord()
    {
        _isRecording = true;
        _score = 0;
    }

    public void StopRecord()
    {
        _isRecording = false;
        if (_bestScore > chachedBestScore)
        {
            chachedBestScore = _bestScore;
        }

        _endScoreText.text = $"Score: {Convert.ToInt16(_score)}";
        _endBestScoreText.text = $"Best: {Convert.ToInt16(_bestScore)}";
    }

    private void Update()
    {
        if (_isRecording && !Settings.GameIsPaused)
        {
            UpdateView();
            _score += Time.deltaTime * 5;
            if (_score > _bestScore) _bestScore = _score;
        }
    }

    private void UpdateView()
    {
        _scoreText.text = $"Score: {Convert.ToInt16(_score)}";
        if (_bestScore <= _score) _bestScoreText.text = $"Best: {Convert.ToInt16(_bestScore)}";
    }
}

