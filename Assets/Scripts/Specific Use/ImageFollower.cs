using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFollower : MonoBehaviour
{
    private Vector3 offset;
    public float multiplier;
    public RectTransform imageToFollow;
    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        offset = imageToFollow.position;
        rt = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rt.position = offset + (imageToFollow.position - offset) * multiplier;
    }
}
