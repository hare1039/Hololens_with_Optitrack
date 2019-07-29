using System;
using MathNet.Numerics;
using MathNet.Numerics.Distributions;


namespace MathNet.Examples {

  public class SignalSamplingExamples : MathNetExampleBase {

    /// <summary>
    /// Examples of generic function sampling and quantization providers
    /// </summary>
    public override void ExecuteExample() {

      MathDisplay.WriteLine("<b>Chebyshev sampling</b>");

      // 1. Get 20 samples of f(x) = (x * x) / 2 at the roots of the Chebyshev polynomial of the first kind within interval [0, 10] 
      var roots = FindRoots.ChebychevPolynomialFirstKind(20, 0, 10);
      var result = Generate.Map<double,double>(roots, Function);
      MathDisplay.WriteLine(@"1. Get 20 samples of f(x) = (x * x) / 2 at the roots of the Chebyshev polynomial of 
      the first kind within interval [0, 10]");
      for(var i = 0; i < result.Length; i++) {
        MathDisplay.Write(result[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 2. Get 20 samples of f(x) = (x * x) / 2 at the roots of the Chebyshev polynomial of the second kind within interval [0, 10]
      roots = FindRoots.ChebychevPolynomialSecondKind(20, 0, 10);
      result = Generate.Map<double,double>(roots, Function);
      MathDisplay.WriteLine(@"2. Get 20 samples of f(x) = (x * x) / 2 at the roots of the Chebyshev polynomial of 
      the second kind within interval [0, 10]");
      for(var i = 0; i < result.Length; i++) {
        MathDisplay.Write(result[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();


      MathDisplay.WriteLine("<b>Equidistant sampling</b>");

      // 1. Get 11 samples of f(x) = (x * x) / 2 equidistant within interval [-5, 5] 
      result = Generate.LinearSpacedMap<double>(11, -5, 5, Function);
      MathDisplay.WriteLine(@"1. Get 11 samples of f(x) = (x * x) / 2 equidistant within interval [-5, 5]");
      for (var i = 0; i < result.Length; i++)
      {
        MathDisplay.Write(result[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 2. Get 10 samples of f(x) = (x * x) / 2 equidistant starting at x=1 with step = 0.5 and retrieve sample points
      double[] samplePoints = Generate.LinearSpaced(10, 1.0, 5.5);
      result = Generate.Map<double,double>(samplePoints, Function);
      MathDisplay.WriteLine(@"2. Get 10 samples of f(x) = (x * x) / 2 equidistant starting at x=1 with step = 0.5 
      and retrieve sample points");
      MathDisplay.Write(@"Points: ");
      for (var i = 0; i < samplePoints.Length; i++)
      {
        MathDisplay.Write(samplePoints[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.Write(@"Values: ");
      for (var i = 0; i < result.Length; i++)
      {
        MathDisplay.Write(result[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 3. Get 10 samples of f(x) = (x * x) / 2 equidistant within period = 10 and period offset = 5
      result = Generate.PeriodicMap<double>(10, Function, 10, 1.0, 10, 5);
      MathDisplay.WriteLine(@"3. Get 10 samples of f(x) = (x * x) / 2 equidistant within period = 10 and period offset = 5");
      for (var i = 0; i < result.Length; i++)
      {
        MathDisplay.Write(result[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();



      MathDisplay.WriteLine("<b>Random sampling</b>");

      // 1. Get 10 random samples of f(x) = (x * x) / 2 using continuous uniform distribution on [-10, 10]
      var uniform = new ContinuousUniform(-10, 10);
      result = Generate.RandomMap<double>(10, uniform, Function);
      MathDisplay.WriteLine(@" 1. Get 10 random samples of f(x) = (x * x) / 2 using continuous uniform 
      distribution on [-10, 10]");
      for (var i = 0; i < result.Length; i++)
      {
        MathDisplay.Write(result[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 2. Get 10 random samples of f(x) = (x * x) / 2 using Exponential(1) distribution and retrieve sample points
      var exponential = new Exponential(1);
      samplePoints = Generate.Random(10, exponential);
      result = Generate.Map<double,double>(samplePoints, Function);
      MathDisplay.WriteLine(@"2. Get 10 random samples of f(x) = (x * x) / 2 using Exponential(1) distribution 
      and retrieve sample points");
      MathDisplay.Write(@"Points: ");
      for (var i = 0; i < samplePoints.Length; i++)
      {
        MathDisplay.Write(samplePoints[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.Write(@"Values: ");
      for (var i = 0; i < result.Length; i++)
      {
        MathDisplay.Write(result[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 3. Get 10 random samples of f(x, y) = (x * y) / 2 using ChiSquare(10) distribution
      var chiSquare = new ChiSquared(10);
      result = Generate.RandomMap2<double>(10, chiSquare, TwoDomainFunction);
      MathDisplay.WriteLine(@" 3. Get 10 random samples of f(x, y) = (x * y) / 2 using ChiSquare(10) distribution");
      for (var i = 0; i < result.Length; i++)
      {
        MathDisplay.Write(result[i].ToString("N") + @" ");
      }

      MathDisplay.WriteLine();
    }

    /// <summary>
    /// Fucntion f(x) = (x * x) / 2
    /// </summary>
    /// <param name="x">Input value</param>
    /// <returns>Calculation result</returns>
    public double Function(double x) {
      return Math.Pow(x, 2) / 2;
    }

    /// <summary>
    /// Fucntion f(x,y) = (x * y) / 2
    /// </summary>
    /// <param name="x">X input value</param>
    /// <param name="y">Y input value</param>
    /// <returns>Calculation result</returns>
    public double TwoDomainFunction(double x, double y) {
      return (x * y) / 2;
    }

  }

}
