using Android.App;
using Android.Gms.Ads;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace LongTech.Android.Flashlight
{
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
  public class MainActivity : AppCompatActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.activity_main);

      MobileAds.Initialize(this, GetString(Resource.String.flashlightAdAppId));

      mAdView = FindViewById<AdView>(Resource.Id.adView);
      mAdView.AdListener = new MyAdListener();
      var adRequest = new AdRequest.Builder().Build();
      mAdView.LoadAd(adRequest);

      RelativeLayout fab = FindViewById<RelativeLayout>(Resource.Id.toggleFlashlight);
      fab.Click += (s, e) => { FlashlightService.ToggleFlashlight(this); };
    }

    protected AdView mAdView;

    protected override void OnPause()
    {
      if (mAdView != null)
        mAdView.Pause();

      base.OnPause();
    }

    protected override void OnResume()
    {
      base.OnResume();

      if (mAdView != null)
        mAdView.Resume();
    }

    protected override void OnDestroy()
    {
      if (mAdView != null)
        mAdView.Destroy();

      base.OnDestroy();
    }

    class MyAdListener : AdListener
    {
      public override void OnAdClicked()
      {
        base.OnAdClicked();
      }
      public override void OnAdClosed()
      {
        base.OnAdClosed();
      }
      public override void OnAdFailedToLoad(int errorCode)
      {
        base.OnAdFailedToLoad(errorCode);
      }
      public override void OnAdImpression()
      {
        base.OnAdImpression();
      }
      public override void OnAdLeftApplication()
      {
        base.OnAdLeftApplication();
      }
      public override void OnAdLoaded()
      {
        base.OnAdLoaded();
      }
      public override void OnAdOpened()
      {
        base.OnAdOpened();
      }
    }
  }
}
