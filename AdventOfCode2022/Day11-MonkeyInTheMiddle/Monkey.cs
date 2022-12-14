namespace Day11_MonkeyInTheMiddle;

public class Monkey
{
    public List<long> items;

    public string operation;

    public string operandValue;

    public int divisibleBy;

    public int throwToMonkeyTrue;
    
    public int throwToMonkeyFalse;
    public Monkey(List<long> items, string operation, int divisibleBy, string operandValue, int throwToMonkeyTrue, int throwToMonkeyFalse)
    {
        this.items = items;
        this.operation = operation;
        this.divisibleBy = divisibleBy;
        this.operandValue = operandValue;
        this.throwToMonkeyTrue = throwToMonkeyTrue;
        this.throwToMonkeyFalse = throwToMonkeyFalse;
    }
}
