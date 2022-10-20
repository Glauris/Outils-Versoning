using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingGeneration : MonoBehaviour // Le script utilise du pooling, en gros au lieu d'Instantiate, ca va désactiver/activer les gameobjects pour les réutiliser si besoin
{
    public List<GameObject> prefabsToGenerate = new List<GameObject>(); //Liste des prefabs de sol/plateformes à générer

    public List<GameObject> terrainGenerated = new List<GameObject>(); //Liste du terrain instancié au début

    public List<GameObject> prefabsOnGame = new List<GameObject>();

    GameObject lastPlatform;

    GameObject actualPlateform;

    int prefabID = 0;

    float xGenerationStart;


    [SerializeField]
    Transform generationPoint;

    public int numberOfSpawns;

    private void Awake()
    {
        xGenerationStart = generationPoint.position.x + 30f;

        for (int i = 0; i < prefabsToGenerate.Count; i++)
        {
            GameObject prefabCreated = Instantiate(prefabsToGenerate[i]);
            prefabCreated.SetActive(false);
            terrainGenerated.Add(prefabCreated);
        }
        for (int j = 0; j < numberOfSpawns; j++)
        {
            GenerateTerrain(terrainGenerated[Random.Range(0, terrainGenerated.Count)], new Vector2(xGenerationStart, 0));
            Debug.Log(xGenerationStart);
            xGenerationStart += 55;
            
        }
    }

    void GenerateTerrain(GameObject _terrain, Vector2 position)
    {
        _terrain.SetActive(true);
        _terrain.transform.position = position;//Si jamais ca fais spawner la prefab trop haut ou trop bas vous bougez le SpawningRandomPoint du Player là
        SearchingPrefab(_terrain);
        prefabsOnGame.Add(_terrain);
        prefabID += 1;
    }

    void SearchingPrefab(GameObject _objectToSearch) //Chercher l'object dans la list des éléments spawnés pour le supprimer de la liste
    {
        for (int i = 0; i < terrainGenerated.Count; i++)
        {
            if(terrainGenerated[i] == _objectToSearch)
            {
                terrainGenerated.Remove(terrainGenerated[i]);
            }
        }
    }

    public void PoolingPlatform(GameObject _platform)
    {
        actualPlateform = _platform;
        for (int i = 2; i < prefabsOnGame.Count; i++)
        {
            if (prefabsOnGame[i] == actualPlateform)
            {
                lastPlatform = prefabsOnGame[i - 2];
                lastPlatform.SetActive(false);
                prefabsOnGame.Remove(lastPlatform);
                terrainGenerated.Add(lastPlatform);
                GenerateTerrain(terrainGenerated[Random.Range(0, terrainGenerated.Count)], new Vector2(xGenerationStart, 0));
                Debug.Log(xGenerationStart);
                xGenerationStart += 55;
            }
        }
    }
}
