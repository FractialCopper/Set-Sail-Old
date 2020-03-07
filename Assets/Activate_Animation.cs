using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Activate_Animation : MonoBehaviour
{
    Animator animator;
    public float time;
    public PlayerBehav player;
    //Transform camera;
    //GameObject text;
    public void Start() {
        // animator  = gameObject.GetComponent<Animator>();
        //TriggerAnimation();
        player = GameObject.Find("Player").GetComponent<PlayerBehav>();
        //camera = GameObject.Find("Main Camera").transform;
        //text = transform.GetChild(0).gameObject;
        transform.SetParent(player.transform);
        //Vector3 relativePosition = camera.transform.InverseTransformDirection(player.transform.position - camera.transform.position);
        //text.transform.position += relativePosition;
        Destroy(gameObject, time);
    }

    public void TriggerAnimation() {
        StartCoroutine(PlayAnimation());
     }

    IEnumerator PlayAnimation() {
        animator.enabled = true;
        yield return new WaitForSeconds(time);
        animator.enabled = false;

    }
}
