using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    //public GameObject playerPrefab;
    public GameObject Player;
    public GameObject enemyPrefab;
    public GameObject BattleMenu;

    //public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit PlayerUnit;
    Unit EnemyUnit;
    PlayerController BattleOn;

    public TextMeshProUGUI dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }
    private void Reset()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        PlayerUnit = Player.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        EnemyUnit = enemyGo.GetComponent<Unit>();

        dialogueText.text = "a " + EnemyUnit.unitName + " approaches.";

        playerHUD.SetHUD(PlayerUnit);
        enemyHUD.SetHUD(EnemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        print("player pressed attack");
        // Damage enemy
        bool isDead = EnemyUnit.TakeDamage(PlayerUnit.damage);
        enemyHUD.SetHP(EnemyUnit.currentHP);
        dialogueText.text = "The attack is successful";

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            // end battle
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            // enemy turn
            StartCoroutine(EnemyTurn());

        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = EnemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = PlayerUnit.TakeDamage(EnemyUnit.damage);

        playerHUD.SetHP(PlayerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead) 
        {
            state = BattleState.LOST;
            EndBattle();
        } else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        BattleOn = Player.GetComponent<PlayerController>();
        if (state == BattleState.WON)
        {
            dialogueText.text = "You survived!";
            BattleMenu.SetActive(false);
            Reset();
            BattleOn.inBattle = false;
        }
        else if (state == BattleState.LOST){
            dialogueText.text = "You have died";
            BattleMenu.SetActive(false);
            Reset();
            BattleOn.inBattle = false;
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an Action";
    }

    IEnumerator PlayerHeal ()
    {
        PlayerUnit.Heal(5);
        playerHUD.SetHP(PlayerUnit.currentHP);
        dialogueText.text = "You recover a little";

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) {
            return;
            }

        StartCoroutine(PlayerAttack());
    }

    public void OnSkillButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());
    }
}
