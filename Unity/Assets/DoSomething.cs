using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoSomething : MonoBehaviour
{

    public SerialHandler serialHandler;
    public GameObject _indexFinger;
    public GameObject _unko;
    //public Text text;
    private Rigidbody _rigidbody;
    private Transform _transform;
    double vel;
    double vel1;
    double _rotation0;
    double _rotation1;
    string text;

    float _distance;
    float _threshold = 0.2f;
    //Quaternion quaternion;
    // Use this for initialization
    void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
        _rigidbody = this.GetComponent<Rigidbody>();
        _transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("test");
        //serialHandler.Write("hogehoge");
        //_rotation0 = _rigidbody.rotation.y;
        
        /*_rotation0 = transform.localEulerAngles.y;
        vel = _rotation1 - _rotation0;
        if (vel > 200 || vel < -200)
        {
            vel = vel1;
        }
        //Debug.Log("回転y成分　速度" + _rotation0);
        //Debug.Log("回転y成分　速度" + vel);
        text = vel.ToString();
        //Debug.Log("test表示" + text);
        serialHandler.Write(text + ",");
        _rotation1 = _rotation0;
        vel1 = vel;*/

        _distance = (_indexFinger.transform.position - _unko.transform.position).magnitude;
        Debug.Log(_distance);
        serialHandler.Write(_distance.ToString() + ",");
        if (_distance < _threshold)
        {
            Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@");
            Purun(_distance);
        }
        else
        {
            Purun(_threshold);
        }
    }

    /*
     * シリアルを受け取った時の処理
     */
    void OnDataReceived(string message)
    {
        try
        {
            //text.text = message; // シリアルの値をテキストに表示
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

    void Purun(float _distance)
    {
        Vector3 localScale = _transform.localScale;
        // localScale.y = 0.007f;
        // _transform.localScale = localScale;
        localScale.y = 0.005f - ((_threshold - _distance) / _threshold) * 0.005f;
        //localScale.y = 0.003f;
        _transform.localScale = localScale;
        // localScale.y = 1.0f;
    }
}