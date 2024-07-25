using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.GameControllers;
using UnityEngine;


public class BlockController : SpawnController
{

    [SerializeField]
    private float heightOffset;

    [SerializeField]
    private float pipeSeperationUpperLimit;

    [SerializeField]
    private float pipeSeperationLowerLimit;

    [SerializeField]
    private GameObject upperPipePrefab;

    [SerializeField]
    private GameObject lowerPipePrefab;

    [SerializeField]
    private GameObject scoreCollider;

    private GameObject pipeBlock;

    private void Start() 
    {
        instanciatedPrefabs = new List<GameObject>();

        pipeBlock = new GameObject("PipeBlock");
        pipeBlock.transform.position = new Vector3( -100, -100, -100);
        prefab = GenerateBlock();

        spawnHeight = Random.Range( -heightOffset, heightOffset );
        UpdateSpawnOffset();
        SpawnPrefab();
    }

    private void Update()
    {
        int spawnResult = CheckBoundries();

        if ( spawnResult == 1 ){
            prefab = GenerateBlock();
            spawnHeight = Random.Range( -heightOffset, heightOffset );
        }
    }

    private GameObject GenerateBlock(){

        float pipeSeperation = Random.Range( pipeSeperationLowerLimit, pipeSeperationUpperLimit ) / 2;

        upperPipePrefab.transform.parent = pipeBlock.transform;
        lowerPipePrefab.transform.parent = pipeBlock.transform;
        scoreCollider.transform.parent = pipeBlock.transform;

        upperPipePrefab.transform.localPosition = new Vector3( 0,  pipeSeperation, 0 );
        lowerPipePrefab.transform.localPosition = new Vector3( 0, -pipeSeperation, 0 );
        scoreCollider.transform.localPosition = new Vector3( 0, 0, 0 );

        return pipeBlock;
    }
}