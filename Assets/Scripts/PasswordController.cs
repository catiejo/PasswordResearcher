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

    private List<Password> typicalPasswords;
    private List<Password> randomPasswords;
    private List<Password> passPhrases;

    // Doing this on Awake instead of Start to avoid potential synchronicity problems
    private void Awake()
    {
        typicalPasswords = new List<Password>();
        foreach (Sprite typ in typicalPasswordSprites)
        {
            typicalPasswords.Add(new Password(typ, typ.name, PassType.Typical));
        }

        randomPasswords = new List<Password>();
        foreach (Sprite r in randomPasswordSprites)
        {
            randomPasswords.Add(new Password(r, r.name, PassType.Random));
        }

        passPhrases = new List<Password>();
        foreach (Sprite pp in typicalPasswordSprites)
        {
            passPhrases.Add(new Password(pp, pp.name, PassType.Phrase));
        }
    }

    public Password GetRandomPassword(PassType type) {
        Password p = new Password();
        switch (type) {
            case PassType.Typical:
                p = typicalPasswords[Random.Range(0, typicalPasswords.Count)];
                break;
            case PassType.Phrase:
                p = passPhrases[Random.Range(0, passPhrases.Count)];
                break;
            case PassType.Random:
                p = randomPasswords[Random.Range(0, randomPasswords.Count)];
                break;
        }
        return p;
    }

}
