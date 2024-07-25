using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.GameControllers
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField]
        protected float spawnOffsetUpperLimit;
        [SerializeField]
        protected float spawnOffsetLowerLimit;

        protected float spawnOfsett;

        [SerializeField]
        protected float spawnDepth;
        
        [SerializeField]
        protected float spawnHeight;

        [SerializeField]
        protected Transform frontSpawnPoint;

        [SerializeField]
        protected Transform rearSpawnPoint;

        [SerializeField]
        protected GameObject prefab;

        protected List<GameObject> instanciatedPrefabs;
        
        protected int CheckBoundries(){

            GameObject lastBlock = instanciatedPrefabs.Last();
            GameObject firstBlock = instanciatedPrefabs.First();
            if ( firstBlock.transform.position.x <= rearSpawnPoint.position.x ){
                DespawnPrefab( firstBlock );
                return -1;
            }
            else if( lastBlock.transform.position.x <= frontSpawnPoint.position.x - spawnOfsett ){
                SpawnPrefab();
                UpdateSpawnOffset();
                return 1;
            }
            else{
                return 0;
            }
        }

        protected void UpdateSpawnOffset(){
            spawnOfsett =  Random.Range( spawnOffsetLowerLimit, spawnOffsetUpperLimit );
        }

        protected void SpawnPrefab(){
            GameObject newBlock = Instantiate( prefab, new Vector3( frontSpawnPoint.position.x, spawnHeight, spawnDepth), Quaternion.identity);
            instanciatedPrefabs.Add( newBlock );
        }

        protected void DespawnPrefab( GameObject block ){
            instanciatedPrefabs.Remove( block );
            Destroy(block);
        }
    }
} 