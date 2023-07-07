using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorIO_Ver_Test
{    
    public class HitEffect : MonoBehaviour
    {
        [SerializeField]private float timeloop;
        private float temptime;

        private ParticleSystem thiseffect;
        // Start is called before the first frame update
        void Start()
        {
            thiseffect = GetComponent<ParticleSystem>();
            temptime = timeloop;
        }

        // Update is called once per frame
        void Update()
        {
            temptime -= Time.deltaTime;
            if (temptime <= 0)
            {
                thiseffect.Play();
                temptime = timeloop;
            }
        }
    }
}
