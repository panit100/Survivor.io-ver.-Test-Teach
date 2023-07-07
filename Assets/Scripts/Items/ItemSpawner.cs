using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class ItemSpawner : MonoBehaviour
    {
        public float spawnOffset = 1f;

        public Transform player;

        public List<GameObject> itemList = new List<GameObject>();    

        void Start()
        {
            StartCoroutine(SpawnItem());
        }

        IEnumerator SpawnItem()
        {
            yield return new WaitForSeconds(10f);
            GameObject randomItem = itemList[Random.Range(0,itemList.Count)];

            GameObject _item = Instantiate(randomItem,RandomSpawnPosition(),Quaternion.identity);

            StartCoroutine(SpawnItem());
        }

        Vector3 RandomSpawnPosition()
        {
            Vector3 playerPosition = player.position;

            Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0);

            Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset);

            return offScreenPosition;
        }
    }
}
