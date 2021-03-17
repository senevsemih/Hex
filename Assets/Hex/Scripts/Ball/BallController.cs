using System.Collections;
using System.Collections.Generic;
using Assets.Hex.Scripts.Managers;
using UnityEngine;

namespace Assets.Hex.Scripts.Ball
{
    public class BallController : MonoBehaviour
    {
        private RayLineController _rayLineController;

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _reachDistance;
        [SerializeField] private List<GameObject> _allDummies = new List<GameObject>();
        
        private int _currentPosition = 0;
        
        private bool _isBallMoving;
        private bool _isDragging;
        private const float DragSpeed = 150f;

        private void Awake()
        {
            _rayLineController = GetComponent<RayLineController>();
        }
        
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _isBallMoving = false;
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                _isBallMoving = true;
                _isDragging = false;
                
                _allDummies.AddRange(AllDummies());
            }

            if (_rayLineController.IsRayReachGoal && _isBallMoving)
            {
                BallPath();
                CameraManager.Instance.CameraFollow();
                _rayLineController.LineRen.enabled = false;
            }
            
            if (_isDragging)
            {
                StartDrag();
            }
        }
        
        private void OnMouseDrag()
        {
            _isDragging = true;
        }
        
        private void StartDrag()
        {
            var x = Input.GetAxis("Mouse X") * DragSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.up * -x);
        }

        private void BallPath()
        {
            var distance = Vector3.Distance(_allDummies[_currentPosition].transform.position, transform.position);

            transform.position = Vector3.Lerp(transform.position,
                _allDummies[_currentPosition].transform.position, Time.deltaTime * _moveSpeed);

            if (distance <= _reachDistance)
            {
                _currentPosition++;
            }

            if (_currentPosition >= _allDummies.Count -1)
            {
                UIManager.Instance.ActivateGoalText();
            }
        }

        private IEnumerable<GameObject> AllDummies()
        {
            return _rayLineController.DummiesList;
        }
    }
}
