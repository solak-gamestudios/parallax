using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ads : MonoBehaviour {

	private BannerView bannerView;
	private InterstitialAd interstitial;
    GameObject Player;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
		if (SceneManager.GetActiveScene ().name == "Main Menu") {
			bannerView = new BannerView ("ca-app-pub-", AdSize.SmartBanner, AdPosition.Bottom);
			bannerView.LoadAd (new AdRequest.Builder().Build ());
		} 
		if (SceneManager.GetActiveScene ().name == "Endless" && globalValues.minutes >= 2) {
			interstitial = new InterstitialAd("ca-app-pub-");
			interstitial.LoadAd(new AdRequest.Builder().Build());
		}
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
	}
	void OnDestroy(){
		bannerView.Hide ();
	}
}
