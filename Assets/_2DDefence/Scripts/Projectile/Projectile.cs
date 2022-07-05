using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defance
{
    //Projectile: 발사체, 날아가는 공격 물체를 
    public class Projectile : MonoBehaviour
    {
        public Team _team;

        Rigidbody2D _rigid;

        public float _flyForce = 100.0f;

        // Start is called before the first frame update
        void Start()
        {
            _rigid = GetComponent<Rigidbody2D>();

            Vector2 force = new Vector2(_flyForce, 0.0f);

            _rigid.AddForce(force);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}