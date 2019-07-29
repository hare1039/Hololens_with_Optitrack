using System;
using MathNet.Numerics;


namespace MathNet.Examples {

  public class NumberTheoryExamples : MathNetExampleBase {

    /// <summary>
    /// Executes the example.
    /// </summary>
    public override void ExecuteExample() {
      // 1. Find out whether the provided number is an even number
      MathDisplay.WriteLine(@"1. Find out whether the provided number is an even number");
      MathDisplay.WriteLine(@"{0} is even = {1}. {2} is even = {3}", 1, Euclid.IsEven(1), 2, 2.IsEven());
      MathDisplay.WriteLine();

      // 2. Find out whether the provided number is an odd number
      MathDisplay.WriteLine(@"2. Find out whether the provided number is an odd number");
      MathDisplay.WriteLine(@"{0} is odd = {1}. {2} is odd = {3}", 1, 1.IsOdd(), 2, Euclid.IsOdd(2));
      MathDisplay.WriteLine();

      // 3. Find out whether the provided number is a perfect power of two
      MathDisplay.WriteLine(@"2. Find out whether the provided number is a perfect power of two");
      MathDisplay.WriteLine(
        @"{0} is power of two = {1}. {2} is power of two = {3}",
        5,
        5.IsPowerOfTwo(),
        16,
        Euclid.IsPowerOfTwo(16));
      MathDisplay.WriteLine();

      // 4. Find the closest perfect power of two that is larger or equal to 97
      MathDisplay.WriteLine(@"4. Find the closest perfect power of two that is larger or equal to 97");
      MathDisplay.WriteLine(97.CeilingToPowerOfTwo().ToString());
      MathDisplay.WriteLine();

      // 5. Raise 2 to the 16
      MathDisplay.WriteLine(@"5. Raise 2 to the 16");
      MathDisplay.WriteLine(16.PowerOfTwo().ToString());
      MathDisplay.WriteLine();

      // 6. Find out whether the number is a perfect square
      MathDisplay.WriteLine(@"6. Find out whether the number is a perfect square");
      MathDisplay.WriteLine(
        @"{0} is perfect square = {1}. {2} is perfect square = {3}",
        37,
        37.IsPerfectSquare(),
        81,
        Euclid.IsPerfectSquare(81));
      MathDisplay.WriteLine();

      // 7. Compute the greatest common divisor of 32 and 36 
      MathDisplay.WriteLine(@"7. Returns the greatest common divisor of 32 and 36");
      MathDisplay.WriteLine(Euclid.GreatestCommonDivisor(32, 36).ToString());
      MathDisplay.WriteLine();

      // 8. Compute the greatest common divisor of 492, -984, 123, 246
      MathDisplay.WriteLine(@"8. Returns the greatest common divisor of 492, -984, 123, 246");
      MathDisplay.WriteLine(Euclid.GreatestCommonDivisor(492, -984, 123, 246).ToString());
      MathDisplay.WriteLine();

      // 9. Compute the extended greatest common divisor "z", such that 45*x + 18*y = z
      MathDisplay.WriteLine(@"9. Compute the extended greatest common divisor Z, such that 45*x + 18*y = Z");
      long x, y;
      var z = Euclid.ExtendedGreatestCommonDivisor(45, 18, out x, out y);
      MathDisplay.WriteLine(@"z = {0}, x = {1}, y = {2}. 45*{1} + 18*{2} = {0}", z, x, y);
      MathDisplay.WriteLine();

      // 10. Compute the least common multiple of 16 and 12
      MathDisplay.WriteLine(@"10. Compute the least common multiple of 16 and 12");
      MathDisplay.WriteLine(Euclid.LeastCommonMultiple(16, 12).ToString());
      MathDisplay.WriteLine();
    }

  }

}
