﻿using UnityEngine;

public interface ICharacter {

	// Character Components

	CharacterMain.CharacterSides Side { get; }

	CharacterMain.CharacterTypes Type { get; }
	
	CharacterStatsBase Stats { get; }

	ICharacterAIHandler AiHandler { get; }

	IMovement Movement { get; }

	ICharacterView View { get; }

	GameObject GObject { get; }

	// System Character Actions

	void Init ();

	void PurgeActions ();

	void Tick ();

	// Outside Character Facade

	void Navigate(Room room, bool full);

	void Heal(float amount);

}
