using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Energy : MonoBehaviour
{
    public float speed;

    public Transform target;

    public float chaseRadius;

    public static int energy = 0;

    public TextMeshProUGUI energyText;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Principal Root")
        {
            energy = +1;

            energyText.text = "Energy: " + energy.ToString();

            DestroyImmediate(this.gameObject);

        }
    }
}
