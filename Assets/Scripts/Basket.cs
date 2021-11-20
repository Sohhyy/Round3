using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject P1;
    public GameObject P2;
    public GameObject[] Scoretext;
    
    public CountDownTimer gameTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       transform.localScale = new Vector3(transform.localScale.x, 55 * Vector3.Distance(P1.transform.position, P2.transform.position), transform.localScale.z);
       transform.position = new Vector3((P2.transform.position.x + P1.transform.position.x) / 2, 1, 0);
        //Debug.Log(Vector3.Distance(P1.transform.position, P2.transform.position));
    }

    private void OnTriggerEnter(Collider other)
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 0;
        rotationVector.y = 0;
        rotationVector.z = 0;
       
        //add scores
        if (other.gameObject.tag == "Coin")
        {
            GameManager.Instance.AddScore(1);
            Instantiate(Scoretext[0], other.gameObject.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(2);
        }
        if (other.gameObject.tag == "Ketchup")
        {
            GameManager.Instance.AddScore(1);
            Instantiate(Scoretext[0], other.gameObject.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(2);
        }
        if (other.gameObject.tag == "Cheese")
        {
            GameManager.Instance.AddScore(3);
            Instantiate(Scoretext[1], other.gameObject.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(2);
        }
        if (other.gameObject.tag == "Sausage")
        {
            GameManager.Instance.AddScore(5);
            Instantiate(Scoretext[2], other.gameObject.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(2);
        }
        if (other.gameObject.tag == "Bacon")
        {
            GameManager.Instance.AddScore(10);
            Instantiate(Scoretext[3], other.gameObject.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(2);
        }

        //minus scores
        if (other.gameObject.tag == "Bomb")
        {
            GameManager.Instance.MinusScore(1);
            Instantiate(Scoretext[4], other.gameObject.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(1);
        }
        if (other.gameObject.tag == "Knife")
        {
            GameManager.Instance.MinusScore(5);
            Instantiate(Scoretext[4], other.gameObject.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(1);
        }
        if (other.gameObject.tag == "Fork")
        {
            GameManager.Instance.MinusScore(5);
            Instantiate(Scoretext[4], other.gameObject.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(1);
        }

        //add time
        if (other.gameObject.tag == "DogFood")
        {
            gameTime.AddTime(5f);
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(4);
        }

        //minus time
        if (other.gameObject.tag == "Fish")
        {
            gameTime.MinusTime(5f);
            Destroy(other.gameObject);
            SoundMgr.Instance.PlaySound(3);
        }

        Debug.Log(other.gameObject.tag);
       
    }
}
