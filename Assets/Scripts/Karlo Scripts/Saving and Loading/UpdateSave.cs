using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateSave : MonoBehaviour
{
    IEnumerator Save(string url) {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("id", DBManager.id);
        form.AddField("save_num", SaveManager.save_num);
        form.AddField("ecoscore", SaveManager.ecoscore);
        form.AddField("savedata", SaveManager.savedata);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form)) {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError || webRequest.isHttpError) {
                Debug.Log(webRequest.error);
            } else {
                Debug.Log("Form upload complete!");
            }
            if (webRequest.downloadHandler.text == "0") {
                //DBManager.save_num = int.Parse(webRequest.downloadHandler.text.Split('\t')[1]);
                Debug.Log("Game Saved Successfully");
            } else {
                Debug.Log("Save failed. Error #" + webRequest.downloadHandler.text);
            }
        }
    }

    public void UpdateSaveButton() {
        StartCoroutine(Save("https://ecocitythegame.ca/sqlconnect/updatesave.php"));
    }
}
