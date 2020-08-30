using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event System.Action<Block> OnBlockPressed;
	public event System.Action OnFinishedMoving;

    public Vector2Int coord;
    Vector2Int startingCoord;
    //Collider collider;

    public void Init(Vector2Int startingCoord, Texture2D image)
    {
        this.startingCoord = startingCoord;
        coord = startingCoord;

        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Block");
        GetComponent<MeshRenderer>().material.mainTexture = image;
        //collider = GetComponent<Collider>();
    }

    public void MoveToPosition(Vector2 target, float duration)
    {
        StartCoroutine(AnimateMove(target, duration));
    }

    /*void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (collider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (OnBlockPressed != null)
                {
                    OnBlockPressed(this);
                }
            }
        }
    }*/

    void OnMouseDown()
    {
        if (OnBlockPressed != null)
        {
            OnBlockPressed(this);
        }
    }

    IEnumerator AnimateMove(Vector2 target, float duration)
    {
        Vector2 initialPos = transform.position;
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime / duration;
            transform.position = Vector2.Lerp(initialPos, target, percent);
            yield return null;
        }

        if (OnFinishedMoving != null)
        {
            OnFinishedMoving();
        }
    }

    public bool IsAtStartingCoord()
    {
        return coord == startingCoord;
    }
}
