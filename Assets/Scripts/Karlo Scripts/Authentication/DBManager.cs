using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager {

    public static string username;
    public static int id;
    public static bool isGuest;
    public static bool inGame;
    public static bool newGame;
    public static int save_num;
    public static string game_mode;
    public static string level;

    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut() {
        username = null;
        id = -1;
        isGuest = false;
        newGame = false;
        inGame = false;
        save_num = -1;
        game_mode = null;
        level = null;

    }
}
    
