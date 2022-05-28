using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacter : MonoBehaviour
{
    public GameObject currModel;
    public Animator currAnim;
    private bool isDead;

    void Update()
    {
        if(transform.childCount > 0)
        {
            currModel = transform.GetChild(0).gameObject;
        }
        if (currModel != null)
        {
            currAnim = GetComponentInChildren<Animator>();
        }
#if UNITY_ANDROID
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
