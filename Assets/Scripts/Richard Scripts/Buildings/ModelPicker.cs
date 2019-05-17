using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPicker : MonoBehaviour
{
    public List<GameObject> models;

    // Start is called before the first frame update
    void Start()
    {
        PickModel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickModel()
    {
        int randIndex = Random.Range(0, models.Count - 1);
        GameObject myModel = Instantiate(models[randIndex], transform.parent.position, transform.parent.rotation, transform.parent);
    }

}
