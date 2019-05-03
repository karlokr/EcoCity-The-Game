using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AuthFuncs{

    public static string EncryptPassword(string Password) {
        string EncryptedPass = "";
        for (int i = 1; i <= Password.Length; i++) {
            EncryptedPass += ((char)(Password[i - 1] * (i + 1))).ToString();
        }
        return EncryptedPass;
    }

    public static string DecryptPassword(string Encrypted) {
        string DecryptedPass = "";
        for (int i = 1; i <= Encrypted.Length; i++) {
            DecryptedPass += ((char)(Encrypted[i - 1] / (i + 1))).ToString();
        }
        return DecryptedPass;
    }

    public static bool CheckUsername(string Username) {
        if (Username != "") {
            return true;
        } else {
            Debug.LogWarning("Username field empty");
            return false;
        }
    }

    public static bool CheckPassword(string Password) {
        if (Password != "") {
            return true;
        } else {
            Debug.LogWarning("Username field empty");
            return false;
        }
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
