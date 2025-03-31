using UnityEngine;
using UnityEngine.Events;

public class Four : MonoBehaviour
{
    public UnityEvent<float> OnSpawn;
    
    public void OnFourClicked()
    {
        Debug.Log("Mon four est allumé");
        OnSpawn.Invoke(10);
    }
}