using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    int vitesse = 1;

    [SerializeField]
    float perlinNoise = 0f;

    [SerializeField]
    float différence = 0.1f;

    [SerializeField]
    float multiplicateur = 0.04f;

    private int nbCubes = 13;
    private float tailleCubes = 0.05f;
    private float diffRangée = 0.101f / 26;
    Material mat = Resources.Load("background", typeof(Material)) as Material;

    private void Update()
    {
        différence = différence + vitesse;
        for(int i = 0; i < nbCubes; i++)
        {
            for(int j = 0; j < 26; j++)
            {
                perlinNoise = Mathf.PerlinNoise(i * différence, j * différence);
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.GetComponent<Renderer>().material = mat;
                gameObject.transform.Rotate(-85, 0, 0);
                gameObject.transform.localScale = new Vector3(tailleCubes, tailleCubes, tailleCubes);
                gameObject.transform.position = new Vector3(i *tailleCubes - 0.26f, perlinNoise * multiplicateur + 1.14f - (j * diffRangée), j * tailleCubes - 0.78f);
                GameObject.Destroy(gameObject,1);
            }
        }
        //DestroyObjects();
    }

    //private void DestroyObjects()
    //{

    //}    



    //[SerializeField]
    //int profondeur = 10;

    //[SerializeField]
    //float largeur;

    //[SerializeField]
    //float longueur;

    //[SerializeField]
    //float intensitéCourbes = 20;

    //[SerializeField]
    //float speed = 1;

    //Vector3 centre;

    //float offsetLargeur = 50f;
    //float offsetLongueur = 50f;
    //float compteur = 0;
    //float rayon = 10f;


    //private void Start()
    //{
    //    Terrain terrain = GetComponent<Terrain>();
    //    largeur = terrain.terrainData.size.x;
    //    longueur = terrain.terrainData.size.z;
    //    centre = GetComponent<Renderer>().bounds.center;
    //    offsetLargeur = Random.Range(0f, 9000f);
    //    offsetLongueur = Random.Range(0f, 9000f);
    //}

    //private void Update()
    //{
    //    Terrain terrain = GetComponent<Terrain>();
    //    terrain.terrainData = GenererTerrain(terrain.terrainData);
    //    compteur = AvancerCompteur();
    //    offsetLargeur = centre.x + Mathf.Cos(compteur) * rayon;
    //    offsetLongueur = centre.y + Mathf.Sin(compteur) * rayon;
    //}

    //float AvancerCompteur()
    //{
    //    if(compteur >= rayon)
    //    {
    //        compteur = -rayon;
    //    }
    //    compteur += Time.deltaTime * speed;
    //    return compteur;
    //}

    //TerrainData GenererTerrain(TerrainData terrainData)
    //{
    //    terrainData.heightmapResolution = (int) largeur + 1;
    //    terrainData.size = new Vector3(largeur, profondeur, longueur);
    //    terrainData.SetHeights(0, 0, GenererHauteurs());
    //    return terrainData;
    //}

    //float[,] GenererHauteurs()
    //{
    //    float[,] hauteurs = new float[(int) largeur, (int) longueur];
    //    for(int i = 0; i < largeur; i++)
    //    {
    //        for(int j = 0; j < longueur; j++)
    //        {
    //            hauteurs[i, j] = CalculerHauteur(i, j);
    //        }
    //    }

    //    return hauteurs;
    //}

    //float CalculerHauteur(int i, int j)
    //{
    //    float x = (float) i / largeur * intensitéCourbes + offsetLargeur;
    //    float y = (float) j / longueur * intensitéCourbes + offsetLongueur;

    //    return Mathf.PerlinNoise(x, y);
    //}
}
