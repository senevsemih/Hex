using Assets.Hex.Scripts.Ball;
using Assets.Hex.Scripts.Managers.Singleton;
using UnityEngine;

namespace Assets.Hex.Scripts.Managers
{
    public class CameraManager : Singleton<CameraManager>
    {
        [SerializeField] private Vector3 _offsetPosition;

        private GameObject _target;
        private GameObject _cameraTransform;
        private const float FollowSpeed = 5f;

        protected override void Awake()
        {
            base.Awake();
            _target = FindObjectOfType<BallController>().gameObject;
            _cameraTransform = FindObjectOfType<Camera>().gameObject;
        }

        public void CameraFollow()
        {
            _cameraTransform.transform.position = Vector3.Lerp(_cameraTransform.transform.position, _target.transform.position + _offsetPosition,
                FollowSpeed * Time.deltaTime);

            _cameraTransform.transform.rotation = Quaternion.Lerp(_cameraTransform.transform.rotation,
                Quaternion.Euler(Vector3.zero), Time.deltaTime * FollowSpeed);
        }
    }
}
