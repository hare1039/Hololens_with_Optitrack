using System;
using MathNet.Numerics;


namespace MathNet.Examples {

  public class SpecialFunctionsExamples : MathNetExampleBase {

    /// <summary>
    /// Executes the example.
    /// </summary>
    public override void ExecuteExample() {
     
      // <seealso cref="http://en.wikipedia.org/wiki/Beta_function">Beta function</seealso>
      MathDisplay.WriteLine("<b>Beta fuction</b>");

      // 1. Compute the Beta function at z = 1.0, w = 3.0
      MathDisplay.WriteLine(@"1. Compute the Beta function at z = 1.0, w = 3.0");
      MathDisplay.WriteLine(SpecialFunctions.Beta(1.0, 3.0).ToString());
      MathDisplay.WriteLine();

      // 2. Compute the logarithm of the Beta function at z = 1.0, w = 3.0
      MathDisplay.WriteLine(@"2. Compute the logarithm of the Beta function at z = 1.0, w = 3.0");
      MathDisplay.WriteLine(SpecialFunctions.BetaLn(1.0, 3.0).ToString());
      MathDisplay.WriteLine();

      // 3. Compute the Beta incomplete function at z = 1.0, w = 3.0, x = 0.7 
      MathDisplay.WriteLine(@"3. Compute the Beta incomplete function at z = 1.0, w = 3.0, x = 0.7");
      MathDisplay.WriteLine(SpecialFunctions.BetaIncomplete(1.0, 3.0, 0.7).ToString());
      MathDisplay.WriteLine();

      // 4. Compute the Beta incomplete function at z = 1.0, w = 3.0, x = 1.0 
      MathDisplay.WriteLine(@"4. Compute the Beta incomplete function at z = 1.0, w = 3.0, x = 1.0");
      MathDisplay.WriteLine(SpecialFunctions.BetaIncomplete(1.0, 3.0, 1.0).ToString());
      MathDisplay.WriteLine();

      // 5. Compute the Beta regularized function at z = 1.0, w = 3.0, x = 0.7
      MathDisplay.WriteLine(@"5. Compute the Beta regularized function at z = 1.0, w = 3.0, x = 0.7");
      MathDisplay.WriteLine(SpecialFunctions.BetaRegularized(1.0, 3.0, 0.7).ToString());
      MathDisplay.WriteLine();

      // 6. Compute the Beta regularized  function at z = 1.0, w = 3.0, x = 1.0 
      MathDisplay.WriteLine(@"6. Compute the Beta regularized function at z = 1.0, w = 3.0, x = 1.0");
      MathDisplay.WriteLine(SpecialFunctions.BetaRegularized(1.0, 3.0, 1.0).ToString());
      MathDisplay.WriteLine();



      MathDisplay.WriteLine("<b>Common functions</b>");

      // 1. Calculate the Digamma function at point 5.0
      // <seealso cref="http://en.wikipedia.org/wiki/Digamma_function">Digamma function</seealso>
      MathDisplay.WriteLine(@"1. Calculate the Digamma function at point 5.0");
      MathDisplay.WriteLine(SpecialFunctions.DiGamma(5.0).ToString());
      MathDisplay.WriteLine();

      // 2. Calculate the inverse Digamma function at point 1.5
      MathDisplay.WriteLine(@"2. Calculate the inverse Digamma function at point 1.5");
      MathDisplay.WriteLine(SpecialFunctions.DiGammaInv(1.5).ToString());
      MathDisplay.WriteLine();

      // 3. Calculate the 10'th Harmonic number
      // <seealso cref="http://en.wikipedia.org/wiki/Harmonic_number">Harmonic number</seealso>
      MathDisplay.WriteLine(@"3. Calculate the 10'th Harmonic number");
      MathDisplay.WriteLine(SpecialFunctions.Harmonic(10).ToString());
      MathDisplay.WriteLine();

      // 4. Calculate the generalized harmonic number of order 10 of 3.0.
      // <seealso cref="http://en.wikipedia.org/wiki/Harmonic_number#Generalized_harmonic_numbers">Generalized harmonic numbers</seealso>
      MathDisplay.WriteLine(@"4. Calculate the generalized harmonic number of order 10 of 3.0");
      MathDisplay.WriteLine(SpecialFunctions.GeneralHarmonic(10, 3.0).ToString());
      MathDisplay.WriteLine();

      // 5. Calculate the logistic function of 3.0
      // <seealso cref="http://en.wikipedia.org/wiki/Logistic_function">Logistic function</seealso>
      MathDisplay.WriteLine(@"5. Calculate the logistic function of 3.0");
      MathDisplay.WriteLine(SpecialFunctions.Logistic(3.0).ToString());
      MathDisplay.WriteLine();

      // 6. Calculate the logit function of 0.3
      // <seealso cref="http://en.wikipedia.org/wiki/Logit">Logit function</seealso>
      MathDisplay.WriteLine(@"6. Calculate the logit function of 0.3");
      MathDisplay.WriteLine(SpecialFunctions.Logit(0.3).ToString());
      MathDisplay.WriteLine();

      // <seealso cref="http://en.wikipedia.org/wiki/Error_function">Error function</seealso>
      MathDisplay.WriteLine("<b>Error function</b>");

      // 1. Calculate the error function at point 2
      MathDisplay.WriteLine(@"1. Calculate the error function at point 2");
      MathDisplay.WriteLine(SpecialFunctions.Erf(2).ToString());
      MathDisplay.WriteLine();

      // 2. Sample 10 values of the error function in [-1.0; 1.0]
      MathDisplay.WriteLine(@"2. Sample 10 values of the error function in [-1.0; 1.0]");
      var data = Generate.LinearSpacedMap<double>(10, -1.0, 1.0, SpecialFunctions.Erf);
      for (var i = 0; i < data.Length; i++)
      {
        MathDisplay.Write(data[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 3. Calculate the complementary error function at point 2
      MathDisplay.WriteLine(@"3. Calculate the complementary error function at point 2");
      MathDisplay.WriteLine(SpecialFunctions.Erfc(2).ToString());
      MathDisplay.WriteLine();

      // 4. Sample 10 values of the complementary error function in [-1.0; 1.0]
      MathDisplay.WriteLine(@"4. Sample 10 values of the complementary error function in [-1.0; 1.0]");
      data = Generate.LinearSpacedMap<double>(10, -1.0, 1.0, SpecialFunctions.Erfc);
      for (var i = 0; i < data.Length; i++)
      {
        MathDisplay.Write(data[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 5. Calculate the inverse error function at point z=0.5
      MathDisplay.WriteLine(@"5. Calculate the inverse error function at point z=0.5");
      MathDisplay.WriteLine(SpecialFunctions.ErfInv(0.5).ToString());
      MathDisplay.WriteLine();

      // 6. Sample 10 values of the inverse error function in [-1.0; 1.0]
      MathDisplay.WriteLine(@"6. Sample 10 values of the inverse error function in [-1.0; 1.0]");
      data = Generate.LinearSpacedMap<double>(10, -1.0, 1.0, SpecialFunctions.ErfInv);
      for (var i = 0; i < data.Length; i++)
      {
        MathDisplay.Write(data[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 7. Calculate the complementary inverse error function at point z=0.5
      MathDisplay.WriteLine(@"7. Calculate the complementary inverse error function at point z=0.5");
      MathDisplay.WriteLine(SpecialFunctions.ErfcInv(0.5).ToString());
      MathDisplay.WriteLine();

      // 8. Sample 10 values of the complementary inverse error function in [-1.0; 1.0]
      MathDisplay.WriteLine(@"8. Sample 10 values of the complementary inverse error function in [-1.0; 1.0]");
      data = Generate.LinearSpacedMap<double>(10, -1.0, 1.0, SpecialFunctions.ErfcInv);
      for (var i = 0; i < data.Length; i++)
      {
        MathDisplay.Write(data[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();


      // <seealso cref="http://en.wikipedia.org/wiki/Factorial">Factorial</seealso>
      MathDisplay.WriteLine("<b>Factorial</b>");

      // 1. Compute the factorial of 5
      MathDisplay.WriteLine(@"1. Compute the factorial of 5");
      MathDisplay.WriteLine(SpecialFunctions.Factorial(5).ToString("N"));
      MathDisplay.WriteLine();

      // 2. Compute the logarithm of the factorial of 5
      MathDisplay.WriteLine(@"2. Compute the logarithm of the factorial of 5");
      MathDisplay.WriteLine(SpecialFunctions.FactorialLn(5).ToString("N"));
      MathDisplay.WriteLine();


      // <seealso cref="http://en.wikipedia.org/wiki/Binomial_coefficient">Binomial coefficient</seealso>
      MathDisplay.WriteLine("<b>Binomial coefficient</b>");

      // 3. Compute the binomial coefficient: 10 choose 8
      MathDisplay.WriteLine(@"3. Compute the binomial coefficient: 10 choose 8");
      MathDisplay.WriteLine(SpecialFunctions.Binomial(10, 8).ToString("N"));
      MathDisplay.WriteLine();

      // 4. Compute the logarithm of the binomial coefficient: 10 choose 8
      MathDisplay.WriteLine(@"4. Compute the logarithm of the binomial coefficient: 10 choose 8");
      MathDisplay.WriteLine(SpecialFunctions.BinomialLn(10, 8).ToString("N"));
      MathDisplay.WriteLine();

      // <seealso cref="http://en.wikipedia.org/wiki/Multinomial_theorem#Multinomial_coefficients">Multinomial coefficients</seealso>
      MathDisplay.WriteLine("<b>Multinomial coefficient</b>");

      // 5. Compute the multinomial coefficient: 10 choose 2, 3, 5 
      MathDisplay.WriteLine(@"5. Compute the multinomial coefficient: 10 choose 2, 3, 5");
      MathDisplay.WriteLine(SpecialFunctions.Multinomial(10, new[] { 2, 3, 5 }).ToString("N"));
      MathDisplay.WriteLine();


      // <seealso cref="http://en.wikipedia.org/wiki/Gamma_function">Gamma function</seealso>
      MathDisplay.WriteLine("<b>Gamma function</b>");

      // 1. Compute the Gamma function of 10
      MathDisplay.WriteLine(@"1. Compute the Gamma function of 10");
      MathDisplay.WriteLine(SpecialFunctions.Gamma(10).ToString("N"));
      MathDisplay.WriteLine();

      // 2. Compute the logarithm of the Gamma function of 10
      MathDisplay.WriteLine(@"2. Compute the logarithm of the Gamma function of 10");
      MathDisplay.WriteLine(SpecialFunctions.GammaLn(10).ToString("N"));
      MathDisplay.WriteLine();

      // 3. Compute the lower incomplete gamma(a, x) function at a = 10, x = 14 
      MathDisplay.WriteLine(@"3. Compute the lower incomplete gamma(a, x) function at a = 10, x = 14");
      MathDisplay.WriteLine(SpecialFunctions.GammaLowerIncomplete(10, 14).ToString("N"));
      MathDisplay.WriteLine();

      // 4. Compute the lower incomplete gamma(a, x) function at a = 10, x = 100 
      MathDisplay.WriteLine(@"4. Compute the lower incomplete gamma(a, x) function at a = 10, x = 100");
      MathDisplay.WriteLine(SpecialFunctions.GammaLowerIncomplete(10, 100).ToString("N"));
      MathDisplay.WriteLine();

      // 5. Compute the upper incomplete gamma(a, x) function at a = 10, x = 0 
      MathDisplay.WriteLine(@"5. Compute the upper incomplete gamma(a, x) function at a = 10, x = 0");
      MathDisplay.WriteLine(SpecialFunctions.GammaUpperIncomplete(10, 0).ToString("N"));
      MathDisplay.WriteLine();

      // 6. Compute the upper incomplete gamma(a, x) function at a = 10, x = 10 
      MathDisplay.WriteLine(@"6. Compute the upper incomplete gamma(a, x) function at a = 10, x = 100");
      MathDisplay.WriteLine(SpecialFunctions.GammaLowerIncomplete(10, 10).ToString("N"));
      MathDisplay.WriteLine();

      // 7. Compute the lower regularized gamma(a, x) function at a = 10, x = 14 
      MathDisplay.WriteLine(@"7. Compute the lower regularized gamma(a, x) function at a = 10, x = 14");
      MathDisplay.WriteLine(SpecialFunctions.GammaLowerRegularized(10, 14).ToString("N"));
      MathDisplay.WriteLine();

      // 8. Compute the lower regularized gamma(a, x) function at a = 10, x = 100 
      MathDisplay.WriteLine(@"8. Compute the lower regularized gamma(a, x) function at a = 10, x = 100");
      MathDisplay.WriteLine(SpecialFunctions.GammaLowerRegularized(10, 100).ToString("N"));
      MathDisplay.WriteLine();

      // 9. Compute the upper regularized gamma(a, x) function at a = 10, x = 0 
      MathDisplay.WriteLine(@"9. Compute the upper regularized gamma(a, x) function at a = 10, x = 0");
      MathDisplay.WriteLine(SpecialFunctions.GammaUpperRegularized(10, 0).ToString("N"));
      MathDisplay.WriteLine();

      // 10. Compute the upper regularized gamma(a, x) function at a = 10, x = 10 
      MathDisplay.WriteLine(@"10. Compute the upper regularized gamma(a, x) function at a = 10, x = 100");
      MathDisplay.WriteLine(SpecialFunctions.GammaUpperRegularized(10, 10).ToString("N"));
      MathDisplay.WriteLine();

      MathDisplay.WriteLine("<b>Numerical stability</b>");

      // 1. Compute numerically stable exponential of 10 minus one 
      MathDisplay.WriteLine(@"1. Compute numerically stable exponential of 4.2876 minus one");
      MathDisplay.WriteLine(SpecialFunctions.ExponentialMinusOne(4.2876).ToString());
      MathDisplay.WriteLine();

      // 2. Compute regular System.Math exponential of 15.28 minus one 
      MathDisplay.WriteLine(@"2. Compute regular System.Math exponential of 4.2876 minus one ");
      MathDisplay.WriteLine((Math.Exp(4.2876) - 1).ToString());
      MathDisplay.WriteLine();

      // 3. Compute numerically stable hypotenuse of a right angle triangle with a = 5, b = 3
      MathDisplay.WriteLine(@"3. Compute numerically stable hypotenuse of a right angle triangle with a = 5, b = 3");
      MathDisplay.WriteLine(SpecialFunctions.Hypotenuse(5, 3).ToString());
      MathDisplay.WriteLine();

    }

  }

}
