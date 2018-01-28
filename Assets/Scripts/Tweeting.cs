using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Tweeting : MonoBehaviour
{
    string firstname; //will be the name the player enters

    TweetList options;
    
    public GameObject Headline;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject Choice3;
    public GameObject logo;
    public GameObject write;
    // Use this for initialization
    void Start()
    {
        options = new TweetList();
        StartCoroutine(Event());
        
    }
    public void ChoiceMade(int which)
    {
        Debug.Log("Clicked bubble " + which);
    }

    IEnumerator Event()
    {

        int r = Random.Range(0, options.tweets.Count);
        Headline.GetComponentInChildren<SmartTextMesh>().UnwrappedText = options.tweets[r][0];//sets headline text
        Headline.GetComponentInChildren<SmartTextMesh>().NeedsLayout = true;//aligns text
        Instantiate(logo);
        yield return new WaitForSeconds(3);//Pause before showing options
        //UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        //System.Threading.Thread.Sleep(3000);//This will stop the program for 3 seconds, but it only puts the text onscreen after it returns the function and updates. Need to find solution
        Instantiate(write);
        //Destroy(logo.gameObject);
        Choice1.GetComponentInChildren<SmartTextMesh>().UnwrappedText = options.tweets[r][1];
        Choice1.GetComponentInChildren<SmartTextMesh>().NeedsLayout = true;
        Choice2.GetComponentInChildren<SmartTextMesh>().UnwrappedText = options.tweets[r][2];
        Choice2.GetComponentInChildren<SmartTextMesh>().NeedsLayout = true;
        Choice3.GetComponentInChildren<SmartTextMesh>().UnwrappedText = options.tweets[r][3];
        Choice3.GetComponentInChildren<SmartTextMesh>().NeedsLayout = true;
        options.tweets.RemoveAt(r);//removes tweet so there are no repeats
        Debug.Log(options.tweets.Count);
        yield return null;
    }
}
