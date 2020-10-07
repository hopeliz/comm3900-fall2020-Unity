using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUp : MonoBehaviour
{
    public Transform[] cubes;

    public float speed = 5;
    public float triggerHeight = 1;
    public float disappearHeight = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (i == 0) {
                cubes[i].position += Vector3.up * speed * Time.deltaTime;
            }

            if (i > 0)
            {
                if (cubes[i - 1].position.y >= triggerHeight)
                {
                    cubes[i].position += Vector3.up * speed * Time.deltaTime;
                }
            }
        }

        foreach (Transform cube in cubes)
        {
            if (cube.position.y >= disappearHeight)
            {
                cube.gameObject.SetActive(false);
            }
        }
    }
}
