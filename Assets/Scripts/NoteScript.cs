using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public GameObject noteSlicedPrefab;

    public float startForce = 15f;

    private Rigidbody2D _rb;

    public bool _isWrong = false;
    public int noteNumber = 1;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("blade"))
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);
            
            GameObject slicedNote = Instantiate(noteSlicedPrefab, transform.position, transform.rotation);
            slicedNote.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(transform.up * 100f);

            if (!_isWrong)
            {
                ScoreDisplay.AddScore(100);
            }
            else
            {
                LifesScript.RemoveLife();
            }
            SoundManagerScript.PlaySound(noteNumber);
            Destroy(gameObject);
            Destroy(slicedNote, 2f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
