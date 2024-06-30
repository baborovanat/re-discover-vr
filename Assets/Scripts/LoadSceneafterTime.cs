using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneafterTime : MonoBehaviour

{
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Login");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSceneLoad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
