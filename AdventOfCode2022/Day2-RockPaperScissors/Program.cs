using static Day2_RockPaperScissors.GlobalConstants;

var allGames = File.ReadAllLines("input.txt");


var rockPaperScissorsMap = new Dictionary<string, string>();
var rockPaperScissorsScoreMap = new Dictionary<string, int>();

void BuildRockPaperScissorsDictPartOne()
{
    rockPaperScissorsMap = new Dictionary<string, string>();
    rockPaperScissorsMap.Add(OPPONENT_ROCK, ROCK);
    rockPaperScissorsMap.Add(OPPONENT_PAPER, PAPER);
    rockPaperScissorsMap.Add(OPPONENT_SCISSORS, SCISSORS);
    rockPaperScissorsMap.Add(PLAYER_PLAY_X, ROCK);
    rockPaperScissorsMap.Add(PLAYER_PLAY_Y, PAPER);
    rockPaperScissorsMap.Add(PLAYER_PLAY_Z, SCISSORS);
}

void BuildRockPaperScissorsDictPartTwo()
{
    rockPaperScissorsMap = new Dictionary<string, string>();
    rockPaperScissorsMap.Add(OPPONENT_ROCK, ROCK);
    rockPaperScissorsMap.Add(OPPONENT_PAPER, PAPER);
    rockPaperScissorsMap.Add(OPPONENT_SCISSORS, SCISSORS);
    rockPaperScissorsMap.Add(PLAYER_PLAY_X, LOSS);
    rockPaperScissorsMap.Add(PLAYER_PLAY_Y, DRAW);
    rockPaperScissorsMap.Add(PLAYER_PLAY_Z, WIN);
}

void BuildRockPaperScissorsScoreDict()
{
    rockPaperScissorsScoreMap.Add(ROCK, 1);
    rockPaperScissorsScoreMap.Add(PAPER, 2);
    rockPaperScissorsScoreMap.Add(SCISSORS, 3);
    rockPaperScissorsScoreMap.Add(WIN, 6);
    rockPaperScissorsScoreMap.Add(LOSS, 0);
    rockPaperScissorsScoreMap.Add(DRAW, 3);
}

int GetTotalScoreForAllGamesPartOne()
{
    int score = 0;
    foreach(var game in allGames)
    {
        var plays = game.Split(" ");
        var opponentPlay = rockPaperScissorsMap[plays[0]];
        var playerPlay = rockPaperScissorsMap[plays[1]];

        score += GetScoreForGame(opponentPlay, playerPlay);
    }

    return score;
}

int GetTotalScoreForAllGamesPartTwo()
{
    int score = 0;
    foreach(var game in allGames)
    {
        var plays = game.Split(" ");
        var opponentPlay = rockPaperScissorsMap[plays[0]];
        var playerAction = rockPaperScissorsMap[plays[1]];

        var playerPlay = GetPlayerPlay(opponentPlay, playerAction);

        score += GetScoreForGame(opponentPlay, playerPlay);
    }
    return score;
}

string GetPlayerPlay(string opponentPlay, string action)
{
    if(action == DRAW)
    {
        return opponentPlay;
    }

    if(opponentPlay == ROCK && action == WIN)
    {
        return PAPER;
    }
    
    if(opponentPlay == ROCK && action == LOSS)
    {
        return SCISSORS;
    }

    if(opponentPlay == SCISSORS && action == WIN)
    {
        return ROCK;
    }

    if (opponentPlay == SCISSORS && action == LOSS)
    {
        return PAPER;
    }

    if (opponentPlay == PAPER && action == WIN)
    {
        return SCISSORS;
    }

    if (opponentPlay == PAPER && action == LOSS)
    {
        return ROCK;
    }

    return "";
}

int GetScoreForGame(string opponentPlay, string playerPlay)
{
    int score = 0;

    score += rockPaperScissorsScoreMap[playerPlay];

    if (opponentPlay == playerPlay)
    {
        score += rockPaperScissorsScoreMap[DRAW];
    }
    else if(playerPlay == ROCK && opponentPlay == SCISSORS)
    {
        score += rockPaperScissorsScoreMap[WIN];
    }
    else if(playerPlay == PAPER && opponentPlay == ROCK)
    {
        score += rockPaperScissorsScoreMap[WIN];
    }
    else if(playerPlay == SCISSORS && opponentPlay == PAPER)
    {
        score += rockPaperScissorsScoreMap[WIN];
    }
    else
    {
        score += rockPaperScissorsScoreMap[LOSS];
    }

    return score;
}

BuildRockPaperScissorsDictPartOne();
BuildRockPaperScissorsScoreDict();
int totalScore = GetTotalScoreForAllGamesPartOne();
Console.WriteLine(totalScore);

BuildRockPaperScissorsDictPartTwo();

totalScore = GetTotalScoreForAllGamesPartTwo();
Console.WriteLine(totalScore);