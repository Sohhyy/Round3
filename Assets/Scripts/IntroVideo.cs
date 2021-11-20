using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeMainScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeMainScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Main");
    }
}
