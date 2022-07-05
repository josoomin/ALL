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
            return; //함수 종료
        /*
        Vector3 pos = transform.position; // 트랜스폼의 위치값을 임시 변수 pos에 담아두고

        if (Input.GetKey(KeyCode.LeftArrow)) // 왼쪽 화살표 키를 누르고 있는 중이면
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
        Debug.Log("충돌 발생 : " + collision.gameObject.name);

        //게임매니저에 게임오버 사실을 알림
        _gameMgr.OnGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거 이벤트 발생 : " + collision.gameObject.name);

        _gameMgr._score += 1;
    }
}