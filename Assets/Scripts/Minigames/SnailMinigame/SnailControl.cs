using System.Collections;
using UnityEngine;

public enum OtroPlayerType
{
    Caracol1,
    Caracol2
}

public class SnailControl : MonoBehaviour
{
    Animator animator;
    public AudioClip explosionSound;

    public OtroPlayerType playerType;
    public float impulso = 5f;
    private bool isImpulseActivated = false;
    private bool previousAnimationState;
    private int keyPressCount = 0;
    private float lastKeyPressTime;

    private Rigidbody2D rb;

    [SerializeField] SnailGameManager snailGameManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!GameManager.Instance.gamePaused)
        { 
            switch (playerType)
            {
                case OtroPlayerType.Caracol1:
                    HandleInput(KeyCode.D, true);
                    break;

                case OtroPlayerType.Caracol2:
                    HandleInput(KeyCode.RightArrow, true);
                    break;
            }
        }
    }

    void HandleInput(KeyCode key, bool activateAnimation)
    {
        if (Input.GetKeyDown(key) && !isImpulseActivated)
        {
            float currentTime = Time.time;
            if (currentTime - lastKeyPressTime < 0.7f)
            {
                keyPressCount++;
                if (keyPressCount >= 5)
                {
                    animator.SetBool("Cansado", true);

                    if (keyPressCount == 12)
                    {
                        animator.SetTrigger("Explotar");
                    }
                }
            }
            else
            {
                StartCoroutine(NoCansado());
            }

            lastKeyPressTime = currentTime;

            SavePreviousAnimationState();
            StartCoroutine(ApplyImpulse());
            SetAnimation(activateAnimation);
        }
    }

    void SavePreviousAnimationState()
    {
        previousAnimationState = animator.GetBool("Impulse");
    }

    public void ExplosionSoundEffect()
    {
        GetComponent<AudioSource>().PlayOneShot(explosionSound, 1f);
    }

    void SetAnimation(bool activate)
    {
        animator.SetBool("Impulse", activate);
    }
    IEnumerator NoCansado()
    {
        yield return new WaitForSeconds(2f); 
        animator.SetBool("Cansado", false);
    }
    IEnumerator ApplyImpulse()
    {
        isImpulseActivated = true;
        rb.velocity = new Vector2(impulso, rb.velocity.y);
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector2.zero;
        isImpulseActivated = false;
        SetAnimation(previousAnimationState);
    }

    public void OnExplosionAnimationEnd()
    {
        GetComponent<AudioSource>().PlayOneShot(explosionSound, 0.5f);
        switch (playerType)
        {
            case OtroPlayerType.Caracol1:

                snailGameManager.victoryScreen.SetActive(true);
                snailGameManager.playerCrossedTheLine = true;
                GameManager.Instance.gamePaused = true;
                GameManager.Instance.playerVicotries[1] = GameManager.Instance.playerVicotries[1] + 1;
                snailGameManager.winnerPlayerText.text = "PLAYER 2 WON THE RACE!!!";
                break;
            case OtroPlayerType.Caracol2:
                snailGameManager.victoryScreen.SetActive(true);
                snailGameManager.playerCrossedTheLine = true;
                GameManager.Instance.gamePaused = true;
                GameManager.Instance.playerVicotries[0] = GameManager.Instance.playerVicotries[0] + 1;
                snailGameManager.winnerPlayerText.text = "PLAYER 1 WON THE RACE!!!";
                HandleInput(KeyCode.RightArrow, true);
                break;
        }
        GameManager.Instance.CloseCurtainAnimations();
        Destroy(gameObject);
    }
}
