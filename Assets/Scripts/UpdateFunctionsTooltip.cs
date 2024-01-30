using TMPro;
using UnityEngine;

public class UpdateFunctionsTooltip : MonoBehaviour
{
    private Vertex _vertex;

    private TextMeshProUGUI _angleText;

    // Expose the MathFunctionType enum to the Unity Editor
    [SerializeField] private MathFunctionType mathFunctionType;

    public enum MathFunctionType
    {
        Sin,
        Cos,
        Tan
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _angleText = GetComponent<TextMeshProUGUI>();
        _vertex = GetComponentInParent<Vertex>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (mathFunctionType)
        {
            case MathFunctionType.Sin:
                // Handle Sin function
                float sinValue = Mathf.Sin(_vertex.Angle * Mathf.Deg2Rad);
                _angleText.text = $"Sin({_vertex.Angle:F0}\u00B0): = {sinValue:F}";
                break;
            case MathFunctionType.Cos:
                // Handle Cos function
                float cosValue = Mathf.Cos(_vertex.Angle * Mathf.Deg2Rad);
                _angleText.text = $"Cos({_vertex.Angle:F0}\u00B0): = {cosValue:F}"; 
                break;
            case MathFunctionType.Tan:
                // Handle Tan function
                float tanValue = Mathf.Tan(_vertex.Angle * Mathf.Deg2Rad);
                _angleText.text = $"Tan({_vertex.Angle:F0}\u00B0): = {tanValue:F}"; 
                break;
            default:
                _angleText.text = "Unknown Function";
                break;
        }
    }
}
