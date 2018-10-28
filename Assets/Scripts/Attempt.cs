using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attempt {
    public Password password;
    public string enteredPassword;
    public float timeElapsed;
    public float timeToReview;
    public int totalAttemptNumber;
    public int typeAttemptNumber;
    public string participantID;

    public Attempt(Password pw, string id) {
        this.password = pw;
        this.participantID = id;
        this.enteredPassword = "";
        this.timeElapsed = -1.0f;
        this.timeToReview = -1.0f;
    }

    public void SetAttemptNumbers(int total, int type) {
        this.typeAttemptNumber = type;
        this.totalAttemptNumber = total;
    }

    public void FinishAttempt(float timeToType, float timeToReview, string pw) {
        this.timeElapsed = timeToType;
        this.timeToReview = timeToReview;
        this.enteredPassword = pw;
    }

    public override string ToString()
    {
        string s = "";
        s += participantID + ", ";
        s += password.type.ToString() + ", ";
        s += password.expected + ", ";
        s += enteredPassword + ", ";
        s += typeAttemptNumber + ", ";
        s += totalAttemptNumber + ", ";
        s += timeElapsed + ", ";
        s += timeToReview + ", ";
        return s;
    }
}
