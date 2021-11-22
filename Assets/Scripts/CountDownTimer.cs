using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text gameTimeText;
    public float gameTime;
    
    float _gameTimeNow;
    StartControl startFlag;
    bool changefastBGM;
    bool playtensecond;
    void Start()
    {
        changefastBGM = true;
        playtensecond = true;
        _gameTimeNow = gameTime;
        gameTimeText.text = _gameTimeNow.ToString();
    }

    void Update()
    {
        if(_gameTimeNow > 0 && GameManager.Instance.isstart)
        {
            UpdateTimer();
        }
        else if(_gameTimeNow <= 0 && GameManager.Instance.isstart)
        {
            //end part
            changefastBGM = true;
            GameManager.Instance.GameEnd();
            _gameTimeNow = gameTime;                    
        }
    }

    public void UpdateTimer()
    {
        _gameTimeNow -= Time.deltaTime;
        gameTimeText.text = _gameTimeNow.ToString("00");
        if (_gameTimeNow <= 15 && changefastBGM)
        {
            changefastBGM = false;
            SoundMgr.Instance.PlayBGM(7);
        }
        if (_gameTimeNow <= 12 && playtensecond)
        {
            playtensecond = false;
            SoundMgr.Instance.PlaySound(11);
        }
    }

    public void AddTime(float time)
    {
        _gameTimeNow += time;
    }

    public void MinusTime(float time)
    {
        _gameTimeNow -= time;
    }

    public float returnTime()
    {
        return _gameTimeNow;
    }
}
