using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class Billboard : MonoBehaviour
{
    public Transform cam;


    private void Start()
    {
       MS.uIM
                 .ObserveEveryValueChanged(x => x.CurCamera)
                 .Subscribe(x => cam = x.transform);
    }



    private void Awake()
    {
        cam = MS.uIM.CurCamera.gameObject.transform;
    } 
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
