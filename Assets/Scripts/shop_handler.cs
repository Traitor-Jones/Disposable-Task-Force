using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop_handler : MonoBehaviour
{   
    [SerializeField] private GameObject shopUI;
    [SerializeField] public static bool shopActive;
    [SerializeField] private GameObject errorUI;
    [SerializeField] private Text error_message;
    
    [Header("=== Boost Upgrade Things ===")]
    [SerializeField] private int boost_additive;
    [SerializeField] private int boost_cost;

    [Header("=== Health Restore Things ===")]
    [SerializeField] private int healthRestored;
    [SerializeField] private int health_cost;

    [Header("=== Revive Things ===")]
    [SerializeField] private int revive_cost;

    public static int num_revives;

    private void Update(){
        if(Input.GetKeyDown("o")){
            shopActive = !shopActive;
        }

        if(shopActive && !PauseMenuV1.isPaused){
            ActivateSHOP();
        }
        else{
            DeactivateSHOP();
        }
    }

    private void HandleErrorMessage(int errorCase){
        switch(errorCase){
            case 0:
                error_message.text = "Insufficient Funds!";
                break;
            case 1:
                error_message.text = "Health is already full!";
                break;
            case 2:
                error_message.text = "Boost is Already Maxed! (Max Value: 25)";
                break;
            default:
                break;
        }
    }

    public void PauseSHOP(){
        PauseMenuV1.isPaused = false;
        shopActive = true;
    }

    public void ActivateSHOP(){
        if(ThirdPersonShip.scene_start){
            if(PauseMenuV1.isPaused || shopActive)
                Time.timeScale = 0;
            shopUI.SetActive(true);
        }
    }

    public void DeactivateSHOP(){
        if(!PauseMenuV1.isPaused && !shopActive)
            Time.timeScale = 1;
        shopUI.SetActive(false);
        shopActive = false;
    }

    private void ActivateError(int errorCase){
        HandleErrorMessage(errorCase);
        errorUI.SetActive(true);
    }

    public void DeactivateError(){
        errorUI.SetActive(false);
    }

    private bool enoughCredits(int cost){
        if(Trash_Inventory.NumberOfTrash >= cost){
            return true;
        }
        else{
            ActivateError(0);
            return false;
        }
    }

    public void BuyHealth(){
        if(enoughCredits(health_cost)){
            if(ShipHealth.ship_health == 100){
                ActivateError(1);
            }
            else{
                if(ShipHealth.ship_health + healthRestored >= 100){
                ShipHealth.ship_health = 100;
                }
                else{
                    ShipHealth.ship_health += healthRestored;
                }
                Trash_Inventory.NumberOfTrash -= health_cost;
            }
        }
    }

    public void BuyBoost(){
        if(enoughCredits(boost_cost)){
            if(ThirdPersonShip.boostMultiplier == 25){
                ActivateError(2);
            }
            else{
                ThirdPersonShip.boostMultiplier += 2;
                Trash_Inventory.NumberOfTrash -= boost_cost;
            }
        }
    }

    public void BuyRevive(){
        if(enoughCredits(revive_cost)){
            num_revives++;
            Trash_Inventory.NumberOfTrash -= revive_cost;
        }
    }
}
