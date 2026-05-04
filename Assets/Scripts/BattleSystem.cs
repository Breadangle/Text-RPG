using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    //public GameObject playerPrefab;
    public GameObject Player;
    public GameObject enemyPrefab;

    //public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit PlayerUnit;
    Unit EnemyUnit;

    public TextMeshProUGUI dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
    }

    void SetUpBattle()
    {
        PlayerUnit = Player.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        EnemyUnit = enemyGo.GetComponent<Unit>();

        dialogueText.text = "a wild " + EnemyUnit.unitName + " approaches.";

        playerHUD.SetHUD(PlayerUnit);
        enemyHUD.SetHUD(EnemyUnit);
    }
}
