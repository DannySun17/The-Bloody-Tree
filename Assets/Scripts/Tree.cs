using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [Header("RayCast")]
    [SerializeField] private LayerMask posiblesLayers;
    [SerializeField] private Transform objectActack;

    [Header("Roots")]
    [SerializeField] private GameObject principalRoot;
    [SerializeField] private GameObject prefabRoot;
    [SerializeField] private List<GameObject> rootsList;


    [Header("Attributes")]
    [SerializeField] private float velocidadCrecimiento; 
    [SerializeField] private float heightToActtack;
    [SerializeField] private float timeToRoot;


    private bool attacking;
    private float rootTime;


    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        rootTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 screenPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (Input.GetMouseButtonDown(0))
        {
            principalRoot.transform.position = Vector3.zero;
            rootTime = 0;
            ClearRoots();
        }
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hitData, 500f, posiblesLayers))
            {
                objectActack.position = new Vector3(hitData.point.x, objectActack.position.y, hitData.point.z);
            }
            attacking = true;
                
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Ataqueeeee");
            attacking = false;
            principalRoot.transform.Translate(Vector3.zero, Space.Self);
            Vector3 dirtoAttack = new Vector3(principalRoot.transform.position.x, principalRoot.transform.position.y + heightToActtack, principalRoot.transform.position.z);
            principalRoot.transform.position = dirtoAttack;
        }

        if (attacking)
        {
            Vector3 dirToMove = new Vector3(objectActack.position.x, principalRoot.transform.position.y, objectActack.position.z);
            principalRoot.transform.Translate(dirToMove * Time.deltaTime * velocidadCrecimiento, Space.Self);
            if(rootTime > timeToRoot)
            {
                GameObject root = Instantiate(prefabRoot, principalRoot.transform.position, principalRoot.transform.rotation);
                root.transform.LookAt(prefabRoot.transform);
                rootsList.Add(root);
                rootTime = 0;
            }
            rootTime += (timeToRoot/velocidadCrecimiento) * Time.deltaTime;

        }


        
    }

    public void ClearRoots()
    {
        foreach(GameObject root in rootsList)
        {
            Destroy(root);
        }
        rootsList.Clear();
    }
}
