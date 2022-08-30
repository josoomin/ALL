using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float _speed = 0.5f;
    public float _attackRange = 1.75f;

    public GameObject _enemyObj;

    Rigidbody2D _rigid;
    SpriteRenderer _renderer;
    Animator _anim;
    Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody�� �ǵ���� ������ �̵�

        // 1.rigidbody.ADDForce �Լ�ȣ ��(���ӵ�)�� �־ �̵� - ���ӵ� � 
        // _rigid.AddForce(new Vector2(10, 0));

        // 2.rigidbody.velocity ����(x�ุ)�� ���� �ǵ帮�� ��� - ��ӵ� �
        Vector2 vel = _rigid.velocity;
        vel.x = _speed;//x�� �ӵ��� ����

        if (_renderer.flipX == true)
            vel.x = -1.0f * _speed;

        _rigid.velocity = vel;

        if (_enemyObj != null)
        {
            //�Ÿ� üũ �Լ� ȣ��
            CheckDistance();
        }
    }

    void CheckDistance() // �Ÿ��� üũ�ϴ� �Լ�
    {
        // ���� �� ĳ���Ͱ��� �Ÿ��� ����ؼ�, ������ ���ݹ��� �ȿ� ������ ����

        float pos1 = transform.position.x; // ���� ��ġ
        float pos2 = _enemyObj.transform.position.x; // ���� ��ġ

        float distance = Mathf.Abs(pos1 - pos2); // �� ĳ���� ���� �Ÿ� (�� x��ǥ ������ �Ÿ�)

        if (distance < _attackRange) // ���ݹ��� �ȿ� ������
        {
            //����
            _anim.SetBool("attack", true);
        }
        else
        {
            // �ٽ�, idle �� ��ȯ
            _anim.SetBool("attack", false);
        }
    }
}
