using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRace : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter3D(Collider other)
    {
        if (other.tag =="Player")
        {
            SceneManager.LoadScene("race2");
        }

    }

   
}
