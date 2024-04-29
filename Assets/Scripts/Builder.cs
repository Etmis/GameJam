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

    [SerializeField]
    List<Sprite> images = new List<Sprite>();

    public Image img;

    [SerializeField]
    GameObject parent;

    private int index = 0;
    public static bool builder = false;
    private GameObject currentTower;
    private static GameObject preview;

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
            Preview();
            if (Input.GetButtonDown("Fire1"))
            {
                InstantiateTowerIfNoCollision();
            }
            img.sprite = images[index];
        }
    }

    private void CheckButton()
    {
        if (Input.GetButtonDown("Builder") && !Escape.isInSettings&& !Upgrader.IsUpgrading)
        {
            if (builder)
            {
                builder = false;
                currentTower = towers[0];
                img.gameObject.SetActive(false);
                Destroy(preview);
            }
            else if (!builder)
            {
                builder = true;
                img.gameObject.SetActive(true);
            }
        }
    }

    private void Scroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // input koleèko myši nahoru
        {
            Destroy(preview);
            preview = null;
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
            Destroy(preview);
            preview = null;
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
        Debug.Log("Spawnuju tower " + currentTower);
        int layerMask = LayerMask.GetMask("FakeTower");
        if (Money.Instance.CurrentMoney >= currentTower.GetComponent<Tower>().price)
        {
            if (Physics.Raycast(ray, out hit, 5, ~layerMask))
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, 2f);
                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag("Blockator") || collider.CompareTag("Tower"))
                    {                       
                        canSpawn = false;
                    }
                }
                if (canSpawn)
                {
                    Money.Instance.Remove(currentTower.GetComponent<Tower>().price);
                    Instantiate(towers[index], hit.point, Quaternion.identity);
                    SoundManager.PlaySound("build");
                }
                canSpawn = true;
            }
        }
    }

    private void Preview()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMask1 = LayerMask.GetMask("FakeTower");
        int layerMask2 = LayerMask.GetMask("Tower");
        int combinedLayerMask = layerMask1 | layerMask2;
        if (Physics.Raycast(ray, out hit, 5, ~combinedLayerMask))
        {
            parent.transform.position = hit.point;

            if (preview == null)
            {
                preview = Instantiate(fakeTowers[index], hit.point, Quaternion.identity);
                preview.transform.SetParent(parent.transform);
            }
        }
        else
        {
            if (preview != null)
            {
                Destroy(preview);
                preview = null;
            }
        }
    }
}
