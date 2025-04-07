using UnityEngine;

public class RapeFromage : MonoBehaviour
{
    public GameObject bolFromageRapePrefab;
    public Transform positionSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fromage"))
        {
            Destroy(other.gameObject); // supprime le bloc de fromage
            Instantiate(bolFromageRapePrefab, positionSpawn.position, Quaternion.identity);
        }
    }
}
