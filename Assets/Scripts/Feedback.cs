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

    void Start()
    {
        emailAttempted = false;
        isFinished = SceneManagerWithParameters.GetParam("isFinished") == "true";
        isCorrect = SceneManagerWithParameters.GetParam("isCorrect") == "true";
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
        if (isFinished)
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
