using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour {

    //genes which generates colour
    public float r;
    public float b;
    public float g;
    public float s;

    bool dead = false; // to kill the player
    public float timeToDie = 0;
    SpriteRenderer sRend;
    Collider2D sColl;

    private void OnMouseDown() //destroying on click
    {
        dead = true;
        timeToDie = PopulationManager.elapsed;
        Debug.Log("Dead At:" + timeToDie);
        sRend.enabled = false;
        sColl.enabled = false;
    }


    // Use this for initialization
    void Start () {

        sRend = GetComponent<SpriteRenderer>();
        sColl = GetComponent<Collider2D>();
        sRend.color = new Color(r, g, b);    // for rendering the colour containing rgb values
        this.transform.localScale = new Vector3(s,s,s);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static implicit operator DNA(DNA1 v)
    {
        throw new NotImplementedException();
    }

    internal int GetGene(int v)
    {
        throw new NotImplementedException();
    }

    internal void Mutate()
    {
        throw new NotImplementedException();
    }

    internal void Combine(DNA dna1, DNA dna2)
    {
        throw new NotImplementedException();
    }
}
