using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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

    // �e�A�C�e���̌��ʎ���
    private Dictionary<Item.ItemType, float> _itemEffectDurations = new Dictionary<Item.ItemType, float>();

    // �e�A�C�e���̌��ʃt���O
    private Dictionary<Item.ItemType, bool> _itemEffectFlags = new Dictionary<Item.ItemType, bool>();

    // ���݂̏d��
    private float _currentGravity;

    // �Q�[���I�[�o�[�̃t���O
    private bool _isGameOver;

    private bool _isDropping;

    // �v���C���[�̃C���X�^���X
    public static Player Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        // ��C��R��ݒ肷��
        _rb.drag = _drag;

        // �d�͂�ݒ肷��
        _rb.gravityScale = _gravity;

        _currentGravity = _gravity;

        // �e�A�C�e���̌��ʎ��Ԃ�������
        for(int i = 1; i <= 3; i++)
        {
            _itemEffectDurations[(Item.ItemType)i] = 0f;
            _itemEffectFlags[(Item.ItemType)i] = false;
        }
    }

    void Update()
    {
        if(_isDropping)
        {
            var current = transform.position;
            current.y -= Time.deltaTime * 2f;
            transform.position = current;
        }

        // �Q�[���I�[�o�[�Ȃ珈���𔲂���
        if (_isGameOver)
        {
            return;
        }

        // �W�����v�L�[�����͂��ꂽ�ꍇ
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // ������̑��x�����Z�b�g����
            _rb.velocity = new Vector2(_rb.velocity.x, 0);

            // �v���C���[�̏���ɗ͂�������
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);

            StartCoroutine(Rotate());
        }

        for (int i = 1; i <= 3; i++)
        {
            if(_itemEffectFlags[(Item.ItemType)i])
            {
                _itemEffectDurations[(Item.ItemType)(i)] -= Time.deltaTime;

                if(_itemEffectDurations[(Item.ItemType)(i)] <= 0f)
                {
                    _itemEffectDurations[(Item.ItemType)(i)] = 0f;
                    _itemEffectFlags[(Item.ItemType)(i)] = false;
                    DeactivateItemEffect((Item.ItemType)(i));
                }
            }
        }
    }

    /// <summary>�A�C�e�����擾�����ۂɌĂ΂�鏈��</summary>
    public void CollectItem(Item.ItemType item)
    {
        // ���ɃA�C�e�����擾���Ă���ꍇ�͌��ʎ��Ԃ���������
        if (_itemEffectFlags[item] == true)
        {
            _itemEffectDurations[item] += 3f;
        }
        // ���߂Ď擾����ꍇ�͌��ʎ��Ԃ�3�b�ɐݒ肷��
        else
        {
            _itemEffectDurations[item] = 3f;
            _itemEffectFlags[item] = true;
            ActivateItemEffect(item);
        }  
    }

    private void ActivateItemEffect(Item.ItemType item)
    {
        switch (item)
        {
            case Item.ItemType.Feather:

                DecreaseGravity(); break;

            case Item.ItemType.Crow:

                IncreaseGravity(); break;

            case Item.ItemType.Origami:

                EnableInvincibility(); break;
        }
    }

    private void DeactivateItemEffect(Item.ItemType item)
    {
        switch (item)
        {
            case Item.ItemType.Feather:

                IncreaseGravity(); break;

            case Item.ItemType.Crow:

                DecreaseGravity(); break;

            case Item.ItemType.Origami:

                DisableInvincibility(); break;
        }
    }

    /// <summary>�d�͂���߂�</summary>
    private void DecreaseGravity()
    {
        float newGravity = _currentGravity / 2;
        _currentGravity = newGravity;
        _rb.gravityScale = newGravity;
    }

    /// <summary>�d�͂����߂�</summary>
    private void IncreaseGravity()
    {
        float newGravity = _currentGravity * 2;
        _currentGravity = newGravity;
        _rb.gravityScale = newGravity;
    }

    /// <summary>���G��Ԃɂ���</summary>
    private void EnableInvincibility()
    {
        _itemEffectFlags[Item.ItemType.Origami] = true;
    }

    /// <summary>���G��Ԃ���������</summary>
    private void DisableInvincibility()
    {
        _itemEffectFlags[Item.ItemType.Origami] = false;
    }

    /// <summary>�v���C���[�����G��Ԃł��邩</summary>
    public bool IsInvincible()
    {
        return _itemEffectFlags[Item.ItemType.Origami];
    }

    /// <summary>�v���C���[����]������R���[�`��</summary>
    private IEnumerator Rotate()
    {
        transform.rotation = Quaternion.Euler(0, 0, 55f);

        yield return new WaitForSeconds(1f);

        transform.rotation = Quaternion.Euler(0, 0, 15f);
    }

    /// <summary>�Q�[���I�[�o�[���̏���</summary>
    public void OnGameOver()
    {
        // �Q�[���I�[�o�[�t���O���I��
        _isGameOver = true;

        // �������Ȃ��悤�ɂ���
        _rb.gravityScale = 0;

        var newPos = transform.position;
        newPos.x += 5f;
        transform.position = new Vector3(newPos.x, newPos.y, newPos.z);

        BackgroundController.Instance.enabled = false;
    }

    public void SetIsDroppingTrue()
    {
        _isDropping = true;
    }
}
