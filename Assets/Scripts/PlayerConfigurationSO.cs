using UnityEngine;

[CreateAssetMenu(fileName = "Player Config", menuName = "Player Config", order = 0)]
public class PlayerConfigurationSO : ScriptableObject
{
	public MainCar mainCar;
	public ControllableCar[] Cars;

	public int maxHealth;
	public float sideMoveSpeedModifier;
	public float forwardMoveSpeedModifier;
}