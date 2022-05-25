using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class DailyReward : MonoBehaviour
{



    //UI
    public Text timeLabel; //only use if your timer uses a label
    public Button timerButton; //used to disable button when needed
    [SerializeField] GameObject rewardUI;
    [SerializeField] GameObject rewardTexts;
    [SerializeField] GameObject[] rewardImage;
    [SerializeField] GameObject noMoreRewardsPanel;
    [SerializeField] Image progress;
    [SerializeField] Text currentDay;

    public Text timeRemain;


    public enum rewardType
    {
        coins,
        eggs
    }
    // <>
    public rewardType[] typeReward;
    public int[] rewardAmount;
    public Text amountText;
    private int nextRewardIndex;
    private int rewardImageIndex;

    //TIME ELEMENTS
    public int hours; //to set the hours
    public int minutes; //to set the minutes
    public int seconds; //to set the seconds
    private bool _timerComplete = false;
    private bool _timerIsReady;
    private TimeSpan _startTime;
    private TimeSpan _endTime;
    private TimeSpan _remainingTime;
    //progress filler
    private float _value = 1f;
    //reward to claim
    public int RewardToEarn;




    //startup
    void Start()
    {
       // StartCoroutine(InitializeAll());

    }
    IEnumerator InitializeAll()
    {
        yield return new WaitForSeconds(1f);
        InitializeThings();
    }
    public void InitializeThings()
    {
        nextRewardIndex = PlayerPrefs.GetInt("nextRewardIndex", 0);
        //  currentDay.text = "REGALO" + " " + nextRewardIndex.ToString();


        if (PlayerPrefs.GetString("_timer") == "")
        {
            //   Debug.Log("==> Enableing button");
            PlayerPrefs.SetString("_timer", "Standby");


            updateTime();

        }
        else
        {
            //disableButton();
           // StartCoroutine(CheckTime());
        }


    }

    //update method to make the progress tick
    void Update()
    {

        if (_timerIsReady)
        {
            if (!_timerComplete && PlayerPrefs.GetString("_timer") != "")
            {
                _value -= Time.deltaTime * 1f / (float)_endTime.TotalSeconds;

                progress.fillAmount = _value;
                var remain = _value * 100 - 100;
                timeRemain.text = Mathf.Abs(remain).ToString("0");
                //this is called once only
                if (_value <= 0 && !_timerComplete)
                {
                    //when the timer hits 0, let do a quick validation to make sure no speed hacks.
                    validateTime();
                    _timerComplete = true;

                }
            }


        }
    }



    //update the time information with what we got some the internet
    private void updateTime()
    {
        if (PlayerPrefs.GetString("_timer") == "Standby")
        {
            PlayerPrefs.SetString("_timer", TimeManager.sharedInstance.getCurrentTimeNow());

            PlayerPrefs.SetInt("_date", TimeManager.sharedInstance.getCurrentDateNow());
        }
        else if (PlayerPrefs.GetString("_timer") != "" && PlayerPrefs.GetString("_timer") != "Standby")
        {
            int _old = PlayerPrefs.GetInt("_date");
            int _now = TimeManager.sharedInstance.getCurrentDateNow();


            //check if a day as passed
            if (_now > _old)
            {//day as passed
             //  Debug.Log("Day has passed - configuring new date");

                PlayerPrefs.SetInt("_date", TimeManager.sharedInstance.getCurrentDateNow());

                if (PlayerPrefs.GetString("_timer") != "" && PlayerPrefs.GetString("_timer") != "Standby")
                {
                    // Debug.Log("==> Enableing button");

                    _timerComplete = true;

                    enableButton();

                    timeRemain.text = 100.ToString();
                    progress.fillAmount = 0;

                    //PlayerPrefs.SetString("_timer", "Standby");

                    //  updateTime();

                }
                //_configTimerSettings();
                return;
            }
            else if (_now == _old)
            {//same day

                _configTimerSettings();
                return;
            }
            else
            {
                //  Debug.Log("error with date");
                return;
            }
        }

        //Debug.Log("Day had passed - configuring now");
        if (PlayerPrefs.GetString("_timer") == "")
        {
            // PlayerPrefs.SetString("_timer", TimeManager.sharedInstance.getCurrentTimeNow());
            StartCoroutine(ConfigTimerRutine());
        }
        else
            _configTimerSettings();
    }


    IEnumerator ConfigTimerRutine()
    {
        yield return new WaitForSeconds(1f);


        if (PlayerPrefs.GetString("_timer") == "")
        {
            PlayerPrefs.SetString("_timer", TimeManager.sharedInstance.getCurrentTimeNow());
            StartCoroutine(ConfigTimerRutine());
        }
        else
            _configTimerSettings();
    }
    //setting up and configureing the values
    //update the time information with what we got some the internet
    private void _configTimerSettings()
    {
        _startTime = TimeSpan.Parse(PlayerPrefs.GetString("_timer"));
        _endTime = TimeSpan.Parse(hours + ":" + minutes);
        TimeSpan temp = TimeSpan.Parse(TimeManager.sharedInstance.getCurrentTimeNow());
        TimeSpan diff = temp.Subtract(_startTime);
        _remainingTime = _endTime.Subtract(diff);
        //start timmer where we left off
        setProgressWhereWeLeftOff();


        // Debug.Log("diff" + " " + diff);
        //  Debug.Log("_endTime" + " " + _endTime);
        if (diff >= _endTime)
        {
            _timerComplete = true;

            //   Debug.Log("timer ended");
            timeRemain.text = 100.ToString();

            enableButton();
        }
        else
        {

            // Debug.Log("timer not ended");
            _timerComplete = false;
            disableButton();
            _timerIsReady = true;


        }
    }

    //initializing the value of the timer
    private void setProgressWhereWeLeftOff()
    {
        float ah = 1f / (float)_endTime.TotalSeconds;
        float bh = 1f / (float)_remainingTime.TotalSeconds;
        _value = ah / bh;

        progress.fillAmount = _value;

    }


    //use to check the current time before completely any task. use this to validate
    private IEnumerator CheckTime()
    {
        disableButton();
        //timeLabel.text = "Checking the time";
        // Debug.Log("==> Checking for new time");
        yield return StartCoroutine(TimeManager.sharedInstance.getTime());
        updateTime();
        //  Debug.Log("==> Time check complete!");


    }


    //trggered on button click
    public void rewardClicked()
    {
        //  Debug.Log("==> Claim Button Clicked");
        claimReward();
        PlayerPrefs.SetString("_timer", "Standby");
        StartCoroutine(CheckTime());
    }

    //validator
    private void validateTime()
    {
        // Debug.Log("==> Validating time to make sure no speed hack!");
        StartCoroutine(CheckTime());
    }







    //enable button function
    private void enableButton()
    {
        timerButton.interactable = true;
        // timeLabel.text = "CLAIM REWARD";
    }



    //disable button function
    private void disableButton()
    {
        timerButton.interactable = false;
        // timeLabel.text = "NOT READY";
    }

    public void claimReward()
    {

        showAd();


        if (typeReward[nextRewardIndex] == rewardType.coins)
        {

            GameController.coins += rewardAmount[nextRewardIndex];

        }
        else
        {

            HuevosManager.eggsSavings += rewardAmount[nextRewardIndex];
        }

        Manager.sharedInstance.SaveData();

        nextRewardIndex++;

        if (nextRewardIndex >= rewardAmount.Length)
        {
            nextRewardIndex = 0;
        }

        PlayerPrefs.SetInt("nextRewardIndex", nextRewardIndex);

        //currentDay.text = "REGALO" + " " + nextRewardIndex.ToString();

        CloseAllRewards();


    }

    void showAd()
    {
        ManagerAds.instance.showInterstitialAll();
    }


    public void OpenRewardButton()
    {
        rewardUI.SetActive(true);

        if (_timerComplete)
        {
            nextRewardIndex = PlayerPrefs.GetInt("nextRewardIndex", 0);

            //  currentDay.text = "REGALO" + " " + nextRewardIndex.ToString();

            OpenAllRewardsUI();

            if (typeReward[nextRewardIndex] == rewardType.coins)
            {
                rewardImageIndex = 0;
            }
            else
            {
                rewardImageIndex = 2;
            }

            rewardImage[rewardImageIndex].SetActive(true);

        }
        else
            CloseAllRewards();

    }

    public void CloseRewardButton()
    {
        rewardUI.SetActive(false);
    }

    public void CloseAllRewards()
    {
        noMoreRewardsPanel.SetActive(true);
        rewardTexts.SetActive(false);

        rewardImage[rewardImageIndex].SetActive(false);

    }


    void OpenAllRewardsUI()
    {
        noMoreRewardsPanel.SetActive(false);
        rewardTexts.SetActive(true);
        amountText.text = "+" + rewardAmount[nextRewardIndex].ToString();

    }

}