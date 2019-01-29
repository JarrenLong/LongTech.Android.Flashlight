using Android.Content;
using Android.Hardware;
using Android.Hardware.Camera2;
using Android.OS;

namespace com.LongTech.Android.Flashlight
{
  /// <summary>
  /// Provides generic service for toggling the flashlight's state
  /// </summary>
  public class FlashlightService
  {
#pragma warning disable CS0618
    private static bool FlashLightOn = false;
    private static Camera mCamera;
    private static CameraManager camManager;

    /// <summary>
    /// Turns the camera's flashlight on or off if supported
    /// </summary>
    /// <param name="enable"></param>
    public static void ToggleFlashlight(Context ctx)
    {
      FlashLightOn = !FlashLightOn;

      try
      {
        if (Build.VERSION.SdkInt >= Build.VERSION_CODES.M)
        {
          if (camManager == null)
            camManager = (CameraManager)ctx.GetSystemService(Context.CameraService);
          string cameraId = null; // Usually back camera is at 0 position.
          try
          {
            cameraId = camManager.GetCameraIdList()[0];
            camManager.SetTorchMode(cameraId, FlashLightOn);
          }
          catch { }
        }
        else
        {
          if (mCamera == null)
            mCamera = Camera.Open();
          var parameters = mCamera.GetParameters();
          parameters.FlashMode = FlashLightOn ? Camera.Parameters.FlashModeTorch : Camera.Parameters.FlashModeOff;
          mCamera.SetParameters(parameters);
          if (FlashLightOn)
            mCamera.StartPreview();
          else
            mCamera.StopPreview();
        }
      }
      catch { }
    }
#pragma warning restore CS0618
  }
}
