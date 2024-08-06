using UnityEngine;

/// <summary>�v���C���[�̎���s�@</summary>
public class Player : MonoBehaviour
{
    /// <summary>��C��R</summary>
    [SerializeField, Range(0f, 1f)] float _drag = 0.5f;

    /// <summary>�d��</summary>
    [SerializeField, Range(0f, 1f)] float _gravity = 0.75f;

    /// <summary>�W�����v��</summary>
    [SerializeField] float _jumpPower = 7.5f;

    // ����
    private Rigidbody2D _rb;

    // �X�v���C�g
    private SpriteRenderer _sprite;

    /// <summary>�v���C���[�̏�Ԃ�\���񋓌^</summary>
    private enum PlayerStatus
    {
        None, // �ʏ�
        LowGravity, // �d�͂��ア
        HighGravity, // �d�͂�����
        Invincible // ���G
    }


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        // ��C��R��ݒ肷��
        _rb.drag = _drag;

        // �d�͂�ݒ肷��
        _rb.gravityScale = _gravity;
    }

    void Update()
    {
        // �W�����v�L�[�����͂��ꂽ�ꍇ
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // ������̑��x�����Z�b�g����
            _rb.velocity = new Vector2(_rb.velocity.x, 0);

            // �v���C���[�̏���ɗ͂�������
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    /// <summary>�A�C�e�����擾�����ۂɂ��̌��ʂ�K�p���郁�\�b�h</summary>
    public void ApplyItemEffect()
    {

    }
}
