using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using
using UnityEngine.UI;

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
    // Put your URL here
    private string _WebsiteURL = "http://infosys320tsun915.azurewebsites.net/tables/TreeSurvey?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        TreeSurvey[] readings = JsonReader.Deserialize<TreeSurvey[]>(jsonResponse);

        int totalCubes = readings.Length;
        int totalDistance = 5;
        int i = 0;
        //We can now loop through the array of objects and access each object individually
        foreach (TreeSurvey reading in readings)
        {
            //Example of how to use the object
            Debug.Log("This reading  : " + reading.TreeID);
            float perc = i / (float)totalCubes;
            i++;
            float x = float.Parse(reading.X);
            float y = float.Parse(reading.Y);
            float z = float.Parse(reading.Z);
            GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<myCubeScript>().setSize(0.18f);
            //newCube.GetComponent<myCubeScript>().ratateSpeed = perc;
            newCube.GetComponentInChildren<TextMesh>().text = x +", " + y + ", "+ z;
            newCube.AddComponent<Text>().text = reading.Location;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
