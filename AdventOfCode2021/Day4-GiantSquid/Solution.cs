

using Day4_GiantSquid;

var fileData = File.ReadAllText("input.txt");

var bingoData = fileData.Split("\r\n\r\n");
var bingoNumbers = bingoData[0].Split(",");

GiantSquidBingo giantSquidBingo = new GiantSquidBingo();

giantSquidBingo.BuildBoards(bingoData);

// Solution to the First Part
giantSquidBingo.RunGame(bingoNumbers); //  First Win

// Solution to the Second Part
giantSquidBingo.RunGame(bingoNumbers, stopAtNthWin: giantSquidBingo.GetNumberOfBoards()); // Last Win