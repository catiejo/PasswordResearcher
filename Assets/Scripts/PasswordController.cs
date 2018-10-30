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

    /// <summary>
    /// Gets a given number of distinct, random passwords.
    /// </summary>
    /// <returns>A list passwords.</returns>
    /// <param name="type">parameter type (typical, random, phrase).</param>
    /// <param name="numPasswords">Number of passwords to get.</param>
    public List<Password> GetRandomPasswords(PassType type, int numPasswords) {
        List<Password> passwords = new List<Password>();
        HashSet<int> indices = new HashSet<int>();

        // Make sure you haven't requested too many passwords!
        bool requestedTooManyPw = false;
        switch (type)
        {
            case PassType.Typical:
                requestedTooManyPw = numPasswords > typicalPasswordSprites.Length;
                break;
            case PassType.Random:
                requestedTooManyPw = numPasswords > randomPasswordSprites.Length;
                break;
            case PassType.Phrase:
                requestedTooManyPw = numPasswords > passPhraseSprites.Length;
                break;
        }
        if (requestedTooManyPw) {
            Debug.LogError("Too many passwords requested! There are not " + numPasswords + " entries in " + type.ToString() + " Passwords!");
            return passwords;
        }

        // Get random, non-identical indices.
        while (indices.Count < numPasswords) {
            switch (type)
            {
                case PassType.Typical:
                    indices.Add(Random.Range(0, typicalPasswordSprites.Length));
                    break;
                case PassType.Phrase:
                    indices.Add(Random.Range(0, passPhraseSprites.Length));
                    break;
                case PassType.Random:
                    indices.Add(Random.Range(0, randomPasswordSprites.Length));
                    break;
            }
        }
        // Populate list
        Sprite s = typicalPasswordSprites[0]; //Placeholder value
        foreach (int index in indices) {
            switch (type)
            {
                case PassType.Typical:
                    s = typicalPasswordSprites[index];
                    break;
                case PassType.Phrase:
                    s = passPhraseSprites[index];
                    break;
                case PassType.Random:
                    s = randomPasswordSprites[index];
                    break;
            }
            passwords.Add(new Password(s, s.name, type));
        }
        return passwords;
    }

}
