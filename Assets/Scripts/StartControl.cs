using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartControl : MonoBehaviour
{
    public bool player1Flag;
    public bool player2Flag;
    public float starttime=5f;
    public float timer;
    public Transform Image1;
    public Transform Image2;
    // Start is called before the first frame update
    void Start()
    {
        player1Flag = false;
        player2Flag = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Flag && player2Flag &&!GameManager.Instance.isstart)
        {
            timer = timer + Time.deltaTime;
           
            if (timer >= starttime)
            {
                player1Flag = false;
                player2Flag = false;
                timer = 0;
                GameManager.Instance.GameStart();
            }
        }
        Image1.GetComponent<Image>().fillAmount = timer / starttime;
        Image2.GetComponent<Image>().fillAmount = timer / starttime;

    }

}
