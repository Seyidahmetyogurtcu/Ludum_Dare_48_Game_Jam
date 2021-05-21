using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerShooter.singleton.egg != null)
        {
            transform.position = PlayerShooter.singleton.egg.transform.position+new Vector3(0,0,-10);
        }
    }
}
