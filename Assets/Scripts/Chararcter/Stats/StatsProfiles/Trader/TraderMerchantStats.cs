using UnityEngine;
using System.Collections;

public class TraderMerchantStats : HumanStats {

	// Use this for initialization
	public override void Init()
	{
		base.Init();
		// Common
		Side 					= Enums.CharacterSides.Trader;
		Type 					= Enums.CharacterTypes.Merchant;
		WalkSpeed			 	= 0.5f;
		RunSpeed 				= 0.7f;
		BasicRoom 				= Ship.Inst.RoomByPoint(gameObject.transform.position);
		// Health
		MaxHealth 				= Random.Range(60, 80);
		Health 					= maxHealth;
		HealthIncrease 			= Random.Range(4, 6);
		HealthRegeneration 		= 0.1f;
		HealthReduction 		= 0.0f;
		HealthThreshold 		= Random.Range(15, 25);
		// Sanity
		MaxSanity				= Random.Range(60, 80);
		Sanity					= maxSanity;
		SanityIncrease			= Random.Range(4, 6);
		SanityRegeneration		= 0.0f;
		SanityReduction			= 0.0f;
		SanityThreshold			= Random.Range(15, 25);
		// Character Activities
		HealOther				= 0.0f;
		// Attack
		Damage					= 2.0f;
		AttackRate				= 1.0f;	
		AbbleDistantAttack		= false;
		// Traits
		ApplyNonCrewTraits (this);
	}

}
