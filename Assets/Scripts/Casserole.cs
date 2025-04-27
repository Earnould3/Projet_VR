using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Casserole : MonoBehaviour
{
    public enum Contenu
    {
        Vide,
        Eau,
        EauEtPates,
        Cuit
    }

    public Contenu contenuActuel = Contenu.Vide;
    
    public string patesTag = "Pates";

    public float tempRemplissage = 5;
    public float tempDeCuisson = 10;
    private float timer;

    public UnityEvent CommenceRemplirEau;
    public UnityEvent FiniRemplirEau;
    public UnityEvent CommenceCuisson;
    public UnityEvent CuissonFinie;
    

    public void RemplirEau()
    {
        Debug.Log("remplissage");
        if (contenuActuel == Contenu.Vide)
        {
            if (timer == 0) CommenceRemplirEau.Invoke();
            
            timer += Time.deltaTime;
            if (timer >= tempRemplissage)
            {
                contenuActuel = Contenu.Eau;
                timer = 0; // Reset the timer after filling
                FiniRemplirEau.Invoke();
            }
        }
    }

    public void Cuire()
    {
        if (contenuActuel == Contenu.EauEtPates)
        {
            if (timer == 0) CommenceCuisson.Invoke();
            timer += Time.deltaTime;
        }

        if (contenuActuel == Contenu.EauEtPates && timer >= tempDeCuisson)
        {
            CuissonFinie.Invoke();
            contenuActuel = Contenu.Cuit;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(patesTag))
        {
            if (contenuActuel == Contenu.Eau)
            {
                Destroy(other.gameObject); // supprime le bloc de pates
                contenuActuel = Contenu.EauEtPates;
            }
        }
    }
}