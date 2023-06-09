using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Animator;

    public Animation DeathAnimation;

    public IEnumerator PlayDeathAnimimation()
    {
        //deathSound.Play();//plays the death sound
        Animator.Play("CapsuleDead");
        yield return new WaitForSeconds(3);//Use the length of the animation clip as the wait time for yield
        //rigidbody2D.isKinematic = true;//freeze the rigidbody2D of the player
        //Application.LoadLevel(Application.loadedLevel);//reload the current level
        Debug.Log("Death animtion played");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
