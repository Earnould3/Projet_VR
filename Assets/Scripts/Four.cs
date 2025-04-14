using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Four : MonoBehaviour
{
    public enum EtatFour
    {
        Rien,
        EnChauffage,
        Chaud
    }

    public enum Ouverture
    {
        Ouvert,
        Ferme
    }

    public EtatFour etatActuel = EtatFour.Rien;
    public Ouverture ouverture = Ouverture.Ferme;

    public float tempsPourChaud = 5f;
    private float timer;

    public UnityEvent fourPret;
    public UnityEvent fourOuvert;
    public UnityEvent fourFerme;

    void Update()
    {
        if (etatActuel == EtatFour.EnChauffage)
        {
            timer += Time.deltaTime;
            if (timer >= tempsPourChaud)
            {
                fourPret.Invoke();
                etatActuel = EtatFour.Chaud;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (etatActuel != EtatFour.Chaud) return;

        var chauffable = other.GetComponent<PeutChauffer>();
        if (chauffable != null) chauffable.Chauffer();
    }

    public void Allumer()
    {
        etatActuel = EtatFour.EnChauffage;
        timer = 0f;
    }

    public void OuvrirFermer()
    {
        ouverture = ouverture == Ouverture.Ouvert ? Ouverture.Ferme : Ouverture.Ouvert;
        
        if (ouverture == Ouverture.Ouvert)
        {
            fourOuvert.Invoke();
        }
        else
        {
            fourFerme.Invoke();
        }
    }
}