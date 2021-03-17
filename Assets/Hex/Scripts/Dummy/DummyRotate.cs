using UnityEngine;

namespace Assets.Hex.Scripts.Dummy
{
    public class DummyRotate : MonoBehaviour
    {
        [SerializeField] private float _rotateAngle;
        
        private void OnMouseDown()
        {
            transform.Rotate( new Vector3(0, _rotateAngle, 0) );
        }
    }
}
