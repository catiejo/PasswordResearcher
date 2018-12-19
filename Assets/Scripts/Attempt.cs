using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attempt {
    //TODO: these should be get, private set.
    public Password password;
    public string enteredPassword;
    public float timeStartedTyping;
    public float timeStoppedTyping;
    public float timePressedDone;
    public int totalAttemptNumber;
    public int typeAttemptNumber;
    public string participantID;
    public string maskedStatus;
    public int numberOfBackspaces;
    public string deviceType;

    public Attempt(Password pw, string id, string masked) {
        this.password = pw;
        this.participantID = id;
        this.enteredPassword = "";
        this.timeStartedTyping = -1.0f;
        this.timeStoppedTyping = -1.0f;
        this.timePressedDone = -1.0f;
        this.deviceType = Application.platform.ToString();
        this.maskedStatus = masked;
    }

    public void SetAttemptNumbers(int total, int type) {
        this.typeAttemptNumber = type;
        this.totalAttemptNumber = total;
    }

    public void FinishAttempt(int numBackspaces, float timeStart, float timeStop, float timeDone, string pw) {
        this.timeStartedTyping = timeStart;
        this.timeStoppedTyping = timeStop;
        this.timePressedDone = timeDone;
        this.enteredPassword = pw;
        this.numberOfBackspaces = numBackspaces;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Attempt"/> in CSV format.
    /// </summary>
    /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Attempt"/> in CSV format.</returns>
    public override string ToString()
    {
        string s = "";
        s += participantID + ",";
        s += maskedStatus + ",";
        s += deviceType + ",";
        s += numberOfBackspaces + ",";
        s += password.type.ToString() + ",";
        s += password.expected + ",";
        s += enteredPassword + ",";
        s += typeAttemptNumber + ",";
        s += totalAttemptNumber + ",";
        s += timeStartedTyping + ",";
        s += timeStoppedTyping + ",";
        s += timePressedDone;
        return s;
    }
}
