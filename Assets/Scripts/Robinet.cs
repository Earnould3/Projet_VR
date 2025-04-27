using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Robinet : MonoBehaviour
{
    public bool allume = false;
    public UnityEvent onEauActive;
    public UnityEvent onEauInactive;

    private void Start()
    {
        if (allume) onEauActive?.Invoke();
    }

    public void Allumer(bool value)
    {
        if (value) onEauActive?.Invoke();
        else onEauInactive?.Invoke();
        allume = value;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (!allume) return;
        
        var casserole = other.GetComponent<Casserole>();
        if (casserole != null && casserole.contenuActuel == Casserole.Contenu.Vide)
        {
            casserole.RemplirEau();
        }
    }
}