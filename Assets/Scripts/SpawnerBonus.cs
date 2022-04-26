using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBonus : MonoBehaviour
{

    public GameObject prefab;

    public float spawnRate = 10f;


   private void OnEnable()
    {
        // Réalise le spawn de bonus qui doivent apparaitre dans le jeu 
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        // Annule l'invocation de Spawn()
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject bonus = Instantiate(prefab, transform.position, Quaternion.identity);
        // Génération des objets bonus
        // Faire apparaitre des objets bonus sur le terrain
        bonus.transform.position += Vector3.right * Random.Range(-2.5f, 3f);
    }
}