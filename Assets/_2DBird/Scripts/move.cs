using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameManager _gameMgr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_gameMgr._isIntro == true)
            return; //�Լ� ����
        /*
        Vector3 pos = transform.position; // Ʈ�������� ��ġ���� �ӽ� ���� pos�� ��Ƶΰ�

        if (Input.GetKey(KeyCode.LeftArrow)) // ���� ȭ��ǥ Ű�� ������ �ִ� ���̸�
        {
            //transform.position = new Vector3(pos.x = 1.0f, pos.y, pos.z);

            pos.x = pos.x - 0.01f;

            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x = pos.x + 0.01f;

            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y = pos.y + 0.01f;

            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y = pos.y - 0.01f;

            transform.position = pos;
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�浹 �߻� : " + collision.gameObject.name);

        //���ӸŴ����� ���ӿ��� ����� �˸�
        _gameMgr.OnGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ʈ���� �̺�Ʈ �߻� : " + collision.gameObject.name);

        _gameMgr._score += 1;
    }
}