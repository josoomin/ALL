using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG3D
{
    public class Slime : Unit
    {
        Animator m_Animater;

        void Start()
        {

        }

        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "AttackCol")
            {
                Debug.Log("검과 충돌!");
                m_Animater.SetTrigger("hit");
            }
        }
    }
}
