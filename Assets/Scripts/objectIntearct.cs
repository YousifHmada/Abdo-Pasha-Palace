using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectIntearct : MonoBehaviour {
    public Transform player;
    public TextAsset DialogData;
    static GameObject Dialog;
    private void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    private void OnMouseDown()
    {
        if (PlayerClose() && ObjectSelect.currentSelection !=null)
        {
            DialogOpen(DialogData);
        }
    }
    private void OnMouseOver()
    {

        if (ObjectSelect.currentSelection != null)
        {

            ObjectSelect.currentSelection.GetComponent<Outline>().OutlineWidth = 0f;
        }
        ObjectSelect.currentSelection = gameObject;
        ObjectSelect.currentSelection.GetComponent<Outline>().OutlineWidth = 10f;
    }
    bool PlayerClose()
    {
        bool close = true;
        RaycastHit info;
        Vector3 origin = new Vector3(player.position.x, player.position.y, player.position.z) + ObjectSelect.castcenter;
        Vector3 direction = transform.forward;
        bool hit = Physics.CapsuleCast(origin + ObjectSelect.castcenter, origin - ObjectSelect.castcenter, ObjectSelect.thick, direction, out info, ObjectSelect.maxDistance);
        if (hit)
        {
            Transform target = info.transform;
            Vector3 targetdir = target.position - transform.position;
            float angle = Vector3.Angle(targetdir, transform.forward);
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance > ObjectSelect.maxDistance)
            {
                close = false;
            }
        }


        return close;
    }
    static public void DialogOpen(TextAsset temp)
    {
        Dialog.SetActive(true);
        DialogManager.questionesFile = temp;
    }
}
