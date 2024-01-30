using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Triangle class
/// Responsible for drawing the triangle mesh and keeping track of vertices and edges
/// Keeps track of selected vertex
/// </summary>
public class Triangle : MonoBehaviour
{
    

    [SerializeField] private GameObject[] vertexGameObjects;

    private bool _vertexGrabbed;
    private GameObject _selectedVertex;
    private Vector3[] _vertexPositions;
    
    // 1 Selected Vertex
    // Constraints: Angles must sum to 180
    private LineRenderer lineRenderer;
    private float _meshResolution;

    // Mesh Stuff
    MeshFilter triangleMeshFilter;
    Mesh triangleMesh;
    GameObject _ArcMesh;
    private Vector3 _selectedVertexLocalPosition;
    private Vector3 _normalVector;
    private Vertex _vertex1;
    private Vertex _vertex2;
    private Vertex _vertex3;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            vertexGameObjects[i].GetComponent<XRGrabInteractable>().selectEntered.AddListener(StartGrab);
            vertexGameObjects[i].GetComponent<XRGrabInteractable>().selectExited.AddListener(EndGrab);
            
            vertexGameObjects[i].GetComponent<Vertex>().ToggleVertexFunctionsTooltip(false);
        }
        
        triangleMeshFilter = this.gameObject.GetComponent<MeshFilter>();
        triangleMesh = new Mesh();
        triangleMesh.name = "Triangle Mesh";
        triangleMeshFilter.mesh = triangleMesh;
    }

    private void StartGrab(SelectEnterEventArgs e)
    {
        _selectedVertex = e.interactableObject.transform.gameObject;
        _selectedVertex.GetComponent<Vertex>().ToggleVertexFunctionsTooltip(true);

        for (int i = 0; i < 3; i++)
        {
            if (vertexGameObjects[i] != _selectedVertex)
            {
                vertexGameObjects[i].GetComponent<Vertex>().ToggleVertexFunctionsTooltip(false);
            }
        }

    }
    
    private void EndGrab(SelectExitEventArgs arg0)
    {
        // for (int i = 0; i < 3; i++)
        // {
        //     if (vertexGameObjects[i].GetComponent<Vertex>().IsFunctionsTooltipActive)
        //     {
        //         return;
        //     }
        //     else
        //     {
        //         vertexGameObjects[i].GetComponent<Vertex>().ToggleVertexFunctionsTooltip(false);
        //     }
        // }
    }

    private void Update()
    {
        DrawTriangleMesh();
        CalculateNormalVector();
    }

    private void CalculateNormalVector()
    {
        // Get the normal vector of the triangle's plane
       _normalVector = Vector3.Cross((vertexGameObjects[1].transform.position - vertexGameObjects[0].transform.position), 
                                                (vertexGameObjects[2].transform.position - vertexGameObjects[0].transform.position))
                                                    .normalized;
    }

    private Vector3[] GetVertexPositions(GameObject[] vertices)
    {
        Vector3[] localVertexPositions = new Vector3[3];
        
        for (int i = 0; i < 3; i++)
        {
            localVertexPositions[i] = vertices[i].transform.position - this.transform.position;
        }

        return localVertexPositions;
    }

    private void DrawTriangleMesh()
    {
        int[] _triangleArray = new int[]{ 0, 2, 1 };
        
        triangleMesh.Clear();
        triangleMesh.vertices = GetVertexPositions(vertexGameObjects);
        triangleMesh.triangles = _triangleArray;
        triangleMesh.RecalculateNormals();
    }
   
}

