using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacter : MonoBehaviour
{
    //Hold The Curr Model in the scene
    public GameObject currModel;
    //Hold the animator of model in the scsne
    public Animator currAnim;
    //check if the player model is in the dead state animation
    private bool isDead;

    void Update()
    {
        //If there is a child of this? object, set the gameobject and find it's animator
        if(transform.childCount > 0)
        {
            currModel = transform.GetChild(0).gameObject;
        }
        if (currModel != null)
        {
            currAnim = GetComponentInChildren<Animator>();
        }
#if UNITY_ANDROID
        //check what raycast catches at which part of the objects of which have their own
        //colliders and their own seperate tags
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.tag)
                {
                    case "head":
                        Head();
                        break;
                    case "body":
                        Body();
                        break;
                    case "legs":
                        Legs();
                        break;
                    case "shield":
                        Shield();
                        break;
                    case "attack":
                        Attack();
                        break;
                    default:

                        break;
                }
            }
        }

#elif UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.tag)
                {
                    case "head":
                        Attack();
                        break;
                    default:

                        break;
                }
            }
        }
#endif

    }

    public void Attack()
    {
        if (!isDead)
        currAnim.Play("Attack");
    }

    public void Head()
    {
        if (!isDead)
        {
            currAnim.Play("Head");
            isDead = true;
        }
    }
    public void Body()
    {   
        if(!isDead)
        currAnim.Play("Body");
    }
    public void Legs()
    {
        if (isDead)
        {
            currAnim.Play("Legs");
            isDead = false;
        }
    }
    public void Shield()
    {
        if(!isDead)
        currAnim.Play("Shield");
    }
}
