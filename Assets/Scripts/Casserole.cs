using UnityEngine;

public class Casserole : MonoBehaviour
{
    public enum Contenu { Vide, Eau, EauEtPates, Cuit }
    public Contenu contenuActuel = Contenu.Vide;

    public void RemplirEau()
    {
        if (contenuActuel == Contenu.Vide)
            contenuActuel = Contenu.Eau;
    }

    public void AjouterPates()
    {
        if (contenuActuel == Contenu.Eau)
            contenuActuel = Contenu.EauEtPates;
    }

    public void Cuire()
    {
        if (contenuActuel == Contenu.EauEtPates)
            contenuActuel = Contenu.Cuit;
    }
}

