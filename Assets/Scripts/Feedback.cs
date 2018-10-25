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
        bool isFinished = SceneController.getParam("isFinished") == "true";
        bool isCorrect = SceneController.getParam("isCorrect") == "true";
        feedbackText.text += isCorrect ? "correct!" : "incorrect.";
        pwImage.sprite = SessionManager.CurrentAttempt.password.pwSprite;
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
