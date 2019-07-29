using System;
using MathNet.Numerics;


namespace MathNet.Examples {

  public class IntegrationExamples : MathNetExampleBase {

    /// <summary>
    /// Executes the example.
    /// </summary>
    /// <seealso cref="http://reference.wolfram.com/mathematica/ref/Integrate.html"/>
    /// <seealso cref="http://en.wikipedia.org/wiki/Trapezoidal_rule">Trapezoidal rule</seealso>
    public override void ExecuteExample() {
      // 1. Integrate x*x on interval [0, 10]
      Console.WriteLine(@"1. Integrate x*x on interval [0, 10]");
      var result = Integrate.OnClosedInterval(x => x * x, 0, 10);
      Console.WriteLine(result);
      Console.WriteLine();

      // 2. Integrate 1/(x^3 + 1) on interval [0, 1]
      Console.WriteLine(@"2. Integrate 1/(x^3 + 1) on interval [0, 1]");
      result = Integrate.OnClosedInterval(x => 1 / (Math.Pow(x, 3) + 1), 0, 1);
      Console.WriteLine(result);
      Console.WriteLine();

      // 3. Integrate f(x) = exp(-x/5) (2 + sin(2 * x)) on [0, 10]
      Console.WriteLine(@"3. Integrate f(x) = exp(-x/5) (2 + sin(2 * x)) on [0, 10]");
      result = Integrate.OnClosedInterval(x => Math.Exp(-x / 5) * (2 + Math.Sin(2 * x)), 0, 100);
      Console.WriteLine(result);
      Console.WriteLine();

      // 4. Integrate target function with absolute error = 1E-4
      Console.WriteLine(@"4. Integrate target function with absolute error = 1E-4 on [0, 10]");
      Console.WriteLine(@"public static double TargetFunctionA(double x) {
  return Math.Exp(-x / 5) * (2 + Math.Sin(2 * x));
}");
      result = Integrate.OnClosedInterval(TargetFunctionA, 0, 100, 1e-4);
      Console.WriteLine(result);
      Console.WriteLine();
    }

    /// <summary>
    /// Test Function: f(x) = exp(-x/5) (2 + sin(2 * x))
    /// </summary>
    /// <param name="x">X parameter value</param>
    /// <returns>Calculation result</returns>
    public double TargetFunctionA(double x) {
      return Math.Exp(-x / 5) * (2 + Math.Sin(2 * x));
    }

  }

}
