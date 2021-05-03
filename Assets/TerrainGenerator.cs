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
    Material mat;

    private void Start()
    {
        mat = Resources.Load("background", typeof(Material)) as Material;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            différence = différence + vitesse;
            for (int i = 0; i < nbCubes; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    perlinNoise = Mathf.PerlinNoise(i * différence, j * différence);
                    GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    gameObject.GetComponent<Renderer>().material = mat;
                    gameObject.transform.Rotate(-85, 0, 0);
                    gameObject.transform.localScale = new Vector3(tailleCubes, tailleCubes, tailleCubes);
                    gameObject.transform.position = new Vector3(i * tailleCubes - 0.26f, perlinNoise * multiplicateur + 1.14f - (j * diffRangée), j * tailleCubes - 0.78f);
                    GameObject.Destroy(gameObject, 1);
                }
            }
        }
    }
}
