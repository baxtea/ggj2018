﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Tweeting : MonoBehaviour
{
    string firstname; //will be the name the player enters
    
    public GameObject Headline;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject Choice3;
    public GameObject logo;
    public GameObject write;
    // Use this for initialization
    void Start()
    {
        

    }

    IEnumerator Event()
    {

        int r = Random.Range(0, TweetList.tweetsList.tweets.Count);
        Headline.GetComponentInChildren<SmartTextMesh>().UnwrappedText = TweetList.tweetsList.tweets[r][0];
        Headline.GetComponentInChildren<SmartTextMesh>().NeedsLayout = true;
        Instantiate(logo);
        yield return new WaitForSeconds(3);
        //UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        //System.Threading.Thread.Sleep(3000);//This will stop the program for 3 seconds, but it only puts the text onscreen after it returns the function and updates. Need to find solution
        Instantiate(write);
        //Destroy(logo.gameObject);
        Choice1.GetComponentInChildren<SmartTextMesh>().UnwrappedText = TweetList.tweetsList.tweets[r][1];
        Choice1.GetComponentInChildren<SmartTextMesh>().NeedsLayout = true;
        Choice2.GetComponentInChildren<SmartTextMesh>().UnwrappedText = TweetList.tweetsList.tweets[r][2];
        Choice2.GetComponentInChildren<SmartTextMesh>().NeedsLayout = true;
        Choice3.GetComponentInChildren<SmartTextMesh>().UnwrappedText = TweetList.tweetsList.tweets[r][3];
        Choice3.GetComponentInChildren<SmartTextMesh>().NeedsLayout = true;
        TweetList.tweetsList.tweets.RemoveAt(r);
        Debug.Log(TweetList.tweetsList.tweets.Count);
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Event());





        }

    }
}
