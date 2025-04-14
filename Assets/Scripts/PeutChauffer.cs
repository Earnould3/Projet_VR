using UnityEngine;
using UnityEngine.Events;

public class PeutChauffer : MonoBehaviour
{
    public UnityEvent onChauffe;

    public void Chauffer()
    {
        onChauffe.Invoke();
    }
}
