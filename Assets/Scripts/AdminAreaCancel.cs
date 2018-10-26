using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminAreaCancel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneController.getParam("PreviousScreen") == "") {
            this.gameObject.SetActive(false);
        }
		
	}
    public void GoBackToPreviousScreen() {
        SceneController.Load(SceneController.getParam("PreviousScreen"));
    }	
}
