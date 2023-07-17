using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompositeBar : MonoBehaviour
{
    private Slider s;
    private float fill;
    public float middleProgress;
    public HoldInVelocityZone middle;
    public float leftProgress;
    public HoldInVelocityZone back;
    public float backProgress;
    public HoldInVelocityZone left;
    public float rightProgress;
    public HoldInVelocityZone right;
    public float gumProgress;
    public HoldInVelocityZone gum;
    public TMP_Text dTimer;
    public int twoTime;
    public SpriteRenderer grossTop;
    public SpriteRenderer grossMid;
    public SpriteRenderer grossRight;
    public SpriteRenderer grossLeft;
    public SpriteRenderer grossBack;
    public GameObject closedTeeth;
    public GameObject openTeeth;
    public bool opened;


    // Start is called before the first frame update
    void Start()
    {
        opened = false;
        s = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        middleProgress = Mathf.Clamp(middle.time / middle.timeInZone, 0f, 1f);
        rightProgress = Mathf.Clamp(right.time / right.timeInZone, 0f, 1f);
        leftProgress = Mathf.Clamp(left.time / left.timeInZone, 0f, 1f);
        gumProgress = Mathf.Clamp(gum.time / gum.timeInZone, 0f, 1f);
        backProgress = Mathf.Clamp(back.time / back.timeInZone, 0f, 1f);
        fill = (middleProgress + rightProgress + leftProgress + gumProgress + backProgress) / 5;
        s.value = fill;
        twoTime = 120  - (int)(fill * 120f);
        if(twoTime % 60 <= 9){
            dTimer.text = twoTime / 60 + ":0" + twoTime % 60;
        }else{
            dTimer.text = twoTime / 60 + ":" + twoTime % 60;
        }
        grossTop.color = new Color(1f, 1f, 1f, 1f - gumProgress);
        grossMid.color = new Color(1f, 1f, 1f, 1f - middleProgress);
        grossRight.color = new Color(1f, 1f, 1f, 1f - rightProgress);
        grossLeft.color = new Color(1f, 1f, 1f, 1f - leftProgress);
        grossBack.color = new Color(1f, 1f, 1f, 1f - backProgress);

        if(fill >= .7999 && !opened){
            opened = true;
            closedTeeth.SetActive(false);
            openTeeth.SetActive(true);
        }
    }
}
