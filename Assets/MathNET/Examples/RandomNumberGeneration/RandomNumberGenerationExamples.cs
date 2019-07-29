using System;
using MathNet.Numerics.Random;


namespace MathNet.Examples {

  public class RandomNumberGenerationExamples : MathNetExampleBase {

    /// <summary>
    /// Executes the example.
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Random_number_generation">Random number generation</seealso>
    /// <seealso cref="http://en.wikipedia.org/wiki/Linear_congruential_generator">Linear congruential generator</seealso>
    /// <seealso cref="http://en.wikipedia.org/wiki/Mersenne_twister">Mersenne twister</seealso>
    /// <seealso cref="http://en.wikipedia.org/wiki/Lagged_Fibonacci_generator">Lagged Fibonacci generator</seealso>
    /// <seealso cref="http://en.wikipedia.org/wiki/Xorshift">Xorshift</seealso>
    public override void ExecuteExample() {
      // All RNG classes in MathNet have the following counstructors:
      // - RNG(int seed, bool threadSafe): initializes a new instance using a specific seed value and thread 
      //   safe property
      // - RNG(int seed): initializes a new instance using a specific seed value. Thread safe property is set 
      //   to Control.ThreadSafeRandomNumberGenerators
      // - RNG(bool threadSafe) : initializes a new instance with the seed value set to DateTime.Now.Ticks and 
      //   specific thread safe property
      // - RNG(bool threadSafe) : initializes a new instance with the seed value set to DateTime.Now.Ticks and 
      //   thread safe property set to Control.ThreadSafeRandomNumberGenerators

      // All RNG classes in MathNet have next methods to produce random values:
      // - double[] NextDouble(int n): returns an "n"-size array of uniformly distributed random doubles in 
      //   the interval [0.0,1.0];
      // - int Next(): returns a nonnegative random number;
      // - int Next(int maxValue): returns a random number less then a specified maximum;
      // - int Next(int minValue, int maxValue): returns a random number within a specified range;
      // - void NextBytes(byte[] buffer): fills the elements of a specified array of bytes with random numbers;

      // All RNG classes in MathNet have next extension methods to produce random values:
      // - long NextInt64(): returns a nonnegative random number less than "Int64.MaxValue";
      // - int NextFullRangeInt32(): returns a random number of the full Int32 range;
      // - long NextFullRangeInt64(): returns a random number of the full Int64 range;
      // - decimal NextDecimal(): returns a nonnegative decimal floating point random number less than 1.0;

      // 1. Multiplicative congruential generator using a modulus of 2^31-1 and a multiplier of 1132489760
      var mcg31M1 = new Mcg31m1(1);
      MathDisplay.WriteLine(@"1. Generate 10 random double values using Multiplicative congruential generator with a 
      modulus of 2^31-1 and a multiplier of 1132489760");
      var randomValues = mcg31M1.NextDoubles(10);
      for(var i = 0; i < randomValues.Length; i++) {
        MathDisplay.Write(randomValues[i].ToString("N") + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 2. Multiplicative congruential generator using a modulus of 2^59 and a multiplier of 13^13
      var mcg59 = new Mcg59(1);
      MathDisplay.WriteLine(@"2. Generate 10 random integer values using Multiplicative congruential generator with a 
      modulus of 2^59 and a multiplier of 13^13");
      for(var i = 0; i < 10; i++) {
        MathDisplay.Write(mcg59.Next() + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 3. Random number generator using Mersenne Twister 19937 algorithm
      var mersenneTwister = new MersenneTwister(1);
      MathDisplay.WriteLine(@"3. Generate 10 random integer values less then 100 using Mersenne Twister 19937 algorithm");
      for(var i = 0; i < 10; i++) {
        MathDisplay.Write(mersenneTwister.Next(100) + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 4. Multiple recursive generator with 2 components of order 3
      var mrg32K3A = new Mrg32k3a(1);
      MathDisplay.WriteLine(@"4. Generate 10 random integer values in range [50;100] using multiple recursive generator 
      with 2 components of order 3");
      for(var i = 0; i < 10; i++) {
        MathDisplay.Write(mrg32K3A.Next(50, 100) + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 5. Parallel Additive Lagged Fibonacci pseudo-random number generator
      var palf = new Palf(1);
      MathDisplay.WriteLine(@"5. Generate 10 random bytes using Parallel Additive Lagged Fibonacci pseudo-random number 
      generator");
      var bytes = new byte[10];
      palf.NextBytes(bytes);
      for(var i = 0; i < bytes.Length; i++) {
        MathDisplay.Write(bytes[i] + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 6. A random number generator based on "System.Security.Cryptography.RandomNumberGenerator" class in 
      //    the .NET library
      var systemCrypto = new CryptoRandomSource();
      MathDisplay.WriteLine(@"6. Generate 10 random decimal values using RNG based on 
      'System.Security.Cryptography.RandomNumberGenerator'");
      for(var i = 0; i < 10; i++) {
        MathDisplay.Write(systemCrypto.NextDecimal().ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 7. Wichmann-Hill’s 1982 combined multiplicative congruential generator
      var rngWh1982 = new WH1982();
      MathDisplay.WriteLine(@"7. Generate 10 random full Int32 range values using Wichmann-Hill’s 1982 combined 
      multiplicative congruential generator");
      for(var i = 0; i < 10; i++) {
        MathDisplay.Write(rngWh1982.NextFullRangeInt32() + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 8. Wichmann-Hill’s 2006 combined multiplicative congruential generator.
      var rngWh2006 = new WH2006();
      MathDisplay.WriteLine(@"8. Generate 10 random full Int64 range values using Wichmann-Hill’s 2006 combined 
      multiplicative congruential generator");
      for(var i = 0; i < 10; i++) {
        MathDisplay.Write(rngWh2006.NextFullRangeInt32() + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 9. Multiply-with-carry Xorshift pseudo random number generator
      var xorshift = new Xorshift();
      MathDisplay.WriteLine(@"9. Generate 10 random nonnegative values less than Int64.MaxValue using 
      Multiply-with-carry Xorshift pseudo random number generator");
      for(var i = 0; i < 10; i++) {
        MathDisplay.Write(xorshift.NextInt64() + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
    }

  }

}
