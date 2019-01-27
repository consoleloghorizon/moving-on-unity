using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    ItemEntity[,] itemGrid = new ItemEntity[1, 2];
    List<ItemEntity> items;

    Vector2 gridDimensions;
    public GameObject itemRef;
    bool initialized = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (initialized)
            return;
        gridDimensions = GetComponent<RectTransform>().rect.size;

        Debug.Log(gridDimensions);

        GameObject itemInstance = Instantiate(itemRef, transform);

        itemInstance.SetActive(true);


        initialized = true;
    }
}
