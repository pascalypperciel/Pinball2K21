using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Balle> balles = new List<Balle>();
    static int numeroBalleDebut = 0;
    Balle balleDebut = new Balle(numeroBalleDebut);
    string sceneFin;
    public void Awake()
    {
        balles.Add(balleDebut);
    }
    public Balle CreerBalle()
    {
        Balle nouvelleBalle = new Balle(balles.Count);
        return nouvelleBalle;
    }
    public void AjouterBalle()
    {
        Balle nouvelleBalle = CreerBalle();
        balles.Add(nouvelleBalle);
    }
    public void EnleverBalle()
    {
        int dernièreBalle;
        dernièreBalle = balles.Count - 1;
        balles.RemoveAt(dernièreBalle);
    }
    public void Update()
    {
        if(PartieTerminee())
            ChangerScene(sceneFin);
    }
    public bool PartieTerminee()
    {
        bool partietermine = false;
        if (balles.Count == 0)
            partietermine = true;
        return partietermine;       
    }
    public void ChangerScene(string nomScene)
    {
        SceneManager.LoadScene(nomScene);
    }
    public void Quitter()
    {
        Application.Quit();
    }
    

    
}
