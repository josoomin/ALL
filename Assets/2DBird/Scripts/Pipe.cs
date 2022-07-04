using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameManager _gameMgr;
    public float _pipeSpeed = -0.005f;

    // Start is called before the first frame update
    void Start()
    {
        _gameMgr = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // �������� �����̴� ����

        // ������Ʈ�� ���µ� �ƴϰ�(�׸���), ���ӿ����� �ƴҶ�

        if (_gameMgr._isIntro == false && _gameMgr._isGameover == false)
        {
            transform.Translate(_pipeSpeed, 0, 0); //x��(����)���θ� �̵�
        }
    }
}