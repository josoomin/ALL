using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public GameObject _pipeSetTemplate;

    float _delay = 2.0f;

    public GameManager _gameMgr;

    void Start()
    {
        //������ ���� ���ϵ��� ���д�.
        _pipeSetTemplate.SetActive(false);
    }

    public void Start_MakePipeSet()
    {
            //1�� ����� ��, MakePipeSet �Լ� ȣ��
            Invoke("MakePipeSet", _delay);
    }

    

    void MakePipeSet()
    {
        if (_gameMgr._isGameover == false)
        {
            //����
            GameObject clonedObj = Instantiate(_pipeSetTemplate);
            clonedObj.SetActive(true);

            float yPos = Random.Range(3.0f, 6.0f);
            clonedObj.transform.position = new Vector3(5, yPos, 0);

            //�� ������ �ݺ��ǵ���, 1�� ����� ��, MakePipeSet �Լ� ȣ��
            Invoke("MakePipeSet", _delay);
        }
    }
}
