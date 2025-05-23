using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRBaseInteractable))]
public class TouchReveal : MonoBehaviour
{
    [SerializeField] private float touchDuration = 2f;
    [SerializeField] private float decayRate = 0.05f;
    [SerializeField] private string visibilityProperty = "_Visibility";

    private XRBaseInteractable interactable;
    private Material materialInstance;
    private float currentValue = 0f;
    private bool isTouching = false;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        Renderer rend = GetComponent<Renderer>();
        materialInstance = rend.material; // create instance for this object
        
        // force the object to have only one material
            for (int i = 0; i < rend.materials.Length; i++)
            {
                rend.materials[i] = materialInstance;
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

        Renderer rend = GetComponent<Renderer>();
        for (int i = 0; i < rend.materials.Length; i++)
        {
            rend.materials[i].SetFloat(visibilityProperty, currentValue);
        }
    }
}