using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Berd
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _tapForce = 10f;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _minRotationZ;

        private Vector3 _startPosition;
        private Rigidbody2D _rigidbody2D;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;

        private void Start ()
        {
            _startPosition = transform.position;
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0,0, _minRotationZ);

            ResetBird();
        }

        private void Update ()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _rigidbody2D.velocity = new Vector2(_speed, 0);
                transform.rotation = _maxRotation;
                _rigidbody2D.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation,_minRotation,_rotationSpeed * Time.deltaTime);
        }

        public void ResetBird()
        {
            transform.position = _startPosition;
            transform.rotation = Quaternion.Euler(0,0,0);
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}