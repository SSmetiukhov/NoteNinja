using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{
    public float minCuttingVelocity = .001f;
    
    private bool _isCutting = false;

    private Rigidbody2D rb;
    private CircleCollider2D _collider;

    private Vector2 _prevPos;

    public GameObject bladeTrailPrefab;
    private GameObject _currentBladeTrail;

    private Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        _collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        } else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (_isCutting)
        {
            UpdateCutting();
        }
    }

    void UpdateCutting()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;

        /*float velocity = (newPos - _prevPos).magnitude * Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            _collider.enabled = true;
        }
        else
            _collider.enabled = false;*/

        _prevPos = newPos;
    }

    void StartCutting()
    {
        _isCutting = true;
        _currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        _prevPos = cam.ScreenToWorldPoint(Input.mousePosition);
        _collider.enabled = true;
    }

    void StopCutting()
    {
        _isCutting = false;
        _currentBladeTrail.transform.SetParent(null);
        Destroy(_currentBladeTrail, 2f);
        _collider.enabled = false;

    }
}
