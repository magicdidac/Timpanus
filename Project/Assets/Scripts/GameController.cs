using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public static GameController instance;

    private PlayerController player;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }


    public PlayerController GetPlayer()
    {
        if (player == null)
            player = GameObject.FindObjectOfType<PlayerController>();

        return player;
    }

}
