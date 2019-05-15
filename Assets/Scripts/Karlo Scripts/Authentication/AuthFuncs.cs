using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public static class AuthFuncs{

    public static string EncryptPassword(string Password) {
        var crypt = new SHA256Managed();
        var hash = new StringBuilder();
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(Password));
        foreach (byte theByte in crypto) {
            hash.Append(theByte.ToString("x2"));
        }
        return hash.ToString();
    }

    public static string DecryptPassword(string Encrypted) {
        string DecryptedPass = "";
        for (int i = 1; i <= Encrypted.Length; i++) {
            DecryptedPass += ((char)(Encrypted[i - 1] / (i + 1))).ToString();
        }
        return DecryptedPass;
    }

    public static bool CheckUsername(string Username) {
        return Username != "";
    }

    public static bool CheckPassword(string Password) {
        return Password != "";
    }

    public static bool CheckSignupPassword(string Password, string ConfirmPassword) {
        if (Password.Equals(ConfirmPassword)) {
            if (LengthConstraint(Password, 8, 20)) {
                Debug.LogWarning("Valid Password");
                return true;
            } else {
                Debug.LogWarning("Invalid Password");
                return false;
            }
        } else {
            Debug.LogWarning("Passwords don't match");
            return false;
        }
    }

    public static bool CheckSignupUser(string Username, string ConfirmPassword) {
        if (LengthConstraint(Username, 3, 16)) {
            Debug.LogWarning("Valid Password");
            return true;
        } else {
            Debug.LogWarning("Invalid Password");
            return false;
        }

    }

    private static bool LengthConstraint(string Input, int LowerBound, int UpperBound) {
        return Input.Length <= UpperBound && Input.Length >= LowerBound;
    }
}
