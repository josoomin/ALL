using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    //public class TinyHuman : MonoBehaviour
    //{
    //    public Rigidbody _human;
    //    public float _power = 1.0f;

    //    void Start()
    //    {
    //        _human = GetComponent<Rigidbody>();
    //    }

    //    void Update()
    //    {
    //        _human.transform.Translate(0, 0, _power);
    //        if (_human.velocity.x <= 0.000001f)
    //        {
    //            _human.transform.Rotate(0,10,0);
    //        }
    //    }
    //}
    public class TinyHuman : MonoBehaviour
    {
        [SerializeField] float _maxDistance = 15.0f;
        [SerializeField] float _moveDelta = 0.01f;
        [SerializeField] float _distance = 0.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            move();
        }

        void move()
        {
            Vector3 dir = transform.forward.normalized;
            _distance += _moveDelta;
            transform.Translate(dir * _moveDelta, Space.World);
            if (_distance > _maxDistance)
            {
                // 턴 하기
                transform.Rotate(Vector3.up, 180.0f);
                _distance = 0.0f;
            }
        }

        float direction = 1.0f; // 1.0f 오른쪽, -0.1f 왼쪽
        void move2()
        {
            _distance += _moveDelta;
            transform.Translate(new Vector3(direction * _moveDelta, 0, 0), Space.World);
            if (_distance > _maxDistance)
            {
                // 턴 하기
                transform.Rotate(Vector3.up, 180.0f);
                _distance = 0.0f;
                direction *= -1.0f;
            }
        }
    }
}