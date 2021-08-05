using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glow : MonoBehaviour
{
    const float fixedTime = 3.0f;
    float timer = 0.0f;
    float glowtimer = 0.0f;
    bool up = false;
    SpriteRenderer spr;
    Color color;
    void Start()
    {
        spr = this.gameObject.GetComponent<SpriteRenderer>();

        this.color = spr.color;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        this.timer += Time.deltaTime;
        this.glowtimer += Time.deltaTime;
        if (this.glowtimer > 0.5f)
        {
            this.glowtimer = 0.0f;
            this.up = !this.up;

        }

        if (this.up)
        {

            if (this.color.a > 0)
            {
                this.color.a -= 0.03f;
                spr.color = this.color;

                Debug.Log("D" + spr.color.a);
                //this.gameObject.GetComponent<SpriteRenderer>().color = color;
            }
        }
        else
        {
            if (this.color.a < 1)
            {
                this.color.a += 0.01f;
                spr.color = this.color;
                Debug.Log("Up" + spr.color.a);

                //this.gameObject.GetComponent<SpriteRenderer>().color = color;
            }

        }

        if (this.timer > 3.0f)
        {
            Destroy(this.gameObject);
        }
        
    }
}
