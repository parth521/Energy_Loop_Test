using UnityEngine;

public class HapticManager : Singleton<HapticManager>
{

    public void LightHaptic()
    {
        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
        }
    }
    public void MediumHaptic()
    {
        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
        }
    }

    // Method to trigger heavy haptic feedback
    public void HeavyHaptic()
    {
        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
            // Implement the heaviest haptic feedback if possible
        }
    }

    // Method to trigger custom haptic feedback
    public void CustomHaptic(long[] pattern, int[] amplitudes, int repeat = -1)
    {
        if (SystemInfo.supportsVibration)
        {
            // Use platform-specific haptics APIs for custom patterns
            // E.g., Android VibrationEffect (API level 26+)
#if UNITY_ANDROID && !UNITY_EDITOR
            using (var vibrator = new AndroidJavaClass("android.os.Vibrator"))
            {
                if (vibrator != null)
                {
                    vibrator.Call("vibrate", pattern, repeat);
                }
            }
#elif UNITY_IOS && !UNITY_EDITOR
            // Implement iOS custom haptics if possible
            Handheld.Vibrate();
#else
            Handheld.Vibrate();
#endif
        }
    }
}
