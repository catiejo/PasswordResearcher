using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminAreaCancel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManagerWithParameters.GetParam("PreviousScreen") == "") {
            this.gameObject.SetActive(false);
        }
		
	}
    public void GoBackToPreviousScreen() {
        SceneManagerWithParameters.Load(SceneManagerWithParameters.GetParam("PreviousScreen"));
    }	
}
