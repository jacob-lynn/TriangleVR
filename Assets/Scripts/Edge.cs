using UnityEngine;

/// <summary>
/// Class representing the edges of a triangle
/// </summary>
public class Edge: MonoBehaviour
{
    // Needs a reference to 2 points
    [SerializeField] private GameObject[] vertices = new GameObject[2];
    private float _initialDistance;

    private void OnEnable()
    {
        _initialDistance = Vector3.Distance(vertices[0].transform.position, vertices[1].transform.position);
    }

    private void Update()
    {
        // float currentDistance = Vector3.Distance(vertices[0].transform.position, vertices[1].transform.position);
        // Vector3 midpoint = (vertices[0].transform.position + vertices[1].transform.position) / 2;

        ScaleEdge();
        // Calculate the target rotation based on the direction to the target
        // Quaternion targetRotation = Quaternion.LookRotation(vertices[1].transform.position - this.transform.position);

        // Calculate the target rotation based on the direction to the target
        // Quaternion targetRotation = Quaternion.LookRotation(vertices[1].transform.position - transform.position, transform.up);

        // Damping factor to control the rotation speed
        // float damping = 0f - Mathf.Exp(-rotationSpeed * Time.deltaTime);

        // Rotate towards the target rotation using Quaternion.RotateTowards
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * damping * Time.deltaTime);


        // Smoothly interpolate towards the target rotation
        // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
        // this.transform.LookAt(vertices[1].transform.position);
        // this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, currentDistance * _scaleFactor);
        // this.transform.position = vertices[0].transform.position;
        

    }

    private void ScaleEdge()
    {
        float currentDistance = Vector3.Distance(vertices[0].transform.position, vertices[1].transform.position);
        // float scaleRatio = currentDistance / _initialDistance; // Calculate the ratio for scaling

        // Adjust the local scale based on the initial distance and current distance
        this.gameObject.transform.localScale = new Vector3(
            this.gameObject.transform.localScale.x,
            _initialDistance,
            this.gameObject.transform.localScale.z
        );

        Vector3 midpoint = (vertices[0].transform.position + vertices[1].transform.position) / 2;
        this.transform.position = midpoint;

        // transform.LookAt(vertices[]);
        // Vector3 rotationDirection = vertices[1].transform.position + vertices[0].transform.position;
        // this.transform.up = rotationDirection;
    }
}