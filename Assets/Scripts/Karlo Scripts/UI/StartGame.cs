using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Awake()
    {
        DBManager.inGame = false;
        DBManager.username = null;
        DBManager.id = -1;
        DBManager.score = -1;
        DBManager.isGuest = false;
        DBManager.save_num = -1;
        DBManager.game_mode = null;
        DBManager.level = null;
    }

}
