using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerAnimationManager animationManager;
    private Rigidbody2D _rig;

    [Header("Movement")] public float moveAccel;
    public float maxSpeed;

    [Header("Jump")] public float jumpAccel;
    private bool _isJumping;
    private bool _isGround;

    [Header("Ground Raycast")] public float groundRaycastDistance;
    public LayerMask groundLayerMask;

    private CharacterSoundController _sound;

    [Header("Scoring")] public ScoreController score;
    public float scoringRatio;
    private float _lastPositionX;

    [Header("GameOver")] public GameObject gameOverScreen;
    public float fallPositionY;

    [Header("Camera")] public CameraFollow gameCamera;

    private void Start()
    {
        animationManager.Running(true);
        _rig = GetComponent<Rigidbody2D>();
        _sound = GetComponent<CharacterSoundController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isGround)
            {
                _isJumping = true;
                _sound.PlayJump();
            }
        }

        animationManager.SetIsGround(_isGround);

        CalculateScore();

        if (transform.position.y < fallPositionY)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        score.FinishScoring();
        gameCamera.enabled = false;
        gameOverScreen.SetActive(true);
        enabled = false;
    }

    private void CalculateScore()
    {
        int distancePassed = Mathf.FloorToInt(transform.position.x - _lastPositionX);
        int scoreIncrement = Mathf.FloorToInt(distancePassed / scoringRatio);

        if (scoreIncrement > 0)
        {
            score.IncreaseCurrentScore(scoreIncrement);
            _lastPositionX += distancePassed;
        }
    }


    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundRaycastDistance, groundLayerMask);
        if (hit)
        {
            if (!_isGround && _rig.velocity.y <= 0) _isGround = true;
        }
        else
        {
            _isGround = false;
        }

        Vector2 velocityVector = _rig.velocity;

        if (_isJumping)
        {
            velocityVector.y += jumpAccel;
            _isJumping = false;
        }

        velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);
        _rig.velocity = velocityVector;
    }


    private void OnDrawGizmos()
    {
        var currentTransform = transform;
        var position = currentTransform.position;
        Debug.DrawLine(position, position + (Vector3.down * groundRaycastDistance), Color.white);
    }
}
