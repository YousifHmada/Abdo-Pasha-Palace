using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelect : MonoBehaviour {
    static  public GameObject currentSelection;
    GameObject oldSelection;
    static public float maxDistance = 2f, maxAngle = 70f, thick = 1.5f;
    static public Vector3 castcenter = new Vector3 (0f,0.75f,-1f);
    bool nocollision = true;
    private void Start()
    {
        currentSelection = null;
        oldSelection = null;
    }
    private void Update()
    {
        if(oldSelection != currentSelection)
        {
            if(oldSelection != null)
            {

                oldSelection.GetComponent<Outline>().OutlineWidth = 0f;
            }
            oldSelection = currentSelection;
        }
        
        if (nocollision)
        {
            getGameObject();
        }
        if(Input.GetButtonDown("Submit")){
            objectIntearct.DialogOpen(currentSelection.GetComponent<objectIntearct>().DialogData);
        }
    }
    public void getGameObject()
    {
        currentSelection = null;
        NearObject();
    }
    void NearObject()
    {
        RaycastHit info;
        Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z)+castcenter;
        Vector3 direction = transform.forward;
        bool hit = Physics.CapsuleCast(origin+castcenter,origin-castcenter, thick, direction, out info, maxDistance);
        if (hit)
        {
            Transform target = info.transform;
            Vector3 targetdir = target.position - transform.position;
            float angle = Vector3.Angle(targetdir, transform.forward);
            float distance = Vector3.Distance(target.position, transform.position);
            if (angle <= maxAngle && distance <= maxDistance && hit)
            {
                currentSelection = target.gameObject;
                currentSelection.GetComponent<Outline>().OutlineWidth = 10f;
            }
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        nocollision = false;
        if (other.gameObject.tag == "Interactable")
        {
            currentSelection = other.gameObject;
            currentSelection.GetComponent<Outline>().OutlineWidth = 10f;
        }
        else
        {
            getGameObject();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            currentSelection = other.gameObject;
            currentSelection.GetComponent<Outline>().OutlineWidth = 10f;
        }
        else
        {
            getGameObject();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        nocollision = true;
        getGameObject();

    }
    
}
