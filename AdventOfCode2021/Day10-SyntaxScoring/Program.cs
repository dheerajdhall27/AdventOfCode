using Day10_SyntaxScoring;

var chunks = File.ReadLines("input.txt");


void SolvePartOne()
{
    var syntaxScorer = new SyntaxScorer();

    var score = syntaxScorer.GetScoreForInvalidChunks(chunks.ToList());

    Console.WriteLine(score);
}

void SolvePartTwo()
{
    var syntaxScorer = new SyntaxScorer();

    var score = syntaxScorer.GetScoreForIncompleteChunks(chunks.ToList());

    Console.WriteLine(score);
}


SolvePartOne();
SolvePartTwo();