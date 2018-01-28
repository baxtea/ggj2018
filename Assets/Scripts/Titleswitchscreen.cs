using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Titleswitchscreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Running");
	}
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("loading new scene");
            SceneManager.LoadScene("Rally Planning");
        }
    }
   // void OnMouseDown()
    //{
       // Debug.Log("loading new scene");
        //SceneManager.LoadScene("Rally Planning", LoadSceneMode.Single);
    //}
}
