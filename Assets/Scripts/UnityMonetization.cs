using UnityEngine;
using UnityEngine.Advertisements;

public class UnityMonetization : MonoBehaviour, IUnityAdsListener
{
    public InGameGameManager inGameGameManager;

    private string _androidId = "3968093";
    private bool _testMode = true;
    private string _myPlacementId = "rewardedVideo";

    void Start()
    {
        Advertisement.Initialize(_androidId, _testMode);

        Advertisement.AddListener(this);
    }

    public void DisplayInterstitialAd()
    {
        Advertisement.Show();
    }

    public void DisplayVideoAd()
    {
        Advertisement.Show(_myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.

            inGameGameManager.ResumeGame();
            Debug.LogWarning("You  get a reward.");
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.

            Debug.LogWarning("You  do not get a reward.");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == _myPlacementId)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
