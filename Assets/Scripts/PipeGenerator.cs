using UnityEngine;

namespace Scripts
{
    public class PipeGenerator : ObjectPool
    {
        [SerializeField] private GameObject _template;
        [SerializeField] private float _secondBetweenSpawn;
        [SerializeField] private float _maxSpawnPositionY;
        [SerializeField] private float _minSpawnPositionY;

        private float _elapsedTime = 0;

        private void Start ()
        {
            Initialize(_template);
        }

        private void Update ()
        {
            _elapsedTime += Time.deltaTime;

            if(_elapsedTime > _secondBetweenSpawn)
            {
                if(TryGetObject(out GameObject pipe))
                {
                    _elapsedTime = 0;

                    float spawPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                    Vector3 spawnPosition = new Vector3(transform.position.x, spawPositionY, transform.position.z);
                    pipe.SetActive(true);
                    pipe.transform.position = spawnPosition;

                    DisableObjectAbroadScreen();
                }
            }
        }
    }
}