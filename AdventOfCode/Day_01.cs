namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly IEnumerable<string> _input;

    public Day_01()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var totalMax = 0;
        var lastMax = int.MaxValue;

        foreach(var value in _input.Select(x => int.Parse(x)))
        {
            if(value > lastMax)
            {
                totalMax++;
            }
            
            lastMax = value;            
        }

        return ValueTask.FromResult(totalMax.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var totalMax = 0;
        var lastMax = int.MaxValue;

        var inputs = _input.Select(x => int.Parse(x)).ToList();
        var i1 = inputs[0];
        var i2 = inputs[1];

        foreach(var i in inputs.Skip(2))
        {
            var sum = i + i1+i2;

            if(sum > lastMax)
            {
                totalMax++;
            }

            lastMax = sum;

            i1=i2;
            i2=i;
        }        

        return ValueTask.FromResult(totalMax.ToString());
    }
}
