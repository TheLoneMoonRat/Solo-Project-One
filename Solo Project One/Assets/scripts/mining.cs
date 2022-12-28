using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mining : MonoBehaviour
{
    int i = 0;
    public Transform tr;
    public Transform me;
    public GameObject gamer;
    public Rigidbody obthing;
    public GameObject mee;
    public MeshRenderer dumb;
    List<GameObject> childrens = new List <GameObject>();
    Vector3 currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = new Vector3(me.transform.position.x - tr.transform.position.x, 0, me.transform.position.z - tr.transform.position.z);
        gamer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (getDistance(me.transform.position, tr.transform.position) > 1) {
            StartCoroutine(toTheMines());
        } else {
            StartCoroutine(mineNow());
            dumb.enabled = false;
        }
    }

    IEnumerator toTheMines() {
        yield return new WaitForSeconds(0.01f);
        transform.Translate(-currentSpeed.x / 2500.0f, 0, -currentSpeed.z / 2500.0f);
    }
    IEnumerator mineNow() {
        yield return new WaitForSeconds(5f);
        if (i % 2000 ==0) {
            Vector3 locationer = new Vector3(me.transform.position.x, me.transform.position.y, me.transform.position.z);
            childrens.Add(Instantiate(gamer, locationer, Quaternion.identity));
            childrens[childrens.Count - 1].SetActive(true);
            obthing = childrens[childrens.Count - 1].GetComponent<Rigidbody>();
            obthing.AddForce(0, 5, 1f, ForceMode.Impulse);
        }
        i++;
    }
    float getDistance (Vector3 a, Vector3 b) {
        Vector3 placeholder = new Vector3(a.x - b.x, 0, a.z - b.z);
        return(toFloat(Math.Sqrt(Math.Pow(placeholder.x, 2) + Math.Pow(placeholder.z, 2))));
    }
    
    private float toFloat(double a) {
        return (float)a;
    }
}
