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

    public Password(Sprite s, string ex, PassType t) {
        this.expected = ex;
        this.pwSprite = s;
        this.type = t;
    }
}

public class PasswordController : MonoBehaviour {
    public Sprite[] typicalPasswordSprites;
    public Sprite[] randomPasswordSprites;
    public Sprite[] passPhraseSprites;

    public Password GetRandomPassword(PassType type) {
        Sprite s = typicalPasswordSprites[0]; //Placeholder value
        switch (type) {
            case PassType.Typical:
                s = typicalPasswordSprites[Random.Range(0, typicalPasswordSprites.Length)];
                break;
            case PassType.Phrase:
                s = passPhraseSprites[Random.Range(0, passPhraseSprites.Length)];
                break;
            case PassType.Random:
                s = randomPasswordSprites[Random.Range(0, randomPasswordSprites.Length)];
                break;
        }
        return new Password(s, s.name, type);
    }

}
