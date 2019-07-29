using System;
using MathNet.Numerics;
using MathNet.Numerics.Random;
using MathNet.Numerics.Interpolation;


namespace MathNet.Examples {

  /// <seealso cref="http://reference.wolfram.com/mathematica/ref/Interpolation.html"/>
  public class InterpolationExamples : MathNetExampleBase {

    public override void ExecuteExample() {

      MathDisplay.WriteLine("<b>Linear interpolation between points</b>");

      // 1. Generate 20 samples of the function x*x-2*x on interval [0, 10]
      MathDisplay.WriteLine(@"1. Generate 20 samples of the function x*x-2*x on interval [0, 10]");
      double[] points = Generate.LinearSpaced(20, 0, 10);
      var values = Generate.Map<double,double>(points, TargetFunction1);
      MathDisplay.WriteLine();

      // 2. Create a linear spline interpolation based on arbitrary points 
      var method = Interpolate.Linear(points, values);
      MathDisplay.WriteLine(@"2. Create a linear spline interpolation based on arbitrary points");
      MathDisplay.WriteLine();

      // 3. Check if interpolation support integration
      MathDisplay.WriteLine(@"3. Support integration = {0}", method.SupportsIntegration);
      MathDisplay.WriteLine();

      // 4. Check if interpolation support differentiation
      MathDisplay.WriteLine(@"4. Support differentiation = {0}", method.SupportsDifferentiation);
      MathDisplay.WriteLine();

      // 5. Differentiate at point 5.2
      MathDisplay.WriteLine(@"5. Differentiate at point 5.2 = {0}", method.Differentiate(5.2));
      MathDisplay.WriteLine();

      // 6. Integrate at point 5.2
      MathDisplay.WriteLine(@"6. Integrate at point 5.2 = {0}", method.Integrate(5.2));
      MathDisplay.WriteLine();

      // 7. Interpolate ten random points and compare to function results
      MathDisplay.WriteLine(@"7. Interpolate ten random points and compare to function results");
      var rng = new MersenneTwister(1);
      for(var i = 0; i < 10; i++) {
        // Generate random value from [0, 10]
        var point = rng.NextDouble() * 10;
        MathDisplay.WriteLine(
          @"Interpolate at {0} = {1}. Function({0}) = {2}",
          point.ToString("N05"),
          method.Interpolate(point).ToString("N05"),
          TargetFunction1(point).ToString("N05"));
      }

      MathDisplay.WriteLine();


      // <seealso cref="http://en.wikipedia.org/wiki/Spline_interpolation">Spline interpolation</seealso>
      MathDisplay.WriteLine("<b>Akima spline interpolation</b>");

      // 1. Generate 10 samples of the function x*x-2*x on interval [0, 10]
      MathDisplay.WriteLine(@"1. Generate 10 samples of the function x*x-2*x on interval [0, 10]");
      points = Generate.LinearSpaced(10, 0, 10);
      values = Generate.Map<double,double>(points, TargetFunction1);
      MathDisplay.WriteLine();

      // 2. Create akima spline interpolation 
      method = CubicSpline.InterpolateAkima(points, values);
      MathDisplay.WriteLine(@"2. Create akima spline interpolation based on arbitrary points");
      MathDisplay.WriteLine();

      // 3. Check if interpolation supports integration
      MathDisplay.WriteLine(@"3. Support integration = {0}", ((IInterpolation)method).SupportsIntegration);
      MathDisplay.WriteLine();

      // 4. Check if interpolation support differentiation
      MathDisplay.WriteLine(@"4. Support differentiation = {0}", ((IInterpolation)method).SupportsDifferentiation);
      MathDisplay.WriteLine();

      // 5. Differentiate at point 5.2
      MathDisplay.WriteLine(@"5. Differentiate at point 5.2 = {0}", method.Differentiate(5.2));
      MathDisplay.WriteLine();

      // 6. Integrate at point 5.2
      MathDisplay.WriteLine(@"6. Integrate at point 5.2 = {0}", method.Integrate(5.2));
      MathDisplay.WriteLine();

      // 7. Interpolate ten random points and compare to function results
      MathDisplay.WriteLine(@"7. Interpolate ten random points and compare to function results");
      rng = new MersenneTwister(1);
      for(var i = 0; i < 10; i++) {
        // Generate random value from [0, 10]
        var point = rng.NextDouble() * 10;
        MathDisplay.WriteLine(
          @"Interpolate at {0} = {1}. Function({0}) = {2}",
          point.ToString("N05"),
          method.Interpolate(point).ToString("N05"),
          TargetFunction1(point).ToString("N05"));
      }

      MathDisplay.WriteLine();


      MathDisplay.WriteLine("<b>Barycentric rational interpolation without poles</b>");

      // 1. Generate 10 samples of the function 1/(1+x*x) on interval [-5, 5]
      MathDisplay.WriteLine(@"1. Generate 10 samples of the function 1/(1+x*x) on interval [-5, 5]");
      points = Generate.LinearSpaced(10, -5, 5);
      values = Generate.Map<double,double>(points, TargetFunctionWithoutPolesEx);
      MathDisplay.WriteLine();

      // 2. Create a floater hormann rational pole-free interpolation based on arbitrary points
      // This method is used by default when create an interpolation using Interpolate.Common method
      method = Interpolate.RationalWithoutPoles(points, values);
      MathDisplay.WriteLine(@"2. Create a floater hormann rational pole-free interpolation based on arbitrary points");
      MathDisplay.WriteLine();

      // 3. Check if interpolation support integration
      MathDisplay.WriteLine(@"3. Support integration = {0}", method.SupportsIntegration);
      MathDisplay.WriteLine();

      // 4. Check if interpolation support differentiation
      MathDisplay.WriteLine(@"4. Support differentiation = {0}", method.SupportsDifferentiation);
      MathDisplay.WriteLine();

      // 5. Interpolate ten random points and compare to function results
      MathDisplay.WriteLine(@"5. Interpolate ten random points and compare to function results");
      rng = new MersenneTwister(1);
      for(var i = 0; i < 10; i++) {
        // Generate random value from [0, 5]
        var point = rng.NextDouble() * 5;
        MathDisplay.WriteLine(
          @"Interpolate at {0} = {1}. Function({0}) = {2}",
          point.ToString("N05"),
          method.Interpolate(point).ToString("N05"),
          TargetFunctionWithoutPolesEx(point).ToString("N05"));
      }

      MathDisplay.WriteLine();


      MathDisplay.WriteLine("<b>Rational interpolation with poles</b>");

      // 1. Generate 20 samples of the function f(x) = x on interval [-5, 5]
      MathDisplay.WriteLine(@"1. Generate 20 samples of the function f(x) = x on interval [-5, 5]");
      points = Generate.LinearSpaced(20, -5, 5);
      values = Generate.Map<double,double>(points, TargetFunctionWithPolesEx);
      MathDisplay.WriteLine();

      // 2. Create a burlish stoer rational interpolation based on arbitrary points 
      method = Interpolate.RationalWithPoles(points, values);
      MathDisplay.WriteLine(@"2. Create a burlish stoer rational interpolation based on arbitrary points");
      MathDisplay.WriteLine();

      // 3. Check if interpolation support integration
      MathDisplay.WriteLine(@"3. Support integration = {0}", method.SupportsIntegration);
      MathDisplay.WriteLine();

      // 4. Check if interpolation support differentiation
      MathDisplay.WriteLine(@"4. Support differentiation = {0}", method.SupportsDifferentiation);
      MathDisplay.WriteLine();

      // 5. Interpolate ten random points and compare to function results
      MathDisplay.WriteLine(@"5. Interpolate ten random points and compare to function results");
      rng = new MersenneTwister(1);
      for(var i = 0; i < 10; i++) {
        // Generate random value from [0, 5]
        var point = rng.Next(0, 5);
        MathDisplay.WriteLine(
          @"Interpolate at {0} = {1}. Function({0}) = {2}",
          point.ToString("N05"),
          method.Interpolate(point).ToString("N05"),
          TargetFunctionWithPolesEx(point).ToString("N05"));
      }

      MathDisplay.WriteLine();

    }

    /// <summary>
    /// Test Function: f(x) = x * x - 2 * x
    /// </summary>
    /// <param name="x">X parameter value</param>
    /// <returns>Calculation result</returns>
    public static double TargetFunction1(double x) {
      return (x * x) - (2 * x);
    }

    /// <summary>
    /// Test Function: f(x) = 1 / (1 + (x * x))
    /// </summary>
    /// <param name="x">X parameter value</param>
    /// <returns>Calculation result</returns>
    public static double TargetFunctionWithoutPolesEx(double x) {
      return 1 / (1 + (x * x));
    }

    /// <summary>
    /// Test Function: f(x) = x * x + 10
    /// </summary>
    /// <param name="x">X parameter value</param>
    /// <returns>Calculation result</returns>
    public static double TargetFunctionWithPolesEx(double x) {
      return x;
    }

  }

}
