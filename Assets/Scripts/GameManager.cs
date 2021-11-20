using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance = null;
    public int score;
    public Text scoretext;
    public bool isstart;
    public GameObject StartingPoint;
    public GameObject Basket;
    public GameObject RankObject;
    public Text Rank1;
    public Text Rank2;
    public Text Rank3;

    public List<int> Rank = new List<int>();
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
        score = 0;
        scoretext.text = score.ToString();
        isstart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int i)
    {
        score = score + i;
        scoretext.text = score.ToString();
    }

    public void MinusScore(int i)
    {
        score = score - i;
        if (score < 0)
        {
            score = 0;
        }
        scoretext.text = score.ToString();
    }

    
    public void RankSort()
    {
        int temp = 0;

        for (int write = 0; write < Rank.Count-1; write++)
        {
            for (int sort = 0; sort < Rank.Count - 1-write; sort++)
            {
                if (Rank[sort] < Rank[sort + 1])
                {
                    temp = Rank[sort + 1];
                    Rank[sort + 1] = Rank[sort];
                    Rank[sort] = temp;
                }
            }
        }
    }

    public void GameStart()
    {
        SoundMgr.Instance.PlayBGM(6);
        
        SoundMgr.Instance.PlaySound(0);
        RankObject.SetActive(false);
        Basket.GetComponent<MeshCollider>().enabled = true;
        score = 0;
        scoretext.text = score.ToString();
        isstart = true;
        CoinManager.Instance.StartCreate();
        StartingPoint.SetActive(false);
    }

    public void GameEnd()
    {
        SoundMgr.Instance.StopBGM();
        SoundMgr.Instance.PlaySound(9);
        Basket.GetComponent<MeshCollider>().enabled = false;
        isstart = false;
        StartingPoint.SetActive(true);
        CoinManager.Instance.StopCreate();
        Rank.Add(score);
        RankSort();
        RankObject.SetActive(true);
        Rank1.text = Rank[0].ToString();
        Rank2.text = Rank[1].ToString();
        Rank3.text = Rank[2].ToString();
        Debug.Log(Rank);

    }
}
