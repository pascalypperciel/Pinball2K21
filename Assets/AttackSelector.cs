using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSelector : MonoBehaviour
{
    [SerializeField]
    public Image selector;

    Vector3 initialPos = new Vector3(-370, 146.4f, 0);
    private int déplacement = 55;

    GameObject magnet;
    GameObject earthquake;
    GameObject missile;
    GameObject missileGuidé;
    GameObject slime;
    GameObject hole;

    void Start()
    {
        //Préparation du sélecteur
        selector.rectTransform.anchoredPosition = initialPos;

        //Préparation de tous les obstacles
        earthquake = GameObject.Find("Earthquake");
        magnet = GameObject.Find("Aimant");
        missile = GameObject.Find("RocketLauncher");
        missileGuidé = GameObject.Find("RocketLauncher");
        slime = GameObject.Find("SlimeGun");
        hole = GameObject.Find("HolePuncher");
        ÉteindreTout();
        ChangementPosition((int) initialPos.x);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int currentPos = (int) selector.rectTransform.anchoredPosition.x;
            if(currentPos < -85)
            {
                selector.rectTransform.anchoredPosition = new Vector3(currentPos + déplacement, initialPos.y, initialPos.z);
                ChangementPosition(currentPos + déplacement);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int currentPos = (int)selector.rectTransform.anchoredPosition.x;
            if(currentPos > -390)
            {
                selector.rectTransform.anchoredPosition = new Vector3(currentPos - déplacement, initialPos.y, initialPos.z);
                ChangementPosition(currentPos - déplacement);
            }
        }
    }

    void ChangementPosition(int posX)
    {
        ÉteindreTout();
        switch (posX)
        {
            case -410:
                earthquake.GetComponent<TerrainGenerator>().enabled = true;
                break;
            case -345:
                magnet.GetComponent<Magnétisme>().enabled = true;
                break;
            case -280:
                missile.GetComponent<NormalMissiles>().enabled = true;
                break;
            case -215:
                missileGuidé.GetComponent<GuidéeMissile>().enabled = true;
                break;
            case -150:
                slime.GetComponent<ImmobilisationBalle>().enabled = true;
                break;
            case -85:
                hole.GetComponent<ObstacleTrou>().enabled = true;
                break;
        }
    }

    void ÉteindreTout()
    {
        //Désactiver scripts
        earthquake.GetComponent<TerrainGenerator>().enabled = false;
        magnet.GetComponent<Magnétisme>().enabled = false;
        missile.GetComponent<NormalMissiles>().enabled = false;
        missileGuidé.GetComponent<GuidéeMissile>().enabled = false;
        slime.GetComponent<ImmobilisationBalle>().enabled = false;
        hole.GetComponent<ObstacleTrou>().enabled = false;

        //Effacer game objects nécessaires
        GameObject tigeGuide = GameObject.Find("GuideTige");
        Destroy(tigeGuide);
        GameObject slimeGuide = GameObject.Find("GuideSlime");
        Destroy(slimeGuide);
    }
}
