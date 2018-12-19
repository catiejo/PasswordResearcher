using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginNoggin : MonoBehaviour
{
    public Image passwordImage;
    public Text infoText;
    public InputField passwordField;

    public static string EnteredPassword { get; private set; }
    private float timeElapsed;
    private float typingStarted;
    private float typingStopped;
    private TouchScreenKeyboard keyboard;
    private bool doneWasClicked;
    private int numBackspacesForCurrentAttempt;

    void Start()
    {
#if UNITY_IOS
        // on iPhone, I can't seem to get the keyboard to display masked characters unless
        // the field is specifically marked as a password...here's a HACK/workaround.
        if (SessionManager.PasswordsAreMasked)
        {
            passwordField.contentType = InputField.ContentType.Password;
        }
        else
        {
            // General > Keyboards: enable english or German depending on which they prefer
            // Turn off all settings exvept capslock.
            // Also turn off autofill (Passwords & Accounts > Autofill Passwords)
            passwordField.contentType = InputField.ContentType.Standard;
        }
#endif
        // initializing variables...
        numBackspacesForCurrentAttempt = 0;
        doneWasClicked = false;
        EnteredPassword = "";
        timeElapsed = 0.0f;
        typingStarted = -1.0f; // -1 so there's no confusion that it's uninitialized.
        typingStopped = -1.0f;
        SessionManager.StartNextAttempt();
        if (SessionManager.CurrentAttempt != null)
        {
            passwordImage.sprite = SessionManager.CurrentAttempt.password.pwSprite;
        } 
        DisplayKeyboard();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (keyboard != null && keyboard.text != EnteredPassword)
        {
            // Check if backspace was used.
            if (EnteredPassword.Length > keyboard.text.Length)
            {
                numBackspacesForCurrentAttempt++;
            }
            EnteredPassword = keyboard.text;
            if (typingStarted >= 0.0f)
            {
                typingStopped = timeElapsed;
            }
            else
            {
                typingStarted = timeElapsed;
                typingStopped = timeElapsed;
            }
        }
        // Make sure they keyboard is always visible, or process the password
        // if the user clicks "enter" or "ok"
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
    /// Places focus on Password Input and gets a reference to the current
    /// keyboard. The passwordField is off-screen, and the built-in keyboard
    /// text field that hovers above the keyboard is used instead so it looks
    /// more natural.
    /// </summary>
    public void DisplayKeyboard() {
        doneWasClicked = false;
        keyboard = TouchScreenKeyboard.Open(EnteredPassword, TouchScreenKeyboardType.Default, false, false, SessionManager.PasswordsAreMasked, false, "type the password here");
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
            // HACK -- see function description.
            StartCoroutine(WaitAndDisplayKeybaord());
            return;
        }
        // non-empty password was entered...finish the attempt
        SessionManager.FinishAttempt(numBackspacesForCurrentAttempt, typingStarted, typingStopped,  timeElapsed, EnteredPassword);
        // set parameters for next scene
        string isFinished = SessionManager.PasswordsRemaining ? "false" : "true";
        string isCorrect = (EnteredPassword == SessionManager.CurrentAttempt.password.expected) ? "true" : "false";
        SceneManagerWithParameters.SetParam("isFinished", isFinished);
        SceneManagerWithParameters.SetParam("isCorrect", isCorrect);
        SceneManagerWithParameters.Load("Feedback Screen");
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