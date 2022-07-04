using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D _rigid;
    public AudioSource _fxBird;

    public float _jumpForce = 1000.0f;
    public float _jumpLimit = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 force = new Vector2(0, _jumpForce);

            _rigid.AddForce(force);

            _fxBird.Play();
        }
        Vector3 vel = _rigid.velocity;

        //점프 속도 제한 값 limit : 5를 넘어가지 않는 값
        float limit = Mathf.Min(_jumpLimit, vel.y);

        _rigid.velocity = new Vector3(vel.x, limit, 0.0f);
    }
}