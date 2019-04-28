using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColliderTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        //Debug.Log("test");
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Debug.Log("test");
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("test");
		
	}

    void OnCollisionEnter(Collision collision)
    {
        //(処理を記述)

        foreach (ContactPoint point in collision.contacts)
        {
            //衝突位置
            //Debug.Log(point);
        }
        
        switch (collision.gameObject.tag)
        {
            case "50p":
                //gameObject.SendMessage("PointGet", 50, SendMessageOptions.DontRequireReceiver);
                break;
            case "30p":
                //gameObject.SendMessage("PointGet", 30, SendMessageOptions.DontRequireReceiver);
                break;
            case "10p":
                //gameObject.SendMessage("PointGet", 10, SendMessageOptions.DontRequireReceiver);
                break;
            default:
                break;
        }


    }

    void OnCollisionExit(Collision collision)
    {
        //(処理を記述)
    }
}
