using UnityEngine;
using UnityEngine.UI;
#if(UNITY_2018_3_OR_NEWER)
using UnityEngine.Android;
#endif
using agora_gaming_rtc;

public class HelloUnity3D : MonoBehaviour
{
    public InputField mChannelNameInputField;
    public Text mShownMessage;
    public Text versionText;
    public Button joinChannel;
    public Button leaveChannel;
    public Button muteButton;

    private IRtcEngine mRtcEngine = null;

    // PLEASE KEEP THIS App ID IN SAFE PLACE
    // Get your own App ID at https://dashboard.agora.io/
    // After you entered the App ID, remove ## outside of Your App ID
    [SerializeField]
    private string appId = "YOUR APP ID";

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        muteButton.enabled = false;
    }

    // Use this for initialization
    void Start()
    {
#if (UNITY_2018_3_OR_NEWER)
			if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
			{
			
			} 
			else 
			{
				Permission.RequestUserPermission(Permission.Microphone);
			}
#endif
        //joinChannel.onClick.AddListener(JoinChannel);
        //leaveChannel.onClick.AddListener(LeaveChannel);
        //muteButton.onClick.AddListener(MuteButtonTapped);

        mRtcEngine = IRtcEngine.GetEngine(appId);
        versionText.GetComponent<Text>().text = "Version : " + getSdkVersion();
        PlayerPrefs.SetInt("keydown", 0);

        /*mRtcEngine.OnJoinChannelSuccess += (string channelName, uint uid, int elapsed) =>
        {
            string joinSuccessMessage = string.Format("joinChannel callback uid: {0}, channel: {1}, version: {2}", uid, channelName, getSdkVersion());
            Debug.Log(joinSuccessMessage);
            mShownMessage.GetComponent<Text>().text = (joinSuccessMessage);
            muteButton.enabled = true;
        };

        mRtcEngine.OnLeaveChannel += (RtcStats stats) =>
        {
            string leaveChannelMessage = string.Format("onLeaveChannel callback duration {0}, tx: {1}, rx: {2}, tx kbps: {3}, rx kbps: {4}", stats.duration, stats.txBytes, stats.rxBytes, stats.txKBitRate, stats.rxKBitRate);
            Debug.Log(leaveChannelMessage);
            mShownMessage.GetComponent<Text>().text = (leaveChannelMessage);
            muteButton.enabled = false;
            // reset the mute button state
            if (isMuted)
            {
                MuteButtonTapped();
            }
        };

        mRtcEngine.OnUserJoined += (uint uid, int elapsed) =>
        {
            string userJoinedMessage = string.Format("onUserJoined callback uid {0} {1}", uid, elapsed);
            Debug.Log(userJoinedMessage);
        };

        mRtcEngine.OnUserOffline += (uint uid, USER_OFFLINE_REASON reason) =>
        {
            string userOfflineMessage = string.Format("onUserOffline callback uid {0} {1}", uid, reason);
            Debug.Log(userOfflineMessage);
        };

        mRtcEngine.OnVolumeIndication += (AudioVolumeInfo[] speakers, int speakerNumber, int totalVolume) =>
        {
            if (speakerNumber == 0 || speakers == null)
            {
                Debug.Log(string.Format("onVolumeIndication only local {0}", totalVolume));
            }

            for (int idx = 0; idx < speakerNumber; idx++)
            {
                string volumeIndicationMessage = string.Format("{0} onVolumeIndication {1} {2}", speakerNumber, speakers[idx].uid, speakers[idx].volume);
                Debug.Log(volumeIndicationMessage);
            }
        };

        mRtcEngine.OnUserMutedAudio += (uint uid, bool muted) =>
        {
            string userMutedMessage = string.Format("onUserMuted callback uid {0} {1}", uid, muted);
            Debug.Log(userMutedMessage);
        };

        mRtcEngine.OnWarning += (int warn, string msg) =>
        {
            string description = IRtcEngine.GetErrorDescription(warn);
            string warningMessage = string.Format("onWarning callback {0} {1} {2}", warn, msg, description);
            Debug.Log(warningMessage);
        };

        mRtcEngine.OnError += (int error, string msg) =>
        {
            string description = IRtcEngine.GetErrorDescription(error);
            string errorMessage = string.Format("onError callback {0} {1} {2}", error, msg, description);
            Debug.Log(errorMessage);
        };

        mRtcEngine.OnRtcStats += (RtcStats stats) =>
        {
            string rtcStatsMessage = string.Format("onRtcStats callback duration {0}, tx: {1}, rx: {2}, tx kbps: {3}, rx kbps: {4}, tx(a) kbps: {5}, rx(a) kbps: {6} users {7}",
                stats.duration, stats.txBytes, stats.rxBytes, stats.txKBitRate, stats.rxKBitRate, stats.txAudioKBitRate, stats.rxAudioKBitRate, stats.userCount);
            Debug.Log(rtcStatsMessage);

            int lengthOfMixingFile = mRtcEngine.GetAudioMixingDuration();
            int currentTs = mRtcEngine.GetAudioMixingCurrentPosition();

            string mixingMessage = string.Format("Mixing File Meta {0}, {1}", lengthOfMixingFile, currentTs);
            Debug.Log(mixingMessage);
        };

        mRtcEngine.OnAudioRouteChanged += (AUDIO_ROUTE route) =>
        {
            string routeMessage = string.Format("onAudioRouteChanged {0}", route);
            Debug.Log(routeMessage);
        };

        mRtcEngine.OnRequestToken += () =>
        {
            string requestKeyMessage = string.Format("OnRequestToken");
            Debug.Log(requestKeyMessage);
        };

        mRtcEngine.OnConnectionInterrupted += () =>
        {
            string interruptedMessage = string.Format("OnConnectionInterrupted");
            Debug.Log(interruptedMessage);
        };

        mRtcEngine.OnConnectionLost += () =>
        {
            string lostMessage = string.Format("OnConnectionLost");
            Debug.Log(lostMessage);
        };

        mRtcEngine.SetLogFilter(LOG_FILTER.INFO);

        mRtcEngine.SetChannelProfile(CHANNEL_PROFILE.CHANNEL_PROFILE_COMMUNICATION);

        // mRtcEngine.SetChannelProfile (CHANNEL_PROFILE.CHANNEL_PROFILE_LIVE_BROADCASTING);
        // mRtcEngine.SetClientRole (CLIENT_ROLE.BROADCASTER);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("keydown") == 0 && Input.GetKeyDown(KeyCode.V))
            JoinChannel();
        else if (Input.GetKeyDown(KeyCode.V))
            LeaveChannel();
            
    }

    
    public void JoinChannel()
    {
        //string channelName = mChannelNameInputField.text.Trim();
        PlayerPrefs.SetInt("keydown", 1);
        string hg = PlayerPrefs.GetString("roomname");
        Debug.Log(string.Format("tap joinChannel with channel name {0}", hg));
        mRtcEngine.JoinChannel(hg, "extra", 0);
        
    }

    public void LeaveChannel()
    {
        // int duration = mRtcEngine.GetAudioMixingDuration ();
        // int current_duration = mRtcEngine.GetAudioMixingCurrentPosition ();

        // IAudioEffectManager effect = mRtcEngine.GetAudioEffectManager();
        // effect.StopAllEffects ();
        PlayerPrefs.SetInt("keydown", 0);
        mRtcEngine.LeaveChannel();
        string channelName = mChannelNameInputField.text.Trim();
        Debug.Log(string.Format("left channel name {0}", channelName));
    }

    void OnApplicationQuit()
    {
        if (mRtcEngine != null)
        {
            IRtcEngine.Destroy();
        }
    }


    public string getSdkVersion()
    {
        string ver = IRtcEngine.GetSdkVersion();
        if (ver == "2.9.1.45")
        {
            ver = "2.9.2";  // A conversion for the current internal version#
        }
        else
        {
            if (ver == "2.9.1.46")
            {
                ver = "2.9.2.1";  // A conversion for the current internal version#
            }
        }
        return ver;
    }


    bool isMuted = false;
    void MuteButtonTapped()
    {
        string labeltext = isMuted ? "Mute" : "Unmute";
        Text label = muteButton.GetComponentInChildren<Text>();
        if (label != null)
        {
            label.text = labeltext;
        }
        isMuted = !isMuted;
        mRtcEngine.EnableLocalAudio(!isMuted);
    }
}
