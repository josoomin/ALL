using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyTest();

        int c = Test1(10, 20);
        Debug.Log(c);

        Test2();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hello World! " + Time.time);
    }

    void MyTest()
    {
        
    }

    int Test1(int a, int b)
    {
        return a + b;
    }
    void Test2()
    {
        Debug.Log("Hello");
    }
}