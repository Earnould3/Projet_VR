using UnityEngine;
using UnityEngine.Events;

public class Four : MonoBehaviour
{
    public enum EtatFour { Rien, EnChauffage, Chaud }
    public enum Ouverture { Ouvert, Ferme }

    public EtatFour etatActuel = EtatFour.Rien;
    public Ouverture ouverture = Ouverture.Ferme;

    public float tempsPourChaud = 5f;
    private float timer;

    void Update()
    {
        if (etatActuel == EtatFour.EnChauffage)
        {
            timer += Time.deltaTime;
            if (timer >= tempsPourChaud)
            {
                etatActuel = EtatFour.Chaud;
                ChaufferObjetsDedans();
            }
        }
    }

    void ChaufferObjetsDedans()
    {
        foreach (Transform obj in transform)
        {
            var chauffable = obj.GetComponent<PeutChauffer>();
            if (chauffable != null) chauffable.Chauffer();
        }
    }

    public void Allumer()
    {
        etatActuel = EtatFour.EnChauffage;
        timer = 0f;
    }

    public void OuvrirFermer()
    {
        ouverture = ouverture == Ouverture.Ouvert ? Ouverture.Ferme : Ouverture.Ouvert;
    }
}
