using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoyaleScroller : MonoBehaviour
{
    private float x, y;

    public ScrollRect mainScrollRect;

    public ScrollRect[] columnRects;

    public bool isDragingHorizontally = false;

    void Update()
    {
        if (!isDragingHorizontally)
        {
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");

            if (Mathf.Abs(x) > Mathf.Abs(y) + 1f)
            {
                isDragingHorizontally = true;
                DisableScrollRects();
            }
            else
            {
                isDragingHorizontally = false;
                EnableScrollRects();
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragingHorizontally = false;
            EnableScrollRects();
        }
    }

    private void DisableScrollRects()
    {
        HandleScrollRectsState(false);
    }

    private void EnableScrollRects()
    {
        HandleScrollRectsState(true);
    }

    private void HandleScrollRectsState(bool state)
    {
        if (columnRects != null)
        {
            for (int i = 0; i < columnRects.Length; i++)
            {
                columnRects[i].enabled = state;
            }
        }
    }
}