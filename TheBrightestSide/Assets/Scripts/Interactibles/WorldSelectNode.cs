using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelectNode : MonoBehaviour
{
    public KeyCode interactKey;
    [SerializeField]
    string textName;
    [SerializeField]
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<TextMesh>().text = textName;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(interactKey))
            {
                // Switch to "scene name" using scene controller
                FindObjectOfType<SceneController>().MoveToScene(sceneName);
            }
        }
    }
}
