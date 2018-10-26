using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://forum.unity.com/threads/unity-beginner-loadlevel-with-arguments.180925/
public static class SceneController {


    private static Dictionary<string, string> parameters;

    public static string GetActiveSceneName() {
        return SceneManager.GetActiveScene().name;
    }

    public static void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void Load(string sceneName, string paramKey, string paramValue)
    {
        setParam(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }

    public static Dictionary<string, string> getSceneParameters()
    {
        return parameters;
    }

    public static string getParam(string paramKey)
    {
        if (parameters == null || !parameters.ContainsKey(paramKey)) {
            return "";
        } 
        return parameters[paramKey];
    }

    public static void setParam(string paramKey, string paramValue)
    {
        if (parameters == null) {
            SceneController.parameters = new Dictionary<string, string>();
        }
        if (parameters.ContainsKey(paramKey)) {
            parameters.Remove(paramKey);
        }
        SceneController.parameters.Add(paramKey, paramValue);
    }

}
