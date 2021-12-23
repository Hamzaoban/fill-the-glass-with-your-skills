using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
/// <summary>
/// Happy Glass 
/// Credit: Satyam Parkhi
/// Email: satyamparkhi@gmail.com
/// Facebook : https://www.facebook.com/satyamparkhi
/// Instagram : https://www.instagram.com/satyamparkhi/
/// Whatsapp : +91 7050225661
/// </summary>
public class AdMobManager : MonoBehaviour
{
	public static AdMobManager _AdMobInstance;
	public string bannerAdId, interstitialAdId, rewardVideoAdId;
	public bool  isDebug;
	public  bool isOnTop;
	
	private static BannerView bannerView;
	private static InterstitialAd interstitial ;
    public GameObject WatchVideoBTN;
	// Use this for initialization

	void Awake ()
	{
		if (_AdMobInstance) {
			DestroyImmediate (gameObject);
		} else {
			DontDestroyOnLoad (gameObject);
			_AdMobInstance = this;
		}
	}


	void Start ()
	{
		
		loadInterstitial ();
		showBannerAd ();
	}
	
	// Update is called once per frame

	void OnGUI ()
	{
		if (isDebug) {
			if (GUI.Button (new Rect (20, 0, 100, 60), "Load Full")) {
				loadInterstitial ();
			}
			
			if (GUI.Button (new Rect (20, 160, 100, 60), "Show Banner")) {
				showBannerAd ();
			}
			if (GUI.Button (new Rect (200, 0, 100, 60), "Show Full")) {
				showInterstitial ();
			}
			
			if (GUI.Button (new Rect (200, 160, 100, 60), "Hide Banner")) {
				hideBannerAd ();
			}
		

		}
	}
    void Update()
    {
    }
    void onInterstitialEvent (object sender, System.EventArgs args)
	{
		print("OnAdLoaded event received.");
		// Handle the ad loaded event.
	}
	void onInterstitialCloseEvent (object sender, System.EventArgs args)
	{
		print("OnAdLoaded event received.");
		// Handle the ad loaded event.
	}

	void onBannerEvent (string eventName, string msg)
	{
		
	}

	void onRewardedVideoEvent (object sender, Reward args)
	{
		string type = args.Type;
		double amount = args.Amount;
		print("User rewarded with: " + amount.ToString() + " " + type);
    }


	public  void showBannerAd ()
	{
		if(isOnTop)
		{
			bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Top);
			AdRequest request = new AdRequest.Builder().Build();
			// Load the banner with the request.
			bannerView.LoadAd(request);
		}
		else
		{
			bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Bottom);
			AdRequest request = new AdRequest.Builder().Build();
			// Load the banner with the request.
			bannerView.LoadAd(request);
		}
		// Create an empty ad request.

	}
		

	public  void loadInterstitial ()
	{
		interstitial = new InterstitialAd(interstitialAdId);
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	public  void showInterstitial ()
	{		
		if (interstitial.IsLoaded()) {            
            interstitial.Show();
			interstitial.OnAdOpening += onInterstitialEvent;
			interstitial.OnAdClosed += onInterstitialCloseEvent;
		}
		else
		{
			loadInterstitial ();
			interstitial.Show();
			interstitial.OnAdOpening += onInterstitialEvent;
			interstitial.OnAdClosed += onInterstitialCloseEvent;
		}
        if (Hint)
        {
            for (int i = 0; i < FindObjectOfType<GameManager>().Hint.Length; i++)
            {
                FindObjectOfType<GameManager>().Hint[i].SetActive(true);
            }
            Hint = false;
        }
    }
    public bool Hint;

    
	void onRewardedVideoSkippedEvent (System.Object sender,System.EventArgs args)
	{	

	}
	void onRewardedVideoFailedEvent (System.Object sender,System.EventArgs args)
	{	

	}

	public  void hideBannerAd ()
	{
		bannerView.Hide();
	}


}
