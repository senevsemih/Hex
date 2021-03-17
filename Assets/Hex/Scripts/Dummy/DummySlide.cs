using UnityEngine;

namespace Assets.Hex.Scripts.Dummy
{
    public class DummySlide : MonoBehaviour
    {
	    private Vector3 _distance;
	    private Vector3 _startPosition;
	    private float _positionX;
	    private float _positionY;
	    private float _positionZ;
	    
	    private void OnMouseDown()
	    {
		    _startPosition = transform.position;
		    _distance = Camera.main.WorldToScreenPoint(transform.position);
		    _positionX = Input.mousePosition.x - _distance.x;
		    _positionY = Input.mousePosition.y - _distance.y;
		    _positionZ = Input.mousePosition.z - _distance.z;
	    }
 
	    private void OnMouseDrag()
	    {
		    float distanceX = Input.mousePosition.x - _positionX;
		    float distanceY = Input.mousePosition.y - _positionY;
		    float distanceZ = Input.mousePosition.z - _positionZ;
		    Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(distanceX, distanceY, distanceZ));
		    transform.position = new Vector3(lastPos.x, _startPosition.y, lastPos.z);
	    }
    }
}
