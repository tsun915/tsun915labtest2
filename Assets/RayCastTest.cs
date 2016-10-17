using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RayCastTest : MonoBehaviour
{
    GameObject Location;
    public GameObject myPrefab;

    

    // Use this for initialization
    void Start()
    {
        Location = (GameObject)Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {                
                hit.collider.gameObject.GetComponentInChildren<TextMesh>().color = new Color(Random.value, Random.value, Random.value);
                Location.GetComponentInChildren<Text>().text = hit.collider.gameObject.GetComponent<Text>().text;
               
            }
        }
    }
}