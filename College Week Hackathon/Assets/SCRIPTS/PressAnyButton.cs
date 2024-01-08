using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButton : MonoBehaviour
{
    private Animator Title;
    public Animator MenuAnimation;
    public GameObject ObjectToDisable;
    // Start is called before the first frame update
    void Start()
    {
        Title = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            Title.SetTrigger("Activate");
            ObjectToDisable.SetActive(false);
            StartCoroutine(ActivateMenuAnimation());
        }
    }

    IEnumerator ActivateMenuAnimation() {
        yield return new WaitForSeconds(0.5f);
        MenuAnimation.SetTrigger("Activate");
    }
}
