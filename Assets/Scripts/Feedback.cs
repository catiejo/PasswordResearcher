using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour {
    public Text feedbackText;
    public Image pwImage;
    public Button nextButton;
    public Text sessionOverText;

	void Start () {
        if (SessionManager.CurrentAttempt != null) {
            EmailSender.SendEmailWithAttempt(SessionManager.CurrentAttempt.ToString());
            pwImage.sprite = SessionManager.CurrentAttempt.password.pwSprite;
        }
        bool isFinished = SceneController.getParam("isFinished") == "true";
        bool isCorrect = SceneController.getParam("isCorrect") == "true";
        if (isCorrect) {
            feedbackText.text += "correct!";
            feedbackText.color = Color.green;
        } else {
            feedbackText.text += "incorrect";
            feedbackText.color = Color.red;
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
