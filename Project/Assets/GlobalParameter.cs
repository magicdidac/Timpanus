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
       // FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, transform, GetComponent<Rigidbody>());
    }

    public static void AddAchievement()
    {
        instance.getParameterByName("Achievement", out last);

        Debug.Log(instance.setParameterByName("Achievement", last+.3f));instance.setParameterByName("Achievement", last+.3f);
        Debug.Log(last);
    }
}
