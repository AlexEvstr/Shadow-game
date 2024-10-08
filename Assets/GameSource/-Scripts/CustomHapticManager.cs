using System.Runtime.InteropServices;
using UnityEngine;

public class CustomHapticManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ExecuteLightHaptic();

    [DllImport("__Internal")]
    private static extern void ExecuteMediumHaptic();

    [DllImport("__Internal")]
    private static extern void ExecuteHeavyHaptic();

    [DllImport("__Internal")]
    private static extern void ExecuteErrorHaptic();

    public void TriggerLightVibration()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            ExecuteLightHaptic();
        }
    }

    public void TriggerMediumVibration()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            ExecuteMediumHaptic();
        }
    }

    public void TriggerHeavyVibration()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            ExecuteHeavyHaptic();
        }
    }

    public void TriggerErrorVibration()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            ExecuteErrorHaptic();
        }
    }
}