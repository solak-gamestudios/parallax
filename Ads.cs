using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ads : MonoBehaviour {

	private BannerView bannerView;
	private InterstitialAd interstitial;
    GameObject Player;
    //public Button AddScoreButton;
    //public GameObject AskFor;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
		if (SceneManager.GetActiveScene ().name == "Main Menu") {
			bannerView = new BannerView ("ca-app-pub-8696786032145652/4056105724", AdSize.SmartBanner, AdPosition.Bottom);
			bannerView.LoadAd (new AdRequest.Builder().Build ());
		} 
		if (SceneManager.GetActiveScene ().name == "Endless" && globalValues.minutes >= 2) {
			interstitial = new InterstitialAd("ca-app-pub-8696786032145652/5151062528");
			interstitial.LoadAd(new AdRequest.Builder().Build());
		}
		/*if (SceneManager.GetActiveScene ().name == "Main Menu") {

			RewardBasedVideoAd rewardBasedVideo = RewardBasedVideoAd.Instance;
			AdRequest request = new AdRequest.Builder ()
			.Build ();
			rewardBasedVideo.LoadAd (request, "ca-app-pub-8696786032145652/5552858525");

		}*/
	}
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name == "Endless") {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        if (SceneManager.GetActiveScene().name == "Main Menu" && Player == null)
        {
            bannerView.Show();
        }
        else {
            bannerView.Hide();
        }
        if (SceneManager.GetActiveScene().name == "Endless")
        {
            if (interstitial.IsLoaded() && Player == null && globalValues.minutes >= 2)
            {
                interstitial.Show();
                globalValues.time = 0;
            }
        }
		/*
		if (rewardBasedVideo.IsLoaded ()) {
			AddScoreButton.interactable = true;

		} else {
			AddScoreButton.interactable = false;
		}
		Debug.Log ("Request: " + rewardBasedVideo.IsLoaded ());
		*/
	}
	void OnDestroy(){
		bannerView.Hide ();
	}
	/*
	public void ShowMoney(){
		AskFor.SetActive (false);
		rewardBasedVideo.Show();
	}
	public void ShowMoneyNo(){
	AskFor.SetActive (false);
	}
	public void AskForMoney(){
		AskFor.SetActive (true);
	}
	*/
}
