using Scripts.Pipe;
using UnityEngine;

namespace Scripts.Berd
{
    [RequireComponent(typeof(Bird))]
    public class BirdCollisionHandler : MonoBehaviour
    {
        private Bird _bird;

        private void Start ()
        {
            _bird = GetComponent<Bird>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out ScoreZone zone))
                _bird.IncreaseScore();
            else
                _bird.Die();
        }
    }
}