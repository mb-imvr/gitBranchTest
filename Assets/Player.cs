using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
    }

    void LookAtTarget()
    {
        var direction = _target.transform.position - this.transform.position;
        transform.LookAt(_target.transform, Vector3.forward);

    }
}
