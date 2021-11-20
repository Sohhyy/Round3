using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tracker1;
    public GameObject Tracker2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Dog2_bowtie")
        {
            transform.position = new Vector3(Tracker1.transform.position.x*2.5f, 1, 0);
            if (Tracker1.transform.position.x < Tracker2.transform.position.x)
            {
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = -180;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Tracker1.transform.position.x >= Tracker2.transform.position.x)
            {
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = 0;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
        }
        if (gameObject.name == "Dog1+hat")
        {
            transform.position = new Vector3(Tracker2.transform.position.x*2.5f, 1, 0);
            if (Tracker1.transform.position.x < Tracker2.transform.position.x)
            {
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = 0;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Tracker1.transform.position.x >= Tracker2.transform.position.x)
            {
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = -180;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
        }
    }
}
