using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuyaux : MonoBehaviour
{
    //Vitesse entre chaque apparition de tuyau (ajouter de la difficulté au jeu)
    public float vitesse = 5f;
    private float bordGauche;

    private void Start()
    {
        //Initialisation de la variable avec la valeur du bord du screen sur les x (par rapport a la camera principal (main camera))
        bordGauche = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        //Apparition a la position y des tuyaux
        transform.position += Vector3.left * vitesse * Time.deltaTime;

        //On supprime les tuyaux qui ont été dépassé (qui se trouve sur la gauche du screen)
        if (transform.position.x < bordGauche)
        {
            Destroy(gameObject);
        }
    }
}
