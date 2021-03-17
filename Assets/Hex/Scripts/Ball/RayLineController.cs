using System.Collections.Generic;
using UnityEngine;

namespace Assets.Hex.Scripts.Ball
{
    public class RayLineController : MonoBehaviour
    {
        [Header("Attributes")] 
        [SerializeField] private float _maxLength;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private bool _isRayReachGoal;

        private int _reflections;

        public bool IsRayReachGoal => _isRayReachGoal;
        public List<GameObject> DummiesList { get; } = new List<GameObject>();
        public LineRenderer LineRen { get; private set; }

        private void Awake()
        {
            LineRen = GetComponent<LineRenderer>();
            _reflections = GameObject.FindGameObjectsWithTag("Dummy").Length;
        }

        private void Update()
        {
            FireRayLine();
        }

        private void FireRayLine()
        {
            var ray = new Ray(transform.position, transform.forward);
            LineRen.positionCount = 1;
            LineRen.SetPosition(0, transform.position);
            var lineLength = _maxLength;

            for (var i = 0; i < _reflections + 1; i++)
            {
                if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo, lineLength, _layerMask))
                {
                    LineRen.positionCount += 1;
                    LineRen.SetPosition(LineRen.positionCount - 1, hitInfo.point);
                    lineLength += Vector3.Distance(ray.origin, hitInfo.point);
                    ray = new Ray(hitInfo.point, Vector3.Reflect(ray.direction, hitInfo.normal));
                    
                    if (!DummiesList.Contains(hitInfo.collider.gameObject))
                    {
                        DummiesList.Add(hitInfo.collider.gameObject);
                    }

                    if (hitInfo.collider.gameObject.CompareTag("Goal"))
                    {
                        _isRayReachGoal = true;
                    }
                }
                else
                {
                    LineRen.positionCount += 1;
                    LineRen.SetPosition(LineRen.positionCount - 1, ray.origin + ray.direction * _maxLength);
                    
                    DummiesList.Clear();
                }
            }
        }
    }
}
