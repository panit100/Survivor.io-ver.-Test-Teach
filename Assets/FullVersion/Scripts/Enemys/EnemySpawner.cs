using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class EnemySpawner : MonoBehaviour
    {
        public float spawnOffset = 1f;

        public Transform player;

        public float gameTime;
        public List<EnemySet> enemySet = new List<EnemySet>();
        int enemySetCount;

        public float enemySpawnTime;
        public List<GameObject> enemyList = new List<GameObject>();
        List<GameObject> enemyContainer = new List<GameObject>();
        float enemySpawnAmount; //when start new wave add enemySpawnAmount

        Coroutine spawnSequence;

        void Start()
        {
            enemySpawnAmount = 10;

            InvokeRepeating("SpawnSequence",1f ,1f);
            // spawnSequence = StartCoroutine(SpawnSequence());
        }

        // IEnumerator SpawnSequence()
        // {
        //     GameObject _enemy = enemyList[Random.Range(0,enemyList.Count)];

        //     for(int i = 0; i< enemySpawnAmount; i++)
        //     {
        //         SpawnEnemy(_enemy);
        //     }
            
        //     yield return new WaitForSeconds(enemySpawnTime);

        //     enemySpawnAmount += 5;
        //     spawnSequence = StartCoroutine(SpawnSequence());
        // }

        void SpawnSequence()
        {
            CountTime();
            // CheckSpawnTime();
            CheckSpawnValue();
        }

        void SpawnEnemy(GameObject enemy)
        {
            GameObject _enemy = Instantiate(enemy,RandomSpawnPosition(),Quaternion.identity); //spawn enemy with random position function
            
            enemyContainer.Add(_enemy);
        }

        Vector3 RandomSpawnPosition()
        {
            Vector3 playerPosition = player.position;

            Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

            Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

            return offScreenPosition;
        }
        
        void CountTime()
        {
            gameTime += 1;
        }

        // void CheckSpawnTime()
        // {
        //     CheckSetCountIncrease();
        //     if(enemySet.Count - 1 == enemySetCount)
        //     {
        //         if(gameTime >= enemySet[enemySetCount].timeWave)
        //         {
        //             CheckSpawnValue();
        //         }
        //     }
        //     else
        //     {
        //         if(gameTime >= enemySet[enemySetCount].timeWave 
        //         && gameTime < enemySet[enemySetCount + 1].timeWave)
        //         {
        //             CheckSpawnValue();
        //         }
        //     }
        // }
        
        void CheckSpawnValue()
        {
            // foreach(EnemySet enemySetTemp in enemySet)
            // {
            //     foreach(EnemySetDetail enemySetDetail in enemySetTemp.enemySetDetail)
            //     {
            //         if(gameTime % enemySetDetail.enemySpawnTime == 0)
            //         {
            //             for (int i = 0; i < enemySetDetail.enemySpawnCount ; i++)
            //             {
            //                 SpawnEnemy(enemySetDetail.enemyPrefab);
            //             }
            //         }
            //     }
            // }
        }

        // void CheckSetCountIncrease()
        // {
        //     if(enemySet.Count - 1 == enemySetCount) { return; }
        //     if(gameTime == enemySet[enemySetCount + 1].timeWave)
        //     {
        //         enemySetCount++;
        //     }
        // }

        public void DestroyAllEnemy()
        {
            foreach(GameObject _enemy in enemyContainer)
            {
                Destroy(_enemy);
            }
        }
    }

    [System.Serializable]
    public class EnemySet
    {
        public float timeWave;
        public List<EnemySetDetail> enemySetDetail;
    }

    [System.Serializable]
    public class EnemySetDetail
    {
        // public GameObject enemyPrefab;
        public string enemyTag;
        public int enemySpawnTotal;
        public float enemySpawnEverySecond;
    }
}