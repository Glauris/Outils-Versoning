using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingGeneration : MonoBehaviour // Le script utilise du pooling, en gros au lieu d'Instantiate, ca va d�sactiver/activer les gameobjects pour les r�utiliser si besoin
{
    public List<GameObject> prefabsToGenerate = new List<GameObject>(); //Liste des prefabs de sol/plateformes � g�n�rer

    public List<GameObject> terrainGenerated = new List<GameObject>(); //Liste du terrain instanci� au d�but


    [SerializeField]
    Transform generationPoint;

    public int numberOfSpawns;

    private void Awake()
    {
        float xGenerationStart = generationPoint.position.x + 35f;

        for (int i = 0; i < prefabsToGenerate.Count; i++)
        {
            GameObject prefabCreated = Instantiate(prefabsToGenerate[i]);
            prefabCreated.SetActive(false);
            terrainGenerated.Add(prefabCreated);
        }
        for (int j = 0; j < numberOfSpawns; j++)
        {
            GenerateTerrain(terrainGenerated[Random.Range(0, terrainGenerated.Count)], new Vector2(xGenerationStart, generationPoint.position.y));
            Debug.Log(xGenerationStart);
            xGenerationStart += 68;
            
        }
    }

    void GenerateTerrain(GameObject _terrain, Vector2 position)
    {
        _terrain.SetActive(true);
        _terrain.transform.position = position;//Si jamais ca fais spawner la prefab trop haut ou trop bas vous bougez le SpawningRandomPoint du Player l�
        SearchingPrefab(_terrain);
    }

    void SearchingPrefab(GameObject _objectToSearch) //Chercher l'object dans la list des �l�ments spawn�s pour le supprimer de la liste --> le r�cup�rer d�s que le joueur l'aura d�pass� sur le parcours
    {
        for (int i = 0; i < terrainGenerated.Count; i++)
        {
            if(terrainGenerated[i] == _objectToSearch)
            {
                terrainGenerated.Remove(terrainGenerated[i]);
            }
        }
    }

}
