using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFollow : MonoBehaviour
{
    public GameObject dest;
    public GameObject lookAtDest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, dest.transform.position, Time.deltaTime);
        transform.LookAt(lookAtDest.transform.position);
    }
}
