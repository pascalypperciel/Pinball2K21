using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSelector : MonoBehaviour
{
    [SerializeField]
    public Image selector;

    Vector3 initialPos = new Vector3(-150, -198, 0);
    private int d�placement = 50;

    GameObject magnet;
    GameObject earthquake;
    GameObject missile;
    GameObject missileGuid�;
    GameObject slime;
    GameObject hole;
    GameObject move;

    void Start()
    {
        //Pr�paration du s�lecteur
        selector.rectTransform.anchoredPosition = initialPos;

        //Pr�paration de tous les obstacles
        earthquake = gameObject.transform.Find("Earthquake").gameObject;
        magnet = gameObject.transform.Find("Aimant").gameObject;
        missile = gameObject.transform.Find("RocketLauncher").gameObject;
        missileGuid� = gameObject.transform.Find("RocketLauncher").gameObject;
        slime = gameObject.transform.Find("SlimeGun").gameObject;
        hole = gameObject.transform.Find("HolePuncher").gameObject;
        move = gameObject.transform.Find("MovingBumper").gameObject;
        �teindreTout();
        ChangementPosition((int) initialPos.x);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int currentPos = (int) selector.rectTransform.anchoredPosition.x;
            if(currentPos < 150)
            {
                selector.rectTransform.anchoredPosition = new Vector3(currentPos + d�placement, initialPos.y, initialPos.z);
                ChangementPosition(currentPos + d�placement);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int currentPos = (int)selector.rectTransform.anchoredPosition.x;
            if(currentPos > -150)
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
            case -150:
                earthquake.GetComponent<TerrainGenerator>().enabled = true;
                break;
            case -100:
                magnet.GetComponent<Magn�tisme>().enabled = true;
                break;
            case -50:
                missile.GetComponent<NormalMissiles>().enabled = true;
                break;
            case 0:
                missileGuid�.GetComponent<Guid�eMissile>().enabled = true;
                break;
            case 50:
                slime.GetComponent<ImmobilisationBalle>().enabled = true;
                break;
            case 100:
                hole.GetComponent<ObstacleTrou>().enabled = true;
                break;
            case 150:
                move.GetComponent<ObstacleTrou>().enabled = true;
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
        move.GetComponent<MouvementObstacle>().enabled = false;

        //Effacer game objects n�cessaires
        GameObject tigeGuide = GameObject.Find("GuideTige");
        Destroy(tigeGuide);
        GameObject slimeGuide = GameObject.Find("GuideSlime");
        Destroy(slimeGuide);
    }
}
