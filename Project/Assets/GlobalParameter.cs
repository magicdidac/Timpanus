using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParameter : MonoBehaviour
{
    private static FMOD.Studio.EventInstance instance;
    [FMODUnity.EventRef] public string fmodEvent;
    

    private static float last;
    // Start is called before the first frame update
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
        
    }

    public static void AddAchievement()
    {
        instance.getParameterByName("Achievement", out last);

        instance.setParameterByName("Achievement", last+.2f);
        Debug.Log(last);
    }
}
