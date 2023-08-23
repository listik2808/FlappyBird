using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Berd
{
    [RequireComponent(typeof(BirdMover))]
    public class Bird : MonoBehaviour
    {
        private BirdMover _birdMover;
        private int _score;

        public Action GameOver;
        public Action<int> ScoreChanged;

        private void Start()
        {
            _birdMover = GetComponent<BirdMover>();
        }

        public void ResetPlayer()
        {
            _score = 0;
            ScoreChanged?.Invoke(_score);
            _birdMover.ResetBird();
        }

        public void Die()
        {
            GameOver?.Invoke();
        }

        public void IncreaseScore()
        {
            _score++;
            ScoreChanged?.Invoke(_score);
        }
    }
}