using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StartPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            StartPoint.GetComponent<StartControl>().player1Flag = true;
            SoundMgr.Instance.PlaySound(5);
            SoundMgr.Instance.PlaySound(10);
        }
        if (other.gameObject.tag == "Player2")
        {
            StartPoint.GetComponent<StartControl>().player2Flag = true;
            SoundMgr.Instance.PlaySound(5);
            SoundMgr.Instance.PlaySound(10);
        }
        Debug.Log(other.gameObject.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            StartPoint.GetComponent<StartControl>().player1Flag = false;
            StartPoint.GetComponent<StartControl>().timer = 0f;
        }
        if (other.gameObject.tag == "Player2")
        {
            StartPoint.GetComponent<StartControl>().player2Flag = false;
            StartPoint.GetComponent<StartControl>().timer = 0f;
        }
    }
}
