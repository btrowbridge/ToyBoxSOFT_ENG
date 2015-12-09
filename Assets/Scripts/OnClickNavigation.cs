using UnityEngine;
using System.Collections;

public class OnClickNavigation : MonoBehaviour {




    public void LoadLevel(int index) {
        Application.LoadLevel(index);
    }
    public void Quit() {
        Application.Quit();
    }
    public void resetScores() {
        PlayerPrefs.DeleteAll();
    }

}
