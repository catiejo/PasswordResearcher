using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionManager : MonoBehaviour {
    public PasswordController passController;
    public Toggle passwordMasking;

    public static Attempt CurrentAttempt { get; private set; }
    public static bool passwordsRemaining;
    public static bool passwordIsMasked;


    private static List<Attempt> sessionAttempts;
    private static int attemptNumber;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Finishes the attempt.
    /// </summary>
    /// <param name="timeElapsed">Time taken to enter the password.</param>
    /// <param name="enteredPassword">Entered password.</param>
    public static void FinishAttempt(float timeElapsed, string enteredPassword) {
        sessionAttempts[attemptNumber - 1].FinishAttempt(timeElapsed, enteredPassword);
        Debug.Log(sessionAttempts[attemptNumber - 1].ToString());
    }

    /// <summary>
    /// Sets CurrentAttempt to the next one in line.
    /// </summary>
    public static void StartNextAttempt() {
        attemptNumber++;
        passwordsRemaining = attemptNumber < sessionAttempts.Count;
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
            int rando = Random.Range(i, sessionAttempts.Count);
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
            Debug.Log(a.ToString());
        }
        if (totalCounter != sessionAttempts.Count + 1 || typicalCounter != 6 || randomCounter != 6 || phraseCounter != 6) {
            Debug.LogError("Holy schnitzel, porky pants! There aren't enough of each password type!");
        }
        attemptNumber = 0;
        passwordsRemaining = true;
        SceneController.Load("Login Screen");
        passwordIsMasked = passwordMasking.isOn;
    }

}
