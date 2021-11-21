using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LargeKnife;
    public GameObject LargeFork;

    public GameObject Ketchup;
    public GameObject Bacon;
    public GameObject Sausage;
    public GameObject Cheese;
    public GameObject Knife;
    public GameObject Fork;
    public GameObject Fish;
    public GameObject DogFood;

    public GameObject Timer;

    public GameObject Left;
    public GameObject Right;
    public static CoinManager Instance = null;
    public CountDownTimer gameTime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    IEnumerator CreateCoin()
    {
        while (GameManager.Instance.isstart)
        {
            var rotationVector_Sausage = transform.rotation.eulerAngles;
            rotationVector_Sausage.x = 180;
            var rotationVector_Bacon = transform.rotation.eulerAngles;
            rotationVector_Bacon.x = -90;
            if (gameTime.returnTime() > 15)
            {
                Debug.Log(gameTime.returnTime());
                int index = Random.Range(0,11);
                if (index < 4)//one points
                {
                    Instantiate(Ketchup, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), transform.rotation);
                }
                else if (index >= 4 && index < 7)//three points
                {
                    Instantiate(Bacon, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), Quaternion.Euler(rotationVector_Bacon));
                }
                else if (index >= 7 && index < 9)//five points
                {
                    Instantiate(Sausage, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), Quaternion.Euler(rotationVector_Sausage));
                }
                else if (index >= 9 && index <= 10)//ten points
                {
                    Instantiate(Cheese, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), transform.rotation);
                }
                yield return new WaitForSeconds(1f);
            }
            else
            {
                Debug.Log(gameTime.returnTime());
                int index = Random.Range(0, 11);
                if (index < 2)//one points
                {
                    Instantiate(Ketchup, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), transform.rotation);
                }
                else if (index >= 2 && index < 5)//three points
                {
                    Instantiate(Bacon, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), Quaternion.Euler(rotationVector_Bacon));
                }
                else if (index >= 5 && index < 8)//five points
                {
                    Instantiate(Sausage, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), Quaternion.Euler(rotationVector_Sausage));
                }
                else if (index >= 8 && index <= 10)//ten points
                {
                    Instantiate(Cheese, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), transform.rotation);
                }
                yield return new WaitForSeconds(0.7f);
            }

        }
        
    }

    IEnumerator CreateBomb()
    {
        while (GameManager.Instance.isstart)
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = -90;
            var rotationVector_fork = transform.rotation.eulerAngles;
            rotationVector_fork.z = 75;

            if (gameTime.returnTime() > 15)
            {
                int index = Random.Range(0, 10);
                if (index < 5)
                {
                    Instantiate(Fork, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), Quaternion.Euler(rotationVector_fork));
                }
                else if (index >= 5)
                {
                    Instantiate(Knife, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), transform.rotation);
                }
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                int index = Random.Range(0, 10);
                if (index < 5)
                {
                    Instantiate(LargeFork, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), Quaternion.Euler(rotationVector_fork));
                }
                else if (index >= 5)
                {
                    Instantiate(LargeKnife, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), transform.rotation);
                }
                yield return new WaitForSeconds(1f);
            }

            

                                                 
        }
    }

    IEnumerator CreateTimer()
    {
        while (GameManager.Instance.isstart && gameTime.returnTime() > 15)
        {
            int index = Random.Range(0, 10);
            if (index < 5)
            {
                Instantiate(DogFood, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), transform.rotation);
            }
            else if (index >= 5)
            {
                Instantiate(Fish, new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), 10, 0), transform.rotation);
            }
            yield return new WaitForSeconds(15f);
        }
    }


    public void StartCreate()
    {      
        StartCoroutine(CreateCoin());
        StartCoroutine(CreateBomb());
        StartCoroutine(CreateTimer());
    }

    public void StopCreate()
    {
        
    }

}
