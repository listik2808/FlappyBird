using Scripts.Berd;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Bird _bird;
        [SerializeField] private TMP_Text _score;

        private void OnEnable()
        {
            _bird.ScoreChanged += onScoreChanged;
        }

        private void OnDisable()
        {
            _bird.ScoreChanged -= onScoreChanged;
        }

        private void onScoreChanged(int score)
        {
            _score.text = score.ToString();
        }
    }
}