using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GameControllers;
using UnityEngine;

public class CloudController : SpawnController
{
    [SerializeField]
    private float heightUpperBound;    

    [SerializeField]
    private float heightLowerBound;

    [SerializeField]
    List<GameObject> cloudTypes;
    

    // Start is called before the first frame update
    void Start()
    {
        instanciatedPrefabs = new List<GameObject>();
        DecideCloudType();
        UpdateSpawnOffset();
        SpawnPrefab();
    }

    void Update()
    {
        spawnHeight = GetRandomHeight();
        DecideCloudType();
        CheckBoundries();
    }

    private int GetRandomIndex(){
        return Random.Range( 0, cloudTypes.Count );
    }

    private float GetRandomHeight(){
        return Random.Range( heightLowerBound, heightUpperBound );
    }

    private void DecideCloudType()
    {
        prefab = cloudTypes[ GetRandomIndex() ];
    }
}