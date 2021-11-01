using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platforminstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platform;
    private float x = 100;
    [SerializeField]
    private bool _isplayerdeath = false;
    private Player _player;
    [SerializeField]
    private GameObject _walls;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(spawnPlatformRoutine());
    }
    private void Update()
    {
        if (_player == null)
        {
            _isplayerdeath = true;
        }
    }
    // Update is called once per frame
    IEnumerator spawnPlatformRoutine()
    {
        while (_isplayerdeath == false)
        {
            //yield return new WaitForSeconds(10f);
            Instantiate(_platform[Random.Range(0, 3)], transform.position + new Vector3(0, 0, x), Quaternion.identity);
            Instantiate(_walls, transform.position + new Vector3(0, 0, x), Quaternion.identity);
            yield return new WaitForSeconds(10f);
            x += 100;
        }
    }
    public void playerDeath()
    {
        _isplayerdeath = true;
    }
}
