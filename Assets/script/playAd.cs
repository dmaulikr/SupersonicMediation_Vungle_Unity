using UnityEngine;
using System.Collections;

public class playAd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Supersonic.Agent.start();
		registerEvents ();
		if (Application.platform == RuntimePlatform.WindowsPlayer) {
			Debug.Log("___________windows here");
		}
		else if (Application.platform == RuntimePlatform.Android) {
			Debug.Log("___________Android");
			Supersonic.Agent.initInterstitial("562fe89d", "unique_user_id");
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Debug.Log("___________IPhonePlayer");
			Supersonic.Agent.initInterstitial("577551dd", "unique_user_id");
		}


			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(){
		
		if (Supersonic.Agent.isInterstitialReady()) {
			DebugLog ("___________ready Ad");
			Supersonic.Agent.showInterstitial();
		} else {
			DebugLog ("___________no Ad");
		}


	}

	public void LoadInterstitialButtonClicked () {
		Debug.Log ("LoadInterstitialButtonClicked");
		Supersonic.Agent.loadInterstitial();
	}

	void DebugLog(string message) {
		Debug.Log("logTag" + System.DateTime.Today +": " + message);
	}
	void OnApplicationPause(bool isPaused) { 
		if (isPaused) {
			Supersonic.Agent.onPause ();
		}else{                   
			Supersonic.Agent.onResume ();
		}
	}
	private void registerEvents () {
		SupersonicEvents.onInterstitialInitSuccessEvent += InterstitialInitSuccessEvent;
		SupersonicEvents.onInterstitialInitFailedEvent += InterstitialInitFailEvent; 
		SupersonicEvents.onInterstitialReadyEvent += InterstitialReadyEvent;
		SupersonicEvents.onInterstitialLoadFailedEvent += InterstitialLoadFailedEvent;
		SupersonicEvents.onInterstitialShowSuccessEvent += InterstitialShowSuccessEvent; 
		SupersonicEvents.onInterstitialShowFailedEvent += InterstitialShowFailEvent; 
		SupersonicEvents.onInterstitialClickEvent += InterstitialAdClickedEvent;
		SupersonicEvents.onInterstitialOpenEvent += InterstitialAdOpenedEvent;
		SupersonicEvents.onInterstitialCloseEvent += InterstitialAdClosedEvent;
	}


	/* * Invoked when Interstitial initialization process completes successfully. */ 
	void InterstitialInitSuccessEvent () { 
		Debug.Log ("_____________InterstitialInitSuccessEvent"); } 

	/* * Invoked when the initialization process has failed. 
* @param description - string - contains information about the failure. */ 
	void InterstitialLoadFailedEvent (SupersonicError error) { 
		Debug.Log ("_____________InterstitialLoadFailedEvent, code: " + error.getCode()+ ", description : " +error.getDescription()); } 

	/* * Invoked right before the Interstitial screen is about to open. */ 
	void InterstitialShowSuccessEvent() { Debug.Log ("_____________InterstitialShowSuccessEvent"); } 

	/* * Invoked when the ad fails to show. * @param description - string - contains information about the failure. */ 
	void InterstitialShowFailEvent(SupersonicError error) { 
		Debug.Log ("_____________InterstitialShowFailEvent, code : " +error.getCode() + ", description : " +error.getDescription()); } 

	/* * Invoked upon ad availability change. * @param available - bool - true when interstitial ad is ready to be presented or false * otherwise. */ 
	void ISAvailability (bool available) { 
		//Show the Ad if available value is true 
	} 

	/* * Invoked when end user clicked on the interstitial ad */ 
	void InterstitialAdClickedEvent () { Debug.Log ("_____________InterstitialAdClickedEvent"); } 

	/* * Invoked when the interstitial ad closed and the user goes back to the application screen. */ 
	void InterstitialAdClosedEvent () { Debug.Log ("_____________InterstitialAdClosedEvent"); } 

	/* * Invoked when the interstitial initialization process fails */ 
	void InterstitialInitFailEvent(SupersonicError error){ Debug.Log ("_____________InterstitialInitFailEvent, code : " +error.getCode()+ ", description : " +error.getDescription()); } 

	/* * Invoked when the Interstitial is Ready to shown after load function is called */ 
	void InterstitialReadyEvent() { Debug.Log ("_____________InterstitialReadyEvent"); } 

	/* * Invoked when the Interstitial Ad Unit has opened */ 
	void InterstitialAdOpenedEvent() { Debug.Log ("_____________InterstitialAdOpenedEvent"); }


}
