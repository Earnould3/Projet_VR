using UnityEngine;

public class Robinet : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var casserole = other.GetComponent<Casserole>();
        if (casserole != null && casserole.contenuActuel == Casserole.Contenu.Vide)
        {
            casserole.RemplirEau();
        }
    }
}