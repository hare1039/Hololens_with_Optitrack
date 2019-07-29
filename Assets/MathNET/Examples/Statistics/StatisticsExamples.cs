using System;
using MathNet.Numerics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;


namespace MathNet.Examples {

  public class StatisticsExamples : MathNetExampleBase {

    /// <summary>
    /// Execute example
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Pearson_product-moment_correlation_coefficient">Pearson 
    /// product-moment correlation coefficient</seealso>
    public override void ExecuteExample() {
      // 1. Initialize the new instance of the ChiSquare distribution class with parameter dof = 5.
      var chiSquare = new ChiSquared(5);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the ChiSquare distribution class with parameter DegreesOfFreedom = {0}", chiSquare.DegreesOfFreedom);
      MathDisplay.WriteLine(@"{0} distributuion properties:", chiSquare);
      MathDisplay.WriteLine(@"{0} - Largest element", chiSquare.Maximum.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Smallest element", chiSquare.Minimum.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Mean", chiSquare.Mean.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Median", chiSquare.Median.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Mode", chiSquare.Mode.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Variance", chiSquare.Variance.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Standard deviation", chiSquare.StdDev.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Skewness", chiSquare.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 2. Generate 1000 samples of the ChiSquare(5) distribution
      MathDisplay.WriteLine(@"2. Generate 1000 samples of the ChiSquare(5) distribution");
      var data = new double[1000];
      for (var i = 0; i < data.Length; i++)
      {
        data[i] = chiSquare.Sample();
      }

      // 3. Get basic statistics on set of generated data using extention methods
      MathDisplay.WriteLine(@"3. Get basic statistics on set of generated data using extention methods");
      MathDisplay.WriteLine(@"{0} - Largest element", data.Maximum().ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Smallest element", data.Minimum().ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Mean", data.Mean().ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Median", data.Median().ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Biased population variance", data.PopulationVariance().ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Variance", data.Variance().ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Standard deviation", data.StandardDeviation().ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Biased sample standard deviation", data.PopulationStandardDeviation().ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 4. Compute the basic statistics of data set using DescriptiveStatistics class
      MathDisplay.WriteLine(@"4. Compute the basic statistics of data set using DescriptiveStatistics class");
      var descriptiveStatistics = new DescriptiveStatistics(data);
      MathDisplay.WriteLine(@"{0} - Kurtosis", descriptiveStatistics.Kurtosis.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Largest element", descriptiveStatistics.Maximum.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Smallest element", descriptiveStatistics.Minimum.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Mean", descriptiveStatistics.Mean.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Variance", descriptiveStatistics.Variance.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Standard deviation", descriptiveStatistics.StandardDeviation.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine(@"{0} - Skewness", descriptiveStatistics.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // Generate 1000 samples of the ChiSquare(2.5) distribution
      var chiSquareB = new ChiSquared(2);
      var dataB = new double[1000];
      for (var i = 0; i < data.Length; i++)
      {
        dataB[i] = chiSquareB.Sample();
      }

      // 5. Correlation coefficient between 1000 samples of ChiSquare(5) and ChiSquare(2.5)
      MathDisplay.WriteLine(@"5. Correlation coefficient between 1000 samples of ChiSquare(5) and ChiSquare(2.5) is {0}", Correlation.Pearson(data, dataB).ToString("N04"));
      MathDisplay.WriteLine(@"6. Ranked correlation coefficient between 1000 samples of ChiSquare(5) and ChiSquare(2.5) is {0}", Correlation.Spearman(data, dataB).ToString("N04"));
      MathDisplay.WriteLine();

      // 6. Correlation coefficient between 1000 samples of f(x) = x * 2 and f(x) = x * x
      data = Generate.LinearSpacedMap(1000, 0, 100, x => x * 2);
      dataB = Generate.LinearSpacedMap(1000, 0, 100, x => x * x);
      MathDisplay.WriteLine(@"7. Correlation coefficient between 1000 samples of f(x) = x * 2 and f(x) = x * x is {0}", Correlation.Pearson(data, dataB).ToString("N04"));
      MathDisplay.WriteLine(@"8. Ranked correlation coefficient between 1000 samples of f(x) = x * 2 and f(x) = x * x is {0}", Correlation.Spearman(data, dataB).ToString("N04"));
      MathDisplay.WriteLine();
    }
	
  }

}
