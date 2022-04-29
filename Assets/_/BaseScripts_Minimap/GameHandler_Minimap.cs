/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;
using GridPathfindingSystem;

public class GameHandler_Minimap : MonoBehaviour {

    public static GridPathfinding gridPathfinding;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private PlayerHandler characterHandler;

    private void Start() {
        cameraFollow.Setup(characterHandler.GetPosition, () => 80f);

        FunctionPeriodic.Create(SpawnEnemy, 1.5f);
        //FunctionTimer.Create(SpawnEnemy, 1f);

        gridPathfinding = new GridPathfinding(new Vector3(-400, -400), new Vector3(400, 400), 5f);
        gridPathfinding.RaycastWalkable();
        /*gridPathfinding.PrintMap((Vector3 pos, Vector3 scale, Color color) => {
            World_Sprite.Create(pos, scale, color);
        });*/
    }

    private Vector3 GetCameraPosition() {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 playerToMouseDirection = mousePosition - characterHandler.GetPosition();
        return characterHandler.GetPosition() + playerToMouseDirection * .3f;
    }

    private void SpawnEnemy() {
        Vector3 spawnPosition = PlayerHandler.instance.GetPosition() + UtilsClass.GetRandomDir() * 100f;
        Instantiate(GameAssets.i.pfEnemy, spawnPosition, Quaternion.identity);
    }

}


namespace Minimap {

    public class Minimap {
    }

}