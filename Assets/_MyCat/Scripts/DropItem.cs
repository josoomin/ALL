using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCat
{
    public class DropItem : MonoBehaviour
    {
        Rigidbody2D _rigid;
        Collider2D _col;

        void Start()
        {
            _col = GetComponent<Collider2D>();
            _col.enabled = false;

            _rigid = gameObject.GetComponent<Rigidbody2D>();
            _rigid.bodyType = RigidbodyType2D.Dynamic;
            _rigid.AddForce(new Vector2(0, 300.0f));

            Invoke("StopPhysics", 1.2f);
        }

        void StopPhysics()
        {
            _rigid.bodyType = RigidbodyType2D.Static;
            _col.enabled = true;
        }

        void Update()
        {

        }
    }
}
