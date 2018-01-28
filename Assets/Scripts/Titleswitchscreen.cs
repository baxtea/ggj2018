using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Titleswitchscreen : MonoBehaviour {
    public GameObject ggj;
	// Use this for initialization
	void Start () {
        Debug.Log("Running");
	}
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("loading new scene");
            Instantiate(ggj);
            StartCoroutine(GoBack());        }
    }
    IEnumerator GoBack()
    {
        Debug.Log("Going Back");
        yield return new WaitForSeconds(1);//Pause before showing options    
        SceneManager.LoadScene("Rally Planning");
        yield return null;
    }
    // void OnMouseDown()
    //{
    // Debug.Log("loading new scene");
    //SceneManager.LoadScene("Rally Planning", LoadSceneMode.Single);
    //}
}
