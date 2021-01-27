using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{

    public Dictionary<string, int> compteur = new Dictionary<string, int>();
    public GameObject ObjectsInScene;
    float t = 1.0f;

    public Camera cam;

    void resetCompteur()
    {
        foreach (Transform child in ObjectsInScene.transform)
        {
            string childid = child.gameObject.GetComponent<SimObjPhysics>().ObjectID;
            child.gameObject.SetActive(true);
            if (!compteur.ContainsKey(childid))
            {
                compteur.Add(childid, 0);
            }
            compteur[childid] = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        resetCompteur();
    }

    // Update is called once per frame
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        for (int i = 0; i < width; i = i + 100)
        {
            for (int j = 0; j < height; j = j + 100)
            {
                Ray ray = cam.ScreenPointToRay(new Vector3(i, j, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.cyan);
                }
            }
        }

        t -= Time.deltaTime;
        if (t <= 0.00f)
        {
            // Nothing touched
            resetCompteur();

            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                if (hit.collider.gameObject.transform.parent != null)
                {
                    if (hit.collider.gameObject.transform.parent.parent != null)
                    {
                        if (hit.collider.gameObject.transform.parent.parent.gameObject.GetComponent<SimObjPhysics>())
                        {
                            Debug.Log(hit.collider.gameObject.transform.parent.parent.name);
                            compteur[hit.collider.gameObject.transform.parent.parent.gameObject.GetComponent<SimObjPhysics>().ObjectID] += 1;
                        }
                    }
                }
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            }

            foreach (Transform child in ObjectsInScene.transform)
            {
                string childid = child.gameObject.GetComponent<SimObjPhysics>().ObjectID;
                if (compteur[childid] == 1)
                {
                    Debug.Log("Ici : " + childid);
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }

            // MAJ timer
            t = 0.1f;
        }
    }

    void FixedUpdate()
    {
    }
}
