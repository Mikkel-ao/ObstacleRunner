using System;
using UnityEngine;

public class ObFourMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody obFourRigidbody;
    [SerializeField] private float speedObFour = 5f;
    [SerializeField] private float amplitude = 2f;
    
    private Vector3 startPosition;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = obFourRigidbody.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float offset = Mathf.PingPong(Time.time * speedObFour, amplitude *2f) - amplitude;
        obFourRigidbody.MovePosition(startPosition + Vector3.right * offset);        
    }
}
