using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Builder : MonoBehaviour
{
    Escape EscapeCanvas;
    [SerializeField] Transform towerHolder;
    [SerializeField] GameObject buildPanel;
    [SerializeField] GameObject[] towerky;
    bool isSetOnTower;
    void Start()
    {
        isSetOnTower = false;
        EscapeCanvas = FindAnyObjectByType<Escape>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            buildPanel.SetActive(true);
            Escape.MenuContextStuffNeeded();
        }
    }
    public void SetOnTowerHolder()
    {
        
        if(!isSetOnTower)
        {
            EscapeCanvas.OutOfMenuContextStuffNeeded();
            buildPanel.SetActive(false);
            var tower = Instantiate(towerky[0], towerHolder.position, Quaternion.identity);
            tower.transform.parent = towerHolder.transform;
            isSetOnTower = true;
        }
        else
        {
            buildPanel.SetActive(false);
            EscapeCanvas.OutOfMenuContextStuffNeeded();
        }
        

    }
}

