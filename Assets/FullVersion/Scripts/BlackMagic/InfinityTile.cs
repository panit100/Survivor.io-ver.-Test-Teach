using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{
    public class InfinityTile : MonoBehaviour
    {
        Collider2D coll;
        private PlayerScript _playerScript;

        void Awake()
        {
            coll = GetComponent<Collider2D>();
            _playerScript = FindObjectOfType<PlayerScript>();
        }

        void OnTriggerExit2D(Collider2D collision)
        {
        
            if (!collision.CompareTag("Area"))
                return;

            Vector3 playerPos = _playerScript.transform.position;
                Vector3 myPos = transform.position;

                switch (transform.tag) {
                    case "Ground":
                        float diffX = playerPos.x - myPos.x;
                        float diffY = playerPos.y - myPos.y;
                        float dirX = diffX < 0 ? -1 : 1;
                        float dirY = diffY < 0 ? -1 : 1;
                        diffX = Mathf.Abs(diffX);
                        diffY = Mathf.Abs(diffY);

                        if (diffX > diffY) {
                            transform.Translate(Vector3.right * dirX * 40);
                        }
                        else if (diffX < diffY) {
                            transform.Translate(Vector3.up * dirY * 40);
                        }
                        break;
                    case "Enemy":
                        if (coll.enabled) {
                            Vector3 dist = playerPos - myPos;
                            Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
                            transform.Translate(ran + dist * 2);
                        }
                        break;
                    case "Tree":
                        break;
                }
            
        }
    }
}
