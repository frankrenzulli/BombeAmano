using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public BombAnimation startAnim;
    public BombAnimation middleAnim;
    public BombAnimation endAnim;

    public void SetActiveRenderer(BombAnimation renderer)
    {
        if (renderer == startAnim)
        {
            startAnim.enabled = true;
        }
        else
        {
            startAnim.enabled = false;
        }

        if (renderer == middleAnim)
        {
            middleAnim.enabled = true;
        }
        else
        {
            middleAnim.enabled = false;
        }
        if (renderer == endAnim)
        {
            endAnim.enabled = true;
        }
        else
        {
            endAnim.enabled = false;
        }


    }

    //ruota l'oggetto in base alla variabile dir che viene presa dallo script bombPlacer 
    public void SetDirection(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void DestroyTime(float time)
    {
        Destroy(gameObject, time);
    }


}
