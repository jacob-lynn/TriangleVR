using TMPro;
using UnityEngine;

public class UpdateAngleToolTip: MonoBehaviour
{
    private Vertex _vertex;
    private Arc _arc;
    private Vector3 _vertexPosition; 
    private Vector3 _leftVertexPosition;
    private Vector3 _rightVertexPosition;
    [SerializeField] private float scaleFactor = 1;
    private TextMeshProUGUI _angleText;
    [SerializeField] private Vector3 offSet;
    
    [SerializeField] private float _minAngle = 10f; // Minimum angle to avoid division by zero
    [SerializeField] private float _baseScaleFactor = 1f; // Base value for scale factor
    [SerializeField] private float _minScale = 0.01f;
    [SerializeField] private float _maxScale = 1f;

    // Start is called before the first frame update
    void OnEnable()
    {
        _vertex = GetComponentInParent<Vertex>();
        _arc = GetComponentInChildren<Arc>();
        _angleText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        _vertexPosition = _vertex.transform.position;
        _leftVertexPosition = _vertex.LeftVertex.transform.position;
        _rightVertexPosition = _vertex.RightVertex.transform.position;
        
        // Assuming you have these variables defined as per your arc drawing logic
        float angle = Vector3.Angle(_leftVertexPosition- _vertexPosition, _rightVertexPosition - _vertexPosition);
        Vector3 startDirection = (_leftVertexPosition - _vertexPosition).normalized;
        Vector3 planeNormal = Vector3.Cross(_leftVertexPosition - _vertexPosition, _rightVertexPosition - _vertexPosition).normalized;
    
        // Calculate the midpoint of the arc
        float midAngle = angle / 2;
        Quaternion midRotation = Quaternion.AngleAxis(midAngle, planeNormal);
        Vector3 midArcPoint = _vertexPosition + midRotation * startDirection * scaleFactor;
    
        // Now midArcPoint is the position of the midpoint of the arc
    
        Vector3 newPostion;
        // this.transform.LookAt(_vertex.transform);
        newPostion = midArcPoint + offSet;
        this.transform.position = newPostion;
    
        UpdateText();
    }

    
    private void UpdateText()
    {
        _angleText.text = _vertex.Angle.ToString("F0") + "\u00B0";
    }
    
    

}
