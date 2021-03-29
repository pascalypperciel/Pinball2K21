using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangerScene(string nomScene)
    {
        SceneManager.LoadScene(nomScene);
    }
    public void Quitter()
    {
        Application.Quit();
    }
   /* public void Update()
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "MyObjectName")
                ChangerScene(name);
        }
    }*/

}
