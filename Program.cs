// Hunting the Manticore

// currentLife / maxLife
int[] manticoreLife = [10, 10];
int[] consolasLife = [15, 15];
int round = 1;
int cannonDamage = 0;
int cannonRange = 0;
int manticorePosition = 0;

Console.Title = "Hunting the Manticore";
Console.ForegroundColor = ConsoleColor.White;

manticorePosition = AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore?", 0, 100);

Console.Clear();

Console.WriteLine("Player 2, it is your turn.");



do {
	PrintRoundStatus(round, manticoreLife, consolasLife);
	cannonDamage = CannonDamage(round);
	cannonRange = AskForNumber("Enter desired cannon range:");
	CalculateDamage(cannonDamage, cannonRange, manticorePosition, manticoreLife, consolasLife);
	CheckForEndgame(manticoreLife, consolasLife);
	round++;
} while (manticoreLife[0] > 0 && consolasLife[0] > 0);

void CheckForEndgame(int[] manticoreLife, int[] consolasLife) {
	if (manticoreLife[0] <= 0) {
		Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
	} else if (consolasLife[0] <= 0) {
		Console.WriteLine("The Manticore has utterly destroyed the city of Consolas! You lose.");
	}
}

void CalculateDamage(int cannonDamage, int cannonRange, int manticorePosition, int[] manticoreLife, int[] consolasLife) {
	if (cannonRange == manticorePosition) {
		Console.WriteLine("The round was a DIRECT HIT!");
		manticoreLife[0] -= cannonDamage;
	} else if (cannonRange < manticorePosition) {
		Console.WriteLine("The round FELL SHORT of the target.");
		consolasLife[0] -= 1;
	} else {
		Console.WriteLine("The round OVERSHOT the target.");
		consolasLife[0] -= 1;
	}
}

void PrintRoundStatus(int round, int[] manticoreLife, int[] consolasLife) {
	Console.WriteLine("-----------------------------------------------------------");
	Console.ForegroundColor = ConsoleColor.Cyan;
	Console.WriteLine($"STATUS: Round: {round}  City: {consolasLife[0]}/{consolasLife[1]}  Manticore: {manticoreLife[0]}/{manticoreLife[1]}");
	Console.ForegroundColor = ConsoleColor.White;
}

int AskForNumber(string text) {
	Console.Write(text + " ");
	int number = Convert.ToInt32(Console.ReadLine());
	return number;
}

int AskForNumberInRange(string text, int min, int max) {
	while (true) {
		int number = AskForNumber(text);
		if (number >= min && number <= max)
			return number;
	}
}

int CannonDamage(int number) {
	int dmg = 1;
	if (number % 5 == 0 && number % 3 == 0) {
		Console.Write("The cannon is expected to deal ");
		Console.ForegroundColor = ConsoleColor.Cyan;
		dmg = 10;
		Console.Write(dmg);
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write(" damage this round.\n");
	} else if (number % 5 == 0) {
		Console.Write("The cannon is expected to deal ");
		Console.ForegroundColor = ConsoleColor.Yellow;
		dmg = 3;
		Console.Write(dmg);
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write(" damage this round.\n");
	} else if (number % 3 == 0) {
		Console.Write("The cannon is expected to deal ");
		Console.ForegroundColor = ConsoleColor.Red;
		dmg = 3;
		Console.Write(dmg);
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write(" damage this round.\n");
	} else {
		Console.Write("The cannon is expected to deal ");
		Console.ForegroundColor = ConsoleColor.Gray;
		dmg = 1;
		Console.Write(dmg);
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write(" damage this round.\n");
	}
	return dmg;
}