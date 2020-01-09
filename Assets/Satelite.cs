using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satelite : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private float _spawnDelay = 0.5f;
    [SerializeField]
    private float _randomFloat = 25f;
    [SerializeField]
    private float _moveSpeed = 0.2f;
    [SerializeField]
    private GameObject _startPosition, _endPosition;

    private bool _movingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        _movingLeft = false;
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }


    private float RandomFloat()
    {
        return Random.Range(-_randomFloat, _randomFloat);
    }

    IEnumerator SpawnRoutine()
    {
        while (true){
            yield return new WaitForSeconds(_spawnDelay);
            Vector3 position = new Vector3(RandomFloat(), RandomFloat(), RandomFloat());
            Instantiate(_player, position, Quaternion.identity);
        }
    }

    void MoveObject()
    {
        if (!_movingLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endPosition.transform.position, _moveSpeed);
            if(transform.position.x >= _endPosition.transform.position.x)
            {
                _movingLeft = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition.transform.position, _moveSpeed);
            if(transform.position.x <= _startPosition.transform.position.x)
            {
                _movingLeft = false;
            }
        }
    }
}
