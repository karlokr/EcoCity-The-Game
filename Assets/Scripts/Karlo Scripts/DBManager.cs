using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager {

    public static string username;
    public static int id;
    public static int score;
    public static bool isGuest;
    public static int save_num;

    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut() {
        username = null;
    }
}
    
