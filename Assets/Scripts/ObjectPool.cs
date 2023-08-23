using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;

        private List<GameObject> _pool = new List<GameObject>();

        protected void Initialize(GameObject prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                GameObject spawned = Instantiate(prefab, _container.transform);
                spawned.SetActive(false);
                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => p.activeSelf == false);

            return result != null;
        }

        protected void DisableObjectAbroadScreen()
        {
            Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f));

            foreach (GameObject obj in _pool)
            {
                if(obj.activeSelf == true)
                {
                    if(obj.transform.position.x < disablePoint.x)
                        obj.SetActive(false);
                }
            }
        }

        public void ResetPool()
        {
            foreach (var pool in _pool)
            {
                pool.SetActive(false);
            }
        }
    }
}