using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attempt {
    public Password password;
    public string enteredPassword;
    public float timeElapsed;
    public int totalAttemptNumber;
    public int typeAttemptNumber;
    public string participantID;

    public Attempt(Password pw, string id) {
        this.password = pw;
        this.participantID = id;
        this.enteredPassword = "";
        this.timeElapsed = 0.0f;
    }

    public void SetAttemptNumbers(int total, int type) {
        this.typeAttemptNumber = type;
        this.totalAttemptNumber = total;
    }

    public void FinishAttempt(float time, string pw) {
        this.timeElapsed = time;
        this.enteredPassword = pw;
    }

    public override string ToString()
    {
        string s = password.type.ToString() + " Attempt " + typeAttemptNumber + " of 5, " + totalAttemptNumber + " of 15. ";
        s += "Expected: '" + password.expected + "', Actual: '" + enteredPassword + "'\n";
        s += "ID: " + participantID + ". Time to Enter: " + timeElapsed;
        return s;
    }
}
