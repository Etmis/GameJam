using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrader : MonoBehaviour
{
    [SerializeField] GameObject paner;
    [SerializeField] List<Sprite> sprity;
    [SerializeField] Image sellImage;
    [SerializeField] Image upgradeImage;
    [SerializeField] TMPro.TMP_Text upgradeText;
    [SerializeField] TMPro.TMP_Text sellText;
    [SerializeField] TMPro.TMP_Text dmgText;


    public static bool IsUpgrading;
    bool readyToSell;
    bool readyToUpgrade;    
    Tower currentTower;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform the raycast
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 5))
            {

                var nig = hitInfo.transform.root.gameObject.GetComponent<Tower>();
                if (nig != null)
                {
                    if(!Escape.isInSettings && !Builder.builder)
                    {
                        currentTower = nig;
                        Debug.Log(nig);

                        Aktivuj();
                        
                    }
                    

                }
            }


        }
    }
    public void Return()
    {
        paner.SetActive(false);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        Time.timeScale = 1;
        if(PlayerPrefs.HasKey("sensitivity"))
        {
            PlayerMovement.sensitivity = PlayerPrefs.GetFloat("sensitivity");
        }
        else
        {
            PlayerMovement.sensitivity = 5;
        }
        sellImage.sprite = sprity[2];
        upgradeImage.sprite = sprity[0];
        IsUpgrading = false;
        readyToSell = false;
        readyToUpgrade = false;
        
    }
    void Aktivuj()
    {
        var js = currentTower.getInfo();
        upgradeText.text = js.moneyNeededToUpgrade.ToString();
        sellText.text = js.moneyGotIfSold.ToString();
        dmgText.text = js.dmgBeforeUpgrade.ToString() + "DMG";
        
        paner.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        Time.timeScale = 0;
        PlayerMovement.sensitivity = 0;
        IsUpgrading = true;
    }
    public void ProdejTO()
    {
        if(readyToSell)
        {
            currentTower.Sell();
            sellImage.sprite = sprity[2];
            SoundManager.PlaySound("sellTower");
            Return();


        }
        else
        {
           
            readyToSell = true;
            sellImage.sprite = sprity[3];

        }
    }
    public void UpgradniTo()
    {

        if (readyToUpgrade)
        {
            var nigg = currentTower.IsPossbileToUpgrade();
            if (!nigg)
            {

            }
            else
            {
                SoundManager.PlaySound("upgrade");
                Return();
                
            }
            

            


        }
        else
        {
            var js = currentTower.getInfo();
            readyToUpgrade = true;
            upgradeImage.sprite = sprity[3];
            dmgText.text = js.dmgAfterUpgrade.ToString() + "DMG";

        }
    }

   
}
