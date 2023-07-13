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
    public HoldInVelocityZone left;
    public float rightProgress;
    public HoldInVelocityZone right;
    public float gumProgress;
    public HoldInVelocityZone gum;
    public float timeProgress;
    public HoldInVelocityZone teeth;
    public TMP_Text dTimer;
    public int twoTime;
    public SpriteRenderer gross;
    public SpriteRenderer grossTop;
    public SpriteRenderer grossMid;
    public SpriteRenderer grossRight;
    public SpriteRenderer grossLeft;


    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        middleProgress = Mathf.Clamp(middle.time / middle.timeInZone, 0f, 1f);
        rightProgress = Mathf.Clamp(right.time / right.timeInZone, 0f, 1f);
        leftProgress = Mathf.Clamp(left.time / left.timeInZone, 0f, 1f);
        gumProgress = Mathf.Clamp(gum.time / gum.timeInZone, 0f, 1f);
        timeProgress = Mathf.Clamp(teeth.time / teeth.timeInZone, 0f, 1f);
        fill = (middleProgress + rightProgress + leftProgress + gumProgress + timeProgress) / 5;
        s.value = fill;
        twoTime = 120  - (int)(timeProgress * 120f);
        if(twoTime % 60 <= 9){
            dTimer.text = twoTime / 60 + ":0" + twoTime % 60;
        }else{
            dTimer.text = twoTime / 60 + ":" + twoTime % 60;
        }
        gross.color = new Color(1f, 1f, 1f, 1f - timeProgress);
        grossTop.color = new Color(1f, 1f, 1f, 1f - gumProgress);
        grossMid.color = new Color(1f, 1f, 1f, 1f - middleProgress);
        grossRight.color = new Color(1f, 1f, 1f, 1f - rightProgress);
        grossLeft.color = new Color(1f, 1f, 1f, 1f - leftProgress);
    }
}
