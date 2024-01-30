using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Keeps track of angle
/// Draws the angle arc
/// </summary>
public class Vertex : MonoBehaviour
{

       public bool IsFunctionsTooltipActive { get; set; }
       private float _angle;

       private Triangle _triangle;

       private float _lockedXValue = -1.66f;
       
       private Vector3 _initialControllerOffset;

       private XRGrabInteractable _interactable;
       private XRBaseInteractor _interactor;
       
       [SerializeField] private GameObject leftVertex;
       [SerializeField] private GameObject rightVertex;
       private GameObject _functionsTooltip;

       public GameObject LeftVertex => leftVertex;

       public GameObject RightVertex => rightVertex;

       public void ToggleVertexFunctionsTooltip(bool value)
       {
           _functionsTooltip.SetActive(value);
           IsFunctionsTooltipActive = value;

       }

       private void Start()
       {
           _interactable = GetComponent<XRGrabInteractable>();
           _triangle = GetComponentInParent<Triangle>();
           _functionsTooltip = transform.Find("Affordance Callout").gameObject;
                     
       }

       public float Angle => _angle;

       private void Update()
       {
           UpdateVertexAngle();

       }
       
       private void UpdateVertexAngle()
       {
           Vector3 pointA =  leftVertex.transform.position - this.transform.position;
           Vector3 pointB =  rightVertex.transform.position - this.transform.position;
           
           _angle = Vector3.Angle(pointA, pointB);
       }

       /// <summary>
       /// Method for to calculate the vertex vector relative to this vertex.
       /// </summary>
       /// <param name="targetVertex"> The target vertex. </param>
       /// <returns></returns>
       private Vector3 CalculateVertexVector(GameObject targetVertex)
       {
           return targetVertex.transform.position - this.transform.position;
       }


}