using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public static class AuthFuncs{

    /// <summary>
    /// Encrypts the password with SHA256 before sending pw to database 
    /// </summary>
    /// <param name="Password">The password to encrypt</param>
    /// <returns>The encrypted password</returns>
    public static string EncryptPassword(string Password) {
        var crypt = new SHA256Managed();
        var hash = new StringBuilder();
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(Password));
        foreach (byte theByte in crypto) {
            hash.Append(theByte.ToString("x2"));
        }
        return hash.ToString();
    }

    /// <summary>
    /// Checks that the username is not empty
    /// </summary>
    /// <param name="Username"></param>
    /// <returns></returns>
    public static bool CheckUsername(string Username) {
        return Username != "";
    }

    /// <summary>
    /// Checks that the password is not empty
    /// </summary>
    /// <param name="Password"></param>
    /// <returns></returns>
    public static bool CheckPassword(string Password) {
        return Password != "";
    }

    /// <summary>
    /// Checks that the "Password" and "Confirm Password" are the same
    /// </summary>
    /// <param name="Password"></param>
    /// <param name="ConfirmPassword"></param>
    /// <returns></returns>
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

    /// <summary>
    /// The length of the username should be between 3 and 16 characters
    /// </summary>
    /// <param name="Username"></param>
    /// <param name="ConfirmPassword"></param>
    /// <returns></returns>
    public static bool CheckSignupUser(string Username, string ConfirmPassword) {
        if (LengthConstraint(Username, 3, 16)) {
            Debug.LogWarning("Valid Password");
            return true;
        } else {
            Debug.LogWarning("Invalid Password");
            return false;
        }

    }

    /// <summary>
    /// Checks the length of a string and retruns true if it is between the inputed lower and upper bounds
    /// </summary>
    /// <param name="Input"></param>
    /// <param name="LowerBound"></param>
    /// <param name="UpperBound"></param>
    /// <returns></returns>
    private static bool LengthConstraint(string Input, int LowerBound, int UpperBound) {
        return Input.Length <= UpperBound && Input.Length >= LowerBound;
    }
}
