using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour
{
    public Text feedbackText;
    public Image passwordImage;
    public Button nextButton;
    public Text sessionOverText;
    public Color correctColor;
    public Color incorrectColor;

    private bool emailAttempted;
    private bool isFinished;
    private bool isCorrect;
    private bool isSecondRoundStarted;

    void Start()
    {
        emailAttempted = false;
        isFinished = SceneManagerWithParameters.GetParam("isFinished") == "true";
        isCorrect = SceneManagerWithParameters.GetParam("isCorrect") == "true";
        isSecondRoundStarted = SceneManagerWithParameters.GetParam("Trigger Second Round") == "true";
        if (isCorrect)
        {
            feedbackText.text += "correct!";
            feedbackText.color = correctColor;
        }
        else
        {
            feedbackText.text += "incorrect.";
            feedbackText.color = incorrectColor;
        }
        if (isSecondRoundStarted) {
            sessionOverText.gameObject.SetActive(true);
            sessionOverText.text = "The first part of the study is complete. Continue onto the next section below.";
            nextButton.GetComponent<Image>().color = Color.cyan;
            nextButton.GetComponentInChildren<Text>().text = "Continue";
            isFinished = false;
        }
        else if (isFinished)
        {
            sessionOverText.gameObject.SetActive(true);
            nextButton.interactable = false;
            nextButton.GetComponentInChildren<Text>().text = "Thank You.";
        }
    }

    void Update()
    {
        // Called in update instead of start so that the screen loads even if
        // the email takes awhile to send (slow network connectivity, etc)
        if (isFinished && !emailAttempted)
        {
            emailAttempted = true; //only try once...you can retry from Admin if you want.
            SessionManager.EmailEntireSession();
        }
    }

    public void OnNextClicked() {
        SceneManagerWithParameters.Load("Login Screen");
    }
}
