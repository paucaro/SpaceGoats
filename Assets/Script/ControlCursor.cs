using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCursor : MonoBehaviour
{
    public int tamañoCursor = 32;
    public Texture2D cursorPatita;
    Texture2D cursorActivo;

    void Start(){
        Cursor.visible = false;
        CambiarCursor(1);
    }

    public void CambiarCursor(int tipoCursor) {
        if (tipoCursor == 1) {
            cursorActivo = cursorPatita;
        }
    }

    void OnGUI() {
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, tamañoCursor, tamañoCursor), cursorActivo);
    }
}
