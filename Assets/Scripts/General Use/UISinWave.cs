using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISinWave : MonoBehaviour
{

    private Vector3 offset;
    public float ampX;
    public float frequencyX;
    public float offsetX;

    public float ampY;
    public float frequencyY;
    public float offsetY;

    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        offset = rt.position;
    }

    // Update is called once per frame
    void Update()
    {
        rt.position = new Vector3(Mathf.Sin((Time.time + offsetX) * frequencyX) * ampX, Mathf.Sin((Time.time * offsetY) * frequencyY) * ampY, 0f) + offset;
    }
}
