using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TouchReveal : MonoBehaviour
{
    [SerializeField] private float touchDuration = 2f;
    [SerializeField] private float decayRate = 0.05f;
    [SerializeField] private string visibilityProperty = "_Visibility";

    private XRSimpleInteractable interactable;
    private Material materialInstance;
    private float currentValue = 0f;
    private bool isTouching = false;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        Renderer rend = GetComponent<Renderer>();
        materialInstance = rend.material; // create instance for this object
        
        // force the object to have only one material
        if (rend.materials.Length > 1)
        {
            Material[] materials = new Material[1];
            materials[0] = materialInstance;
            rend.materials = materials;
        }

        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);

        materialInstance.SetFloat(visibilityProperty, currentValue);
    }

    void OnDestroy()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.hoverExited.RemoveListener(OnHoverExit);
    }

    void OnHoverEnter(HoverEnterEventArgs args)
    {
        isTouching = true;
    }

    void OnHoverExit(HoverExitEventArgs args)
    {
        isTouching = false;
    }

    void Update()
    {
        if (isTouching)
        {
            currentValue += Time.deltaTime / touchDuration;
        }
        else
        {
            currentValue -= decayRate * Time.deltaTime;
        }

        currentValue = Mathf.Clamp01(currentValue);
        materialInstance.SetFloat(visibilityProperty, currentValue);
    }
}