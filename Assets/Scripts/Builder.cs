using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    [SerializeField]
    List<GameObject> towers = new List<GameObject>();

    [SerializeField]
    List<GameObject> fakeTowers = new List<GameObject>();

    private int index = 0;
    private bool builder = false;
    private GameObject currentTower;
    private GameObject preview;
    private RaycastHit lastHit;

    // Start is called before the first frame update
    void Start()
    {
        currentTower = towers[0];
    }

    // Update is called once per frame
    void Update()
    {
        CheckButton();

        if (builder)
        {
            Scroll();
            if (Input.GetButtonDown("Fire1"))
            {
                InstantiateTowerIfNoCollision();
            }
            Preview();
        }
    }

    private void CheckButton()
    {
        if (Input.GetButtonDown("Builder"))
        {
            if (builder)
            {
                builder = false;
                currentTower = towers[0];
            }
            else if (!builder)
            {
                builder = true;
            }
        }
    }

    private void Scroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // input koleèko myši nahoru
        {
            index++;
            if (index > towers.Count - 1)
            {
                index = 0;
            }
            currentTower = towers[index];
            Debug.Log(index);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // input koleèko myši dolù
        {
            index--;
            if (index < 0)
            {
                index = towers.Count - 1;
            }
            currentTower = towers[index];
            Debug.Log(index);
        }
    }

    private void InstantiateTowerIfNoCollision()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool canSpawn = true;

        if (Physics.Raycast(ray, out hit))
        {
            // Kontrola, zda je na pozici kurzoru myši kolizní objekt
            Collider[] colliders = Physics.OverlapSphere(hit.point, 2f); // Pravdìpodobnìjší velikost pro vìže
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Blockator"))
                {
                    canSpawn = false;
                }
            }
            if (canSpawn)
            {
                Instantiate(currentTower, hit.point, Quaternion.identity);
            }
            canSpawn = true;
        }
    }

    private void Preview()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (lastHit.point != hit.point)
            {
                lastHit = hit;
                preview = Instantiate(currentTower, hit.point, Quaternion.identity);
            }
        }
    }
}
