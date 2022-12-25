using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tracking : MonoBehaviour
{
    public Transform treegroup;
    Vector3 currentDistance;
    
    float closest;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        currentDistance = new Vector3(treegroup.GetChild(0).transform.position.x, 0, treegroup.GetChild(0).transform.position.z);
        closest = Math.Sqrt(Math.Pow(currentDistance.x, 2.0f) + Math.Pow(currentDistance.z, 2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i< treegroup.childCount; i++) {
            currentDistance = new Vector3(treegroup.GetChild(0).transform.position.x, 0, treegroup.GetChild(0).transform.position.z);
            if (Math.Sqrt(Math.Pow(ToSingle(currentDistance.x), 2) + Math.Pow(ToSingle(currentDistance.z), 2)) < closest) {
                target = treegroup.GetChild(i);
                closest = Math.Sqrt(Math.Pow(currentDistance.x, 2f) + Math.Pow(currentDistance.z, 2f));
            } 
        } 

    }
}