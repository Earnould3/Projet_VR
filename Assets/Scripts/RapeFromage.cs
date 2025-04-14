using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class RapeFromage : MonoBehaviour
{
    public GameObject bolFromageRapePrefab;
    public Transform positionSpawn;
    public UnityEvent fromageRape;
    
    public string fromageTag = "Fromage";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(fromageTag))
        {
            fromageRape.Invoke();
            Destroy(other.gameObject); // supprime le bloc de fromage
            Instantiate(bolFromageRapePrefab, positionSpawn.position, Quaternion.identity);
        }
    }
}
