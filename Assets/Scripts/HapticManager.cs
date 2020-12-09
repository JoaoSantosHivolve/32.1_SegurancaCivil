using Common;
using Valve.VR;

public class HapticManager : Singleton<HapticManager>
{
    public SteamVR_Action_Vibration hapticAction;

    public void VibrateController(SteamVR_Input_Sources source, float magnitude = 0.5f, float duration = 0f, float secondsFromNow = 0f)
    {
        hapticAction.Execute(secondsFromNow, duration, 5f, magnitude, source);
    }
}
