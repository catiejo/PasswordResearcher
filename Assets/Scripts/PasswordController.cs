using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PassType
{
    Typical, Phrase, Random
};

[System.Serializable]
public struct Password
{
    public string expected;
    public Sprite pwSprite;
    public PassType type;
}

public class PasswordController : MonoBehaviour {
    public Password[] typicalPasswords;
    public Password[] randomPasswords;
    public Password[] passPhrases;

    public Password GetRandomPassword(PassType type) {
        Password p = new Password();
        switch (type) {
            case PassType.Typical:
                p = typicalPasswords[Random.Range(0, typicalPasswords.Length)];
                break;
            case PassType.Phrase:
                p = passPhrases[Random.Range(0, passPhrases.Length)];
                break;
            case PassType.Random:
                p = randomPasswords[Random.Range(0, randomPasswords.Length)];
                break;
        }
        return p;
    }

}
