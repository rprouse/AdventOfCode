namespace AdventOfCode2024;

public class Calibration
{
    public ulong Value { get; set; }
    public ulong[] Inputs { get; set; }

    public Calibration(string line)
    {
        var parts = line.Split(':', StringSplitOptions.TrimEntries);
        Value = parts[0].ToUlong();
        Inputs = parts[1].Split(' ', StringSplitOptions.TrimEntries).Select(p => p.ToUlong()).ToArray();
    }

    public bool ValidWithAdditionAndMultiplication()
    {
        ulong result = Inputs[0];
        int nextInput = 1;

        // Recursion for the win
        return ValidWithAdditionAndMultiplication(result, nextInput);
    }

    private bool ValidWithAdditionAndMultiplication(ulong result, int nextInput)
    {
        // Short circuit if the result is already greater than the value
        if (result > Value)
            return false;

        // If we've reached the end of the inputs, check if the result is the value
        if (nextInput >= Inputs.Length)
            return result == Value;

        // Try addition
        ulong addition = result + Inputs[nextInput];
        if (ValidWithAdditionAndMultiplication(addition, nextInput + 1))
            return true;

        // Try multiplication
        ulong multiplication = result * Inputs[nextInput];
        if (ValidWithAdditionAndMultiplication(multiplication, nextInput + 1))
            return true;

        return false;
    }

    public bool ValidWithAdditionMultiplicationAndConcatination()
    {
        ulong result = Inputs[0];
        int nextInput = 1;

        // Recursion for the win
        return ValidWithAdditionMultiplicationAndConcatination(result, nextInput);
    }

    private bool ValidWithAdditionMultiplicationAndConcatination(ulong result, int nextInput)
    {
        // Short circuit if the result is already greater than the value
        if (result > Value)
            return false;

        // If we've reached the end of the inputs, check if the result is the value
        if (nextInput >= Inputs.Length)
            return result == Value;

        // Try concatination
        ulong concatination = ulong.Parse(result.ToString() + Inputs[nextInput].ToString());
        if (ValidWithAdditionMultiplicationAndConcatination(concatination, nextInput + 1))
            return true;

        // Try addition
        ulong addition = result + Inputs[nextInput];
        if (ValidWithAdditionMultiplicationAndConcatination(addition, nextInput + 1))
            return true;

        // Try multiplication
        ulong multiplication = result * Inputs[nextInput];
        if (ValidWithAdditionMultiplicationAndConcatination(multiplication, nextInput + 1))
            return true;

        return false;
    }
}
