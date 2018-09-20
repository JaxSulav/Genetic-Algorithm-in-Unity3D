using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]

public class Brain : MonoBehaviour {

    public int DNALength = 1;
    public float timeAlive;
    public float distanceTravelled;
    Vector3 startPosition;
    public DNA1 dna;

    private ThirdPersonCharacter m_Char;
    private Vector3 m_Move;
    private bool m_Jump;
    bool alive = true;

    private void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    public void Init()
    {
        /* initialize DNA1, 0 for forward 1 for back, 2 for left, 3 for right, 4 for jump, 5 for crouch */
        dna = new DNA1(DNALength, 6);
        m_Char = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        alive = true;
        startPosition = this.transform.position;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float h = 0;
        float v = 0;
        bool crouch = false;
        if (dna.GetGene(0) == 0) v = 1;
        else if (dna.GetGene(0) == 1) v = -1;
        else if (dna.GetGene(0) == 2) h = -1;
        else if (dna.GetGene(0) == 3) h = 1;
        else if (dna.GetGene(0) == 4) m_Jump = true;
        else if (dna.GetGene(0) == 4) crouch = true;

        m_Move = v * Vector3.forward + h * Vector3.right;
        m_Char.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
        if (alive)
        {
            timeAlive += Time.deltaTime;
            distanceTravelled = Vector3.Distance(this.transform.position, startPosition);
        }

    }
}
