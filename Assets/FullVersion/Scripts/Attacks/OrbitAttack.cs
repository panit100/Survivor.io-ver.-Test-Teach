using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace SurvivorIO_Ver_Test
{    
    public class OrbitAttack : BaseAttack
    {
        public GameObject OrbitObject;
        public float OrbitSpeed;
        public float OrbitDuration;
        public float OrbitCoolDown;
        public int orbitCount;
        public float radial;

        private bool loadAllOrbit = false;
        private float tempDuration;
        private Coroutine IECooldown;
        
        private void Awake()
        {
            if(!this.isActiveAndEnabled)weaponLevel = 0;
        }
        void Start()
        {
            tempDuration = OrbitDuration;
            StartCoroutine(SurroundOrbitSpawn());
        }

        private void Update()
        {
            if (loadAllOrbit)
            {
                this.transform.RotateAround(this.transform.position,Vector3.forward,OrbitSpeed*Time.deltaTime);
                OrbitDuration -= Time.deltaTime;
                if(OrbitDuration < 0)
                {
                    foreach (Transform orbits in this.transform)
                    {
                        GameObject.Destroy(orbits.gameObject);
                    }
                    if (IECooldown == null) IECooldown = StartCoroutine(WaitForCoolDown());
                    loadAllOrbit = false;
                }
            }
        }



        IEnumerator WaitForCoolDown()
        {
            yield return new WaitForSeconds(OrbitCoolDown);
            StartCoroutine(SurroundOrbitSpawn());
            IECooldown = null;
        }

        IEnumerator SurroundOrbitSpawn()
        {
            float anglestep = 360.0f / orbitCount;
            for (int i = 0; i < orbitCount; i++)
            {
                var NewOrbitObject = Instantiate(OrbitObject);
                NewOrbitObject.transform.position = Vector3.Lerp(this.transform.position, NewOrbitObject.transform.position, 0.4f);
                NewOrbitObject.transform.RotateAround(transform.position,Vector3.forward, anglestep*i);
                NewOrbitObject.transform.SetParent(this.transform);
                Vector3 Direction = NewOrbitObject.transform.position - this.transform.position;
                yield return new WaitForEndOfFrame();
            }
            OrbitDuration = tempDuration;
            loadAllOrbit = true;
        
        }
        
        public override void UpgradeWeaponLevel()
        {
            if (weaponLevel == 0)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                weaponLevel++;
                if ((OrbitCoolDown / 4) >= 0.1f)
                {
                    OrbitCoolDown /= 4;
                }
                orbitCount++;
                OrbitDuration *= 1.1f;
            }
            weaponLevel++;
        }
    }
}
