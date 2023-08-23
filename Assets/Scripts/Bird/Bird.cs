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

        private void Start()
        {
            _birdMover = GetComponent<BirdMover>();
        }

        public void ResetPlayer()
        {
            _score = 0;
            _birdMover.ResetBird();
        }

        public void Die()
        {
            Debug.Log("Умер");
            Time.timeScale = 0;
        }

        public void IncreaseScore()
        {
            _score++;
        }
    }
}