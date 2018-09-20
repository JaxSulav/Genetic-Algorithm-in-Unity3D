using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopManager : MonoBehaviour {

    public GameObject prefab;
    public int populationSize = 50;
    List<GameObject> population = new List<GameObject>();
    public static float elapsed = 0;
    public float trialTime = 5;
    int generation = 1;

    GUIStyle guiStyle = new GUIStyle();
    private void OnGUI()
    {
        guiStyle.fontSize = 25;
        guiStyle.normal.textColor = Color.cyan;
        GUI.BeginGroup(new Rect(10, 10, 250, 150));
        GUI.Box(new Rect(0, 0, 140, 140), "Stats", guiStyle );
        GUI.Label(new Rect(10, 25, 200, 30), "Gen: " + generation, guiStyle);
        GUI.Label(new Rect(10, 50, 200, 30), string.Format("Time: {0:0.00}", elapsed), guiStyle);
        GUI.Label(new Rect(10, 75, 200, 30), "Population: " + population.Count, guiStyle);
        GUI.EndGroup();
    }

    // Use this for initialization
    void Start () {
        for(int i = 0; i <populationSize; i++)
        {
            Vector3 startingPos = new Vector3(this.transform.position.x + Random.Range(-2, 2), 
                this.transform.position.y, this.transform.position.z + Random.Range(-2, 2));
            GameObject bot = Instantiate(prefab, startingPos, this.transform.rotation);
            bot.GetComponent<Brain>().Init();
            population.Add(bot);
        }
		
	}

    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 startingPos = new Vector3(this.transform.position.x + Random.Range(-2, 2),
                this.transform.position.y, this.transform.position.z + Random.Range(-2, 2));
        GameObject offSpring = Instantiate(prefab, startingPos, this.transform.rotation);
        Brain bot = offSpring.GetComponent<Brain>();
        if (Random.Range(0, 100) == 1)// mutation 1 out of 100
        {
            bot.Init();
            bot.dna.Mutate();
        }
        else
        {
            bot.Init();
            bot.dna.Combine(parent1.GetComponent<Brain>().dna, parent2.GetComponent<Brain>().dna);
        }
        return offSpring;
   }

    void breedNewPopulation()
    {
        List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<Brain>().distanceTravelled).ToList();
        population.Clear();
        for(int i = (int)(sortedList.Count/2.0f) - 1; i < sortedList.Count - 1; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i+1]));
            population.Add(Breed(sortedList[i+1], sortedList[i]));     
        }

        for (int i = 0; i< sortedList.Count; i++)
        {
            Destroy(sortedList[i]);
        }
        generation++;
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= trialTime)
        {
            breedNewPopulation();
            elapsed = 0;
        }
    }
}
