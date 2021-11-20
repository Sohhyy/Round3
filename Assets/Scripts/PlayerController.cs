using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject P1;
    public GameObject P2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        //transform.localScale = new Vector3(Vector3.Distance(P1.transform.position,P2.transform.position),1,1);
        transform.position = new Vector3((P2.transform.position.x + P1.transform.position.x) / 2, 1, 0);
        Debug.Log(Vector3.Distance(P1.transform.position, P2.transform.position));
    }

   
}
