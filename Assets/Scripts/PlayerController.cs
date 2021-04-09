using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
	public static PlayerController Instance;

	Action _playerTakeDamage;
	
	[SerializeField] PlayerConfigurationSO _playerConfigurationSO;
	[SerializeField] Transform[] _carPositions;
	
	InputReceiver _inputReceiver = new InputReceiver();
	Rigidbody _rbd;
	Material _material;
	
	Vector3 _moveVector;
	float _sideMoveInput;

	int _currentHealth;
	
	void Awake()
	{
		Instance = this;
		_inputReceiver.OnSlide = OnInputSlide;
		_currentHealth = _playerConfigurationSO.maxHealth;
		_rbd = GetComponent<Rigidbody>();
	}

	void Start()
	{
		CarInitialization();
	}

	void Update()
	{
		_inputReceiver.OnUpdate();
	}

	void FixedUpdate()
	{
		_moveVector = MoveForward();
		_moveVector.x += _sideMoveInput;
		_rbd.MovePosition(_moveVector);
	}

	Vector3 MoveForward()
	{
		return _rbd.position + Vector3.forward * _playerConfigurationSO.forwardMoveSpeedModifier;
	}

	void OnInputSlide(float diff)
	{
		_sideMoveInput = diff * _playerConfigurationSO.sideMoveSpeedModifier;
	}
	
	void CarInitialization()
	{
		MainCar mainCar = Instantiate(_playerConfigurationSO.mainCar, transform);
		mainCar.Init(TakeDamage);
		_material = mainCar.visual.material;
		
		int carCount = _playerConfigurationSO.Cars.Length;
		for (int i = 0; i < _carPositions.Length; i++)
		{
			ControllableCar car;
			
			if (i >= carCount)
			{
				int random = Random.Range(0, carCount);
				car = Instantiate(_playerConfigurationSO.Cars[random], _carPositions[i]);
			}
			else
			{
				car = Instantiate(_playerConfigurationSO.Cars[i], _carPositions[i]);
			}
			
			car.Init(OnGuardDestroyed);
		}
	}

	void OnGuardDestroyed()
	{
		// TODO play some vfx
		
	}

	void TakeDamage()
	{
		_currentHealth -= 1;
		if (_currentHealth <= 0)
		{
			Destroy(gameObject);
		}
		
		ChangeColorBasedOnRemainingHealth();
	}

	void ChangeColorBasedOnRemainingHealth()
	{
		float redSaturation = 1f - (float)_currentHealth / _playerConfigurationSO.maxHealth;
		Color newColor = _material.color;
		newColor.r = 255 * redSaturation;
		_material.color = newColor;
	}
}