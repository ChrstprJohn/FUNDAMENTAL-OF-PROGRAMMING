using System.Globalization;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models.Arrays;

public static class PICARDOCHRISTOPHERJOHN_24_1635_NumberInput
{
    public static bool TryRead(string? input, int count, out int[] numbers)
    {
        numbers = new int[count];
        if (string.IsNullOrWhiteSpace(input) || input.Length > 100)
            return false;

        string[] parts = input.Split(',', StringSplitOptions.TrimEntries);
        if (parts.Length != count)
            return false;

        for (int index = 0; index < count; index++)
        {
            if (!int.TryParse(parts[index], NumberStyles.Integer,
                    CultureInfo.InvariantCulture, out numbers[index])
                || numbers[index] < -1000 || numbers[index] > 1000)
                return false;
        }

        return true;
    }
}
