using UnityEngine;

public class PlatGratin : MonoBehaviour
{
    public enum EtatPlat { Vide, AvecPates, Complet, Cuit }
    public EtatPlat etat = EtatPlat.Vide;

    public void AjouterPates()
    {
        if (etat == EtatPlat.Vide)
            etat = EtatPlat.AvecPates;
    }

    public void AjouterFromage()
    {
        if (etat == EtatPlat.AvecPates)
            etat = EtatPlat.Complet;
    }

    public void Cuire()
    {
        if (etat == EtatPlat.Complet)
            etat = EtatPlat.Cuit;
    }
}
