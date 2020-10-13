using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastingTest : MonoBehaviour
{
    public GameObject defaultDot;
    public GameObject interactDot;
    public GameObject promptTextObject;
    public Text promptText;

    public Material red;
    public Material green;
    public int colorNumber = 0;     // 0 = red 1 = green

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
        {
            defaultDot.SetActive(false);    // Turns off Default Dot
            interactDot.SetActive(true);    // Turns on Interact Dot
            promptTextObject.SetActive(true);   // Turns on the prompt text object

            if (hit.transform.name == "Thing 1")
            {
                promptText.text = "Make Bigger";

                if (Input.GetMouseButton(0))
                {
                    hit.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);      // Increases by 0.1 units per frame
                }
            }

            if (hit.transform.name == "Thing 2")
            {
                promptText.text = "Change Color";

                if (Input.GetMouseButtonDown(0))
                {
                    if (colorNumber == 0)
                    {
                        // Change to green
                        hit.transform.gameObject.GetComponent<Renderer>().material = green;
                        colorNumber = 1;
                    }

                    else
                    {
                        // Change to red
                        hit.transform.gameObject.GetComponent<Renderer>().material = red;
                        colorNumber = 0;
                    }
                }
            }
        }
        else
        {
            defaultDot.SetActive(true);    // Turns on Default Dot
            interactDot.SetActive(false);    // Turns off Interact Dot
            promptTextObject.SetActive(false);   // Turns off the prompt text object
        }
    }
}
