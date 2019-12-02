using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField] private float speed = 3;

    [HideInInspector] private Animator anim;
    [HideInInspector] private Vector3 initialPoint;

    private void Start()
    {
        anim = GetComponent<Animator>();
        initialPoint = transform.position;

        GameController.instance.audioManager.PlayAtPosition("Car", transform);
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.forward.normalized * speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, initialPoint) > 300)
            transform.position = initialPoint;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>())
            anim.SetBool("isVisible", true);
        else
            anim.SetBool("isVisible", false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
            anim.SetBool("isVisible", false);
    }

}
