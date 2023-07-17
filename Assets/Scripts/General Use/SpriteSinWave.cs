using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSinWave : MonoBehaviour
{
    private Vector3 offset;
    public float ampX;
    public float frequencyX;
    public float offsetX;

    public float ampY;
    public float frequencyY;
    public float offsetY;


    // Start is called before the first frame update
    void Start()
    {
        offsetX = Random.Range(0f, 2f);
        offsetY = Random.Range(0f, 2f);
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin((Time.time + offsetX) * frequencyX) * ampX, Mathf.Sin((Time.time + offsetY) * frequencyY) * ampY, 0f) + offset;
    }
}
