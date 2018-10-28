using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour {
    public Text feedbackText;
    public Image passwordImage;
    public Button nextButton;
    public Text sessionOverText;
    public Color correctColor;
    public Color incorrectColor;

    void Start () {
        if (SessionManager.CurrentAttempt != null) {
            if (Application.internetReachability != NetworkReachability.NotReachable) {
                string emailSubject = "Attempt " + SessionManager.CurrentAttempt.totalAttemptNumber + " for " + SessionManager.CurrentAttempt.participantID;
                EmailSender.SendEmail(emailSubject, SessionManager.CurrentAttempt.ToString());
            }
        }
        bool isFinished = SceneController.getParam("isFinished") == "true";
        bool isCorrect = SceneController.getParam("isCorrect") == "true";
        if (isCorrect) {
            feedbackText.text += "correct!";
            feedbackText.color = correctColor;
        } else {
            feedbackText.text += "incorrect.";
            feedbackText.color = incorrectColor;
        }
        if (isFinished) {
            sessionOverText.gameObject.SetActive(true);
            nextButton.interactable = false;
            nextButton.GetComponentInChildren<Text>().text = "Thank You.";
        }
	}

    public void OnNextClicked() {
        SceneController.Load("Login Screen");
    }
}
