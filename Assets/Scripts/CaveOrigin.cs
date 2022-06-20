//Cave Origin By Niklas Meisch 16.06.2022
using UnityEngine;

public class CaveOrigin : MonoBehaviour
{
    [SerializeField] private GameObject _cameraRigPrefab;
    [SerializeField] private GameObject _tracker;
    [SerializeField] private Vector3 _caveDimentions = new Vector3(2,2,2);
    [SerializeField] private bool _onStart = true;
   
    private GameObject _origin;
    private GameObject _originOffset;
   
    // Start is called before the first frame update
    void Awake()
    {

        _origin = this.gameObject;
        //create a new empty with name OriginOffset
        _originOffset = new GameObject("originOffset");
        //set its position to the one of the origin
        _originOffset.transform.position = _origin.transform.position;
        //set its rotation to default
        _originOffset.transform.rotation = Quaternion.identity;
        // instantiate the camera rig with the position and rotation of the Origin
        _cameraRigPrefab = Instantiate(_cameraRigPrefab,_origin.transform.position,_origin.transform.rotation);
    }
    private void Start()
    {
        if (_onStart)
        {
            SetCaveOrigin();
        }
        
    }
  
    #region Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position + this.transform.forward,this.transform.position +this.transform.forward*2);
        Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(0, _caveDimentions.y / 2, 0), _caveDimentions); 
    }
    #endregion
    public void SetCaveOrigin()
    {
        //place originOffset and camera Rig at tracker position
        _originOffset.transform.position = _tracker.transform.position;
        _cameraRigPrefab.transform.position = _tracker.transform.position;
        //attatch Camera rig to Tracker
        _cameraRigPrefab.transform.SetParent(_tracker.transform);
        // attatch tracker to origin offset
        _tracker.transform.SetParent(_originOffset.transform);
        // move origin offset the inverse of its current offset to 0,0,0
        // and then move it to the current Origin position
        Vector3 offsetVector =_originOffset.transform.position - _origin.transform.position;
        _originOffset.transform.position = _originOffset.transform.position + (offsetVector * -1);
        // attatch the origin offset to the Origin
        _originOffset.transform.SetParent(_origin.transform);
    }
}
