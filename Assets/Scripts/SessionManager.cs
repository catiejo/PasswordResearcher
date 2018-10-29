using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionManager : MonoBehaviour {
    public PasswordController passController;
    public Toggle passwordMasking;

    public static Attempt CurrentAttempt { get; private set; }
    public static bool PasswordsRemaining { get; private set; }
    public static bool PasswordsAreMasked { get; private set; }

    private static List<Attempt> sessionAttempts;
    private static int attemptNumber;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Finishes the attempt.
    /// </summary>
    /// <param name="timeToType">Time taken to enter the password.</param>
    /// <param name="timeToReview">Time taken between last keypress and pressing the login.</param>
    /// <param name="enteredPassword">Entered password.</param>
    public static void FinishAttempt(float timeToType, float timeToReview, string enteredPassword) {
        sessionAttempts[attemptNumber - 1].FinishAttempt(timeToType, timeToReview, enteredPassword);
        Debug.Log(sessionAttempts[attemptNumber - 1].ToString());
    }

    /// <summary>
    /// Sets CurrentAttempt to the next one in line.
    /// </summary>
    public static void StartNextAttempt() {
        attemptNumber++;
        PasswordsRemaining = attemptNumber < sessionAttempts.Count;
        if (attemptNumber > sessionAttempts.Count)
        {
            CurrentAttempt = null;
            Debug.LogError("Trying to make an attempt out of bounds");
        }
        else
        {
            CurrentAttempt = sessionAttempts[attemptNumber - 1];
        }
    }

    /// <summary>
    /// Generates a randomized list of 15 attempts (3 different password types 5 times).
    /// Loads the login scene when finished.
    /// </summary>
    /// <param name="participant">Participant ID.</param>
    public void StartSession(Text participant)
    {
        Password typical = passController.GetRandomPassword(PassType.Typical);
        Password random = passController.GetRandomPassword(PassType.Random);
        Password phrase = passController.GetRandomPassword(PassType.Phrase);
        // create a list of 15 attempts
        sessionAttempts = new List<Attempt>();
        for (int i = 0; i < 5; i++)
        {
            sessionAttempts.Add(new Attempt(typical, participant.text));
            sessionAttempts.Add(new Attempt(random, participant.text));
            sessionAttempts.Add(new Attempt(phrase, participant.text));
        }
        // shuffle the attempts in a random order
        for (int i = 0; i < sessionAttempts.Count; i++)
        {
            Attempt temp = sessionAttempts[i];
            int rando = UnityEngine.Random.Range(i, sessionAttempts.Count);
            sessionAttempts[i] = sessionAttempts[rando];
            sessionAttempts[rando] = temp;
        }
        int typicalCounter = 1;
        int randomCounter = 1;
        int phraseCounter = 1;
        int totalCounter = 1;
        // assign attempt numbers to each.
        foreach (Attempt a in sessionAttempts)
        {
            switch (a.password.type)
            {
                case PassType.Typical:
                    a.SetAttemptNumbers(totalCounter, typicalCounter);
                    typicalCounter++;
                    break;
                case PassType.Phrase:
                    a.SetAttemptNumbers(totalCounter, phraseCounter);
                    phraseCounter++;
                    break;
                case PassType.Random:
                    a.SetAttemptNumbers(totalCounter, randomCounter);
                    randomCounter++;
                    break;
            }
            totalCounter++;
        }
        if (totalCounter != sessionAttempts.Count + 1 || typicalCounter != 6 || randomCounter != 6 || phraseCounter != 6)
        {
            Debug.LogError("This experiment is set up to have 3 passwords 5 times, so a total of 15 passwords. Something's amiss...");
        }
        attemptNumber = 0;
        PasswordsRemaining = true;
        SceneManagerWithParameters.Load("Login Screen");
        PasswordsAreMasked = passwordMasking.isOn;
    }

    /// <summary>
    /// Email the entire session at once. They are also emailed incrementally. 
    /// </summary>
    public static void EmailEntireSession() {
        // TODO: this could have a bool return for success/failure, but then it
        // can't be used as a click handler...
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return;
        }
        string subject = "Session with " + sessionAttempts[0].participantID;
        string body = GetSessionAsCsvString();
        try
        {
            EmailSender.SendEmail(subject, body);
        } catch (Exception e) 
        {
            return;
        }
    }

    /// <summary>
    /// Wrapper method for static method so it can be used as a click-handler.
    /// </summary>
    public void EmailEntireSessionClickHandler() {
        EmailEntireSession();
    }

    public static string GetSessionAsCsvString() {
        string csv = "Participant, PW Type, Expected PW, Actual PW, Type Attempt Number, Total Attempt Number, Time To Enter, Time To Review\n";
        foreach (Attempt a in sessionAttempts)
        {
            csv += a.ToString();
            csv += '\n';
        }
        return csv;
    }

}
