using UnityEngine;
using UnityEngine.Serialization;

public class Arc : MonoBehaviour
{
    public float arcRadius;
    
    // Define parameters for radius scaling
    public float minAngle = 10f; // Minimum angle to avoid extreme radius for very small angles
    public float maxAngle = 170f; // Maximum angle to limit radius for very large angles
    public float minRadius = 0.5f; // Minimum radius
    public float maxRadius = 2.0f; // Maximum radius
    
    private GameObject _OriginAnchor2d;
    private GameObject _PolarPlane;
    private LineRenderer lineRenderer;

    [FormerlySerializedAs("xOffset")] public float zOffset;


    //test
    Vector3 currentThetaPosition;


    //private Rigidbody activePointPolarRigidbody;

    //
    private Vertex _vertex;
    [SerializeField] private float _meshResolution;

    private void Start()
    {
        _vertex = GetComponentInParent<Vertex>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        DrawArcTest();
    }

    private void DrawArcTest()
    {
        Vector3 midVertex = _vertex.transform.position; // This object's position is the midVertex
        Vector3 rightVertex = _vertex.RightVertex.transform.position;
        Vector3 leftVertex = _vertex.LeftVertex.transform.position;
    
        Vector3 planeNormal = Vector3.Cross(leftVertex - midVertex, rightVertex - midVertex).normalized;
    
        // Calculate the interior angle
        float angle = Vector3.Angle(leftVertex - midVertex, rightVertex - midVertex);
    
        // Calculate dynamic radius based on angle
        float normalizedAngle = (angle - minAngle) / (maxAngle - minAngle);
        arcRadius = Mathf.Lerp(maxRadius, minRadius, normalizedAngle);
        
        int segments = Mathf.RoundToInt(_meshResolution * angle);// More segments = smoother arc
        lineRenderer.positionCount = segments + 1;
    
        Vector3 startDirection = (leftVertex - midVertex).normalized; // Start direction towards leftVertex
    
        for (int i = 0; i <= segments; i++)
        {
            Quaternion segmentRotation = Quaternion.AngleAxis(i * (angle / segments), planeNormal);
            Vector3 arcPoint = midVertex + segmentRotation * startDirection * arcRadius;
    
            arcPoint.z = zOffset;
            
            lineRenderer.SetPosition(i, arcPoint);
        }
    }
}
