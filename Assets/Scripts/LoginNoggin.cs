using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginNoggin : MonoBehaviour {
    public Image passwordImage;
    public Text infoText;
    public InputField passwordField;

    public static string EnteredPassword { get; private set; }
    private float timeElapsed;
    private float typingStarted;
    private float typingStopped;
    private TouchScreenKeyboard keyboard;
    private bool doneWasClicked;

    void Start () {
        // initializing variables...
        doneWasClicked = false;
        EnteredPassword = "";
        timeElapsed = 0.0f;
        typingStarted = -1.0f; // -1 so there's no confusion that it's uninitialized.
        typingStopped = -1.0f;
        SessionManager.StartNextAttempt();
        passwordImage.sprite = SessionManager.CurrentAttempt.password.pwSprite;
        DisplayKeyboard();
    }

    void Update () {
        timeElapsed += Time.deltaTime;
        // On Android, the inputstring is either the entire string or the empty string.
        // This differs from the docs that say it should only be the letter(s) entered
        // in the current frame.
        if (Input.inputString.Length > 0)
        {
            EnteredPassword = Input.inputString;
            // Get the time stamp of first and last character typed.
            if (typingStarted >= 0.0f) {
                typingStopped = timeElapsed;
            } else {
                typingStarted = timeElapsed;
                typingStopped = timeElapsed;
            }
        }
        if (keyboard != null)
        {
            switch (keyboard.status)
            {
                case TouchScreenKeyboard.Status.Canceled:
                    DisplayKeyboard();
                    break;
                case TouchScreenKeyboard.Status.LostFocus:
                    DisplayKeyboard();
                    break;
                case TouchScreenKeyboard.Status.Done:
                    OnPasswordSubmitted();
                    break;
            }
        }
    }

    /// <summary>
    /// Places focus on Password Input. The keyboard appears automatically. 
    /// This is in a separate function so it can be  used as a click handler 
    /// in the inspector.
    /// </summary>
    public void DisplayKeyboard() {
        doneWasClicked = false;
        keyboard = TouchScreenKeyboard.Open(EnteredPassword, TouchScreenKeyboardType.Default, false, false, SessionManager.passwordIsMasked, false, "type the password here");
        passwordField.ActivateInputField();
    }

    /// <summary>
    /// Finishes the CurrentAttempt (unless password is blank)
    /// </summary>
    public void OnPasswordSubmitted() {
        if (doneWasClicked) {
            // Make sure this function is only called once.
            return;
        }
        doneWasClicked = true;
        if (EnteredPassword == "")
        {
            StartCoroutine(WaitAndDisplayKeybaord());
            return;
        }
        // non-empty password was entered...finish the attempt
        SessionManager.FinishAttempt(typingStopped - typingStarted, timeElapsed - typingStopped, EnteredPassword);
        // set parameters for next scene
        string isFinished = SessionManager.passwordsRemaining ? "false" : "true";
        string isCorrect = (EnteredPassword == SessionManager.CurrentAttempt.password.expected) ? "true" : "false";
        SceneController.setParam("isFinished", isFinished);
        SceneController.setParam("isCorrect", isCorrect);
        SceneController.Load("Feedback Screen");

    }

    /// <summary>
    /// If the text is empty and the user clicks "ok" or the check mark,
    /// the keyboard fritzes and constantly appears and reappears. This 
    /// method waits for the keyboard to disappear completely and then makes
    /// it reappear.
    /// </summary>
    IEnumerator WaitAndDisplayKeybaord() {
        yield return new WaitForSeconds(0.5f);
        infoText.text = "Password can't be blank!";
        infoText.color = Color.red;
        DisplayKeyboard();
    }
}