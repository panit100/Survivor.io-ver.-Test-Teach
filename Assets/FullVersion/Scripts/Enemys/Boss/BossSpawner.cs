using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class BossSpawner : MonoBehaviour
    {
        public float spawnOffset = 1f;
        public Transform player;
        [SerializeField] List<BossSetDetail> bossSetList = new List<BossSetDetail>();
        GameObject bossEnemyObject;
        EnemySpawnerPooling EnemySpawner;

        void Start()
        {
            SetupComponent();
        }
        void SetupComponent()
        {
            EnemySpawner = GetComponent<EnemySpawnerPooling>();
        }

        void FixedUpdate()
        {
            SpawnBoss();
        }
        void SpawnBoss()
        {
            foreach(var n in bossSetList)
            {
                if(!n.isSpawned)
                {
                    if(n.bossSpawnTime == EnemySpawner.gameTime)
                    {
                        bossEnemyObject = Instantiate(n.bossPrefab,RandomSpawnPosition(),Quaternion.identity); //spawn enemy with random position function
                        n.isSpawned = true;
                    }
                }
            }
        }


        Vector3 RandomSpawnPosition()
        {
            Vector3 playerPosition = player.position;

            Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

            Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

            return offScreenPosition;
        }

        [System.Serializable]
        public class BossSetDetail
        {
            public GameObject bossPrefab;
            public int bossSpawnTime;
            public bool isSpawned;
        }
    }
}
