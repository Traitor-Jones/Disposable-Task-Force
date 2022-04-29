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
using V_AnimationSystem;
using CodeMonkey.Utils;
using CodeMonkey;
using GridPathfindingSystem;

public class EnemyHandler : MonoBehaviour {

    public static List<EnemyHandler> enemyHandlerList = new List<EnemyHandler>();

    public static EnemyHandler GetClosestEnemy(Vector3 position, float maxRange) {
        EnemyHandler closest = null;
        foreach (EnemyHandler enemyHandler in enemyHandlerList) {
            if (enemyHandler.IsDead()) continue;
            if (Vector3.Distance(position, enemyHandler.GetPosition()) <= maxRange) {
                if (closest == null) {
                    closest = enemyHandler;
                } else {
                    if (Vector3.Distance(position, enemyHandler.GetPosition()) < Vector3.Distance(position, closest.GetPosition())) {
                        closest = enemyHandler;
                    }
                }
            }
        }
        return closest;
    }

    private const float speed = 30f;

    private V_UnitSkeleton unitSkeleton;
    private V_UnitAnimation unitAnimation;
    private AnimatedWalker animatedWalker;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    private int health;
    private float pathfindingTimer;

    private State state;
    private enum State {
        Normal,
        Busy
    }

    private void Awake() {
        enemyHandlerList.Add(this);
        health = 2;
        state = State.Normal;
    }

    private void Start() {
        Transform bodyTransform = transform.Find("Body");
        unitSkeleton = new V_UnitSkeleton(1f, bodyTransform.TransformPoint, (Mesh mesh) => bodyTransform.GetComponent<MeshFilter>().mesh = mesh);
        unitAnimation = new V_UnitAnimation(unitSkeleton);
        animatedWalker = new AnimatedWalker(unitAnimation, UnitAnimType.GetUnitAnimType("dMinion_Idle"), UnitAnimType.GetUnitAnimType("dMinion_Walk"), 1f, 1f);

        /*if (PlayerHandler.instance != null) {
            PathRoute pathRoute = GridPathfinding.instance.GetPathRouteWithShortcuts(GetPosition(), PlayerHandler.instance.GetPosition());
            foreach (Vector3 vec in pathRoute.pathVectorList) {
                World_Sprite.Create(vec, Vector3.one * 1f);
            }
        }*/
    }

    private void Update() {
        unitSkeleton.Update(Time.deltaTime);
        pathfindingTimer -= Time.deltaTime;

        switch (state) {
        case State.Normal:
            HandleMovement();
            FindTarget();
            break;
        case State.Busy:
            break;
        }
    }

    private void FindTarget() {
        float targetRange = 100f;
        float attackRange = 15f;
        if (PlayerHandler.instance != null) {
            if (Vector3.Distance(PlayerHandler.instance.GetPosition(), GetPosition()) < attackRange) {
                StopMoving();
                state = State.Busy;
                unitAnimation.PlayAnimForced(UnitAnimType.GetUnitAnimType("dMinion_Attack"), 1f, (UnitAnim unitAnim) => {
                    // Attack complete
                    state = State.Normal;
                }, null, null);
            } else {
                if (Vector3.Distance(PlayerHandler.instance.GetPosition(), GetPosition()) < targetRange) {
                    if (pathfindingTimer <= 0f) {
                        pathfindingTimer = .3f;
                        SetTargetPosition(PlayerHandler.instance.GetPosition());
                    }
                }
            }
        }
    }

    public bool IsDead() {
        return health <= 0;
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public void Damage() {
        Vector3 bloodDir = (GetPosition() - PlayerHandler.instance.GetPosition()).normalized;
        Blood_Handler.SpawnBlood(GetPosition(), bloodDir);
        health--;
        if (IsDead()) {
            FlyingBody.Create(GameAssets.i.pfEnemyFlyingBody, GetPosition(), bloodDir);
            Destroy(gameObject);
        } else {
            // Knockback
            transform.position += bloodDir * 5f;
        }
    }

    private void HandleMovement() {
        if (pathVectorList != null) {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f) {
                Vector3 moveDir = (targetPosition - transform.position).normalized;

                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                animatedWalker.SetMoveVector(moveDir);
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
            } else {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count) {
                    StopMoving();
                    animatedWalker.SetMoveVector(Vector3.zero);
                }
            }
        } else {
            animatedWalker.SetMoveVector(Vector3.zero);
        }
    }

    private void StopMoving() {
        pathVectorList = null;
    }

    public void SetTargetPosition(Vector3 targetPosition) {
        currentPathIndex = 0;
        pathVectorList = GridPathfinding.instance.GetPathRouteWithShortcuts(GetPosition(), targetPosition).pathVectorList;
        if (pathVectorList != null && pathVectorList.Count > 1) {
            pathVectorList.RemoveAt(0);
        }
    }

}