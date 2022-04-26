using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    //Vitesse paramètrale de l'avancement sur la map (vitesse du jeu)
    public float vitesseAnimation = 1f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //On ajoute la vitesse precedemment definis au material sur les x (on met 0 car on ne veut rien bouger sur les y)
        meshRenderer.material.mainTextureOffset += new Vector2(vitesseAnimation * Time.deltaTime, 0);
    }

}