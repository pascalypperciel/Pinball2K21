using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSelector : MonoBehaviour
{
    [SerializeField]
    public Image selector;

    Vector3 initialPos = new Vector3(-370, 146.4f, 0);
    private int d�placement = 55;

    GameObject magnet;
    GameObject earthquake;
    GameObject missile;
    GameObject missileGuid�;
    GameObject slime;
    GameObject hole;

    void Start()
    {
        //Pr�paration du s�lecteur
        selector.rectTransform.anchoredPosition = initialPos;

        //Pr�paration de tous les obstacles
        earthquake = GameObject.Find("Earthquake");
        magnet = GameObject.Find("Aimant");
        missile = GameObject.Find("RocketLauncher");
        missileGuid� = GameObject.Find("RocketLauncher");
        slime = GameObject.Find("SlimeGun");
        hole = GameObject.Find("HolePuncher");
        �teindreTout();
        ChangementPosition((int) initialPos.x);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int currentPos = (int) selector.rectTransform.anchoredPosition.x;
            if(currentPos < -85)
            {
                selector.rectTransform.anchoredPosition = new Vector3(currentPos + d�placement, initialPos.y, initialPos.z);
                ChangementPosition(currentPos + d�placement);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int currentPos = (int)selector.rectTransform.anchoredPosition.x;
            if(currentPos > -390)
            {
                selector.rectTransform.anchoredPosition = new Vector3(currentPos - d�placement, initialPos.y, initialPos.z);
                ChangementPosition(currentPos - d�placement);
            }
        }
    }

    void ChangementPosition(int posX)
    {
        �teindreTout();
        switch (posX)
        {
            case -410:
                earthquake.GetComponent<TerrainGenerator>().enabled = true;
                break;
            case -345:
                magnet.GetComponent<Magn�tisme>().enabled = true;
                break;
            case -280:
                missile.GetComponent<NormalMissiles>().enabled = true;
                break;
            case -215:
                missileGuid�.GetComponent<Guid�eMissile>().enabled = true;
                break;
            case -150:
                slime.GetComponent<ImmobilisationBalle>().enabled = true;
                break;
            case -85:
                hole.GetComponent<ObstacleTrou>().enabled = true;
                break;
        }
    }

    void �teindreTout()
    {
        //D�sactiver scripts
        earthquake.GetComponent<TerrainGenerator>().enabled = false;
        magnet.GetComponent<Magn�tisme>().enabled = false;
        missile.GetComponent<NormalMissiles>().enabled = false;
        missileGuid�.GetComponent<Guid�eMissile>().enabled = false;
        slime.GetComponent<ImmobilisationBalle>().enabled = false;
        hole.GetComponent<ObstacleTrou>().enabled = false;

        //Effacer game objects n�cessaires
        GameObject tigeGuide = GameObject.Find("GuideTige");
        Destroy(tigeGuide);
        GameObject slimeGuide = GameObject.Find("GuideSlime");
        Destroy(slimeGuide);
    }
}
