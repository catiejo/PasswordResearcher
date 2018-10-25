using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://forum.unity.com/threads/unity-beginner-loadlevel-with-arguments.180925/
public static class SceneController {


    private static Dictionary<string, string> parameters;

    public static void Load(string sceneName, Dictionary<string, string> parameters = null)
    {
        SceneController.parameters = parameters;
        SceneManager.LoadScene(sceneName);
    }

    public static void Load(string sceneName, string paramKey, string paramValue)
    {
        SceneController.parameters = new Dictionary<string, string>();
        SceneController.parameters.Add(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }

    public static Dictionary<string, string> getSceneParameters()
    {
        return parameters;
    }

    public static string getParam(string paramKey)
    {
        if (parameters == null) return "";
        return parameters[paramKey];
    }

    public static void setParam(string paramKey, string paramValue)
    {
        if (parameters == null)
            SceneController.parameters = new Dictionary<string, string>();
        SceneController.parameters.Add(paramKey, paramValue);
    }

}
