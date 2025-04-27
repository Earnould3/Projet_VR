using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class PlatGratin : MonoBehaviour
{
    public enum EtatPlat { Vide, AvecPates, Complet, Cuit }
    public EtatPlat etat = EtatPlat.Vide;
    
    public float tempsDeCuisson = 10f;
    private float timer;

    public string casseroleTag = "Casserole";
    public string fromageTag = "FromageRape";

    public UnityEvent pateAjoutee;
    public UnityEvent fromageAjoutee;
    public UnityEvent theEnd;

    public void AjouterPates()
    {
        if (etat == EtatPlat.Vide)
        {
            etat = EtatPlat.AvecPates;
            pateAjoutee.Invoke();
        }
    }

    public void AjouterFromage()
    {
        if (etat == EtatPlat.AvecPates)
        {
            fromageAjoutee.Invoke();
            etat = EtatPlat.Complet;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(casseroleTag))
        {
            var casserole = other.GetComponent<Casserole>();
            if (casserole != null && casserole.contenuActuel == Casserole.Contenu.Cuit)
            {
                AjouterPates();
            }
        }
        
        if (other.CompareTag(fromageTag))
        {
            Destroy(other.gameObject); // supprime le bloc de fromage
            AjouterFromage();
        }
    }

    public void Cuire()
    {
        if (etat == EtatPlat.Complet)
        {
            timer += Time.deltaTime;
        }
        
        if (etat == EtatPlat.Complet && timer >= tempsDeCuisson)
        {
            etat = EtatPlat.Cuit;
            theEnd?.Invoke();
        }
    }
}
