using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PipeManager _pipeMgr;

    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _gameoverUI;
    public Rigidbody2D _birdRigid;
    public Animator _birdAni;

    public bool _isIntro = true; //��Ʈ�� ���������� ��Ÿ��
    public bool _isGameover = false; // ���ӿ��� ���������� ��Ÿ��

    public Text _scoreNumberText;
    public int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject canvasUI = GameObject.Find("Canvas");
        //Transform playUITrans = canvasUI.transform.Find("1_UI_Play");
        //Transform scoreNumberTrans = playUITrans.Find("Txt_Number");

        //_scoreNumberText = scoreNumberTrans.gameObject.GetComponent<Text>();

        Transform _scoreNumberTrans = _playUI.transform.Find("Txt_Number");
        _scoreNumberText = _scoreNumberTrans.gameObject.GetComponent<Text>();

        // ��Ʈ�� ����
        //_introUI = GameObject.Find("UI_Intro");

        // 1. UI ó��
        _introUI.SetActive(true);
        _playUI.SetActive(false);
        _gameoverUI.SetActive(false);

        //2. �߷�(����) ��Ȱ��ȭ
        _birdRigid.simulated = false;

        //3. ���� �Է� ��Ȱ��ȭ
        _isIntro = true;

        _birdAni.StartPlayback();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreNumberText.text = _score.ToString(); 
    }

    //��ư �̺�Ʈ �Լ� : ���� ����
    public void OnClick_GameStart()
    {
        Debug.Log("���� ���� ��ư ����");

        //1. ��Ʈ�� UI�� ���ְ�, �÷��� UI�� ����
        _introUI.SetActive(false);
        _playUI.SetActive(true);
        _gameoverUI.SetActive(false);

        //2. �߷�(����) Ȱ��ȭ
        _birdRigid.simulated = true;

        //3. ���� �Է� Ȱ��ȭ
        _isIntro = false;

        _birdAni.StopPlayback();

        //������ ���� ����
        _pipeMgr.Start_MakePipeSet();
    }

    // ���ӿ��� �̺�Ʈ �Լ�
    public void OnGameOver()
    {
        // �÷��� UI�� ���ְ�
        _playUI.SetActive(false);

        // ���ӿ��� UI�� ���ֱ�
        _gameoverUI.SetActive(true);

        // �ٽ�, �߷� ��Ȱ��
        _birdRigid.simulated = false;

        _birdAni.StartPlayback();

        _isGameover = true;
    }

    // ���� ����� �̺�Ʈ �Լ�
    public void OnClick_Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}