using System;
using System.Linq;
using System.Collections.Generic;
using MathNet.Numerics.Distributions;


namespace MathNet.Examples {

  public class ContinuousDistributionsExamples : MathNetExampleBase {

    public override void ExecuteExample() {

      MathDisplay.WriteLine("<b>Beta distribution</b>");

      // 1. Initialize the new instance of the Beta distribution class with parameters a = 5 and b = 1.
      var beta = new Beta(5, 1);
      MathDisplay.WriteLine(
        @"1. Initialize the new instance of the Beta distribution class with parameters a = {0} and b = {1}",
        beta.A,
        beta.B);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", beta);

      // Cumulative distribution function
      MathDisplay.WriteLine(
        @"{0} - Сumulative distribution at location '0.3'",
        beta.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(
        @"{0} - Probability density at location '0.3'",
        beta.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(
        @"{0} - Log probability density at location '0.3'",
        beta.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", beta.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", beta.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", beta.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", beta.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", beta.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", beta.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", beta.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", beta.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Beta distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Beta distribution");
      for(var i = 0; i < 10; i++) {
        MathDisplay.Write(beta.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Chi_distribution">Chi distribution</a>
      MathDisplay.WriteLine("<b>Chi distribution</b>");

      // 1. Initialize the new instance of the Chi distribution class with parameter dof = 1.
      var chi = new Chi(1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Chi distribution class with parameter DegreesOfFreedom = {0}", chi.DegreesOfFreedom);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", chi);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", chi.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", chi.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", chi.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", chi.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", chi.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", chi.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", chi.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", chi.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", chi.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", chi.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", chi.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Chi distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Chi distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(chi.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Chi-square_distribution">ChiSquare distribution</a>
      MathDisplay.WriteLine("<b>Chi square distribution</b>");

      // 1. Initialize the new instance of the ChiSquare distribution class with parameter dof = 1.
      var chiSquare = new ChiSquared(1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the ChiSquare distribution class with parameter DegreesOfFreedom = {0}", chiSquare.DegreesOfFreedom);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", chiSquare);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", chiSquare.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", chiSquare.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", chiSquare.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", chiSquare.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", chiSquare.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", chiSquare.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", chiSquare.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", chiSquare.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", chiSquare.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", chiSquare.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", chiSquare.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", chiSquare.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the ChiSquare distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the ChiSquare distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(chiSquare.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Cauchy_distribution">Cauchy distribution</a>
      MathDisplay.WriteLine("<b>Cauchy distribution</b>");

      // 1. Initialize the new instance of the Cauchy distribution class with parameters Location = 1 and Scale = 2.
      var cauchy = new Cauchy(1, 2);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Cauchy distribution class with parameters Location = {0} and Scale = {1}", cauchy.Location, cauchy.Scale);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", cauchy);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", cauchy.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", cauchy.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", cauchy.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", cauchy.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", cauchy.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", cauchy.Minimum.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", cauchy.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", cauchy.Mode.ToString(" #0.00000;-#0.00000"));

      // 3. Generate 10 samples of the Cauchy distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Cauchy distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(cauchy.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Uniform_distribution_%28continuous%29">ContinuousUniform distribution</a>
      MathDisplay.WriteLine("<b>Continuous uniform distribution</b>");

      // 1. Initialize the new instance of the ContinuousUniform distribution class with default parameters.
      var continuousUniform = new ContinuousUniform();
      MathDisplay.WriteLine(@"1. Initialize the new instance of the ContinuousUniform distribution class with parameters Lower = {0}, Upper = {1}", continuousUniform.LowerBound, continuousUniform.UpperBound);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", continuousUniform);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", continuousUniform.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", continuousUniform.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", continuousUniform.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", continuousUniform.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", continuousUniform.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", continuousUniform.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", continuousUniform.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", continuousUniform.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", continuousUniform.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", continuousUniform.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", continuousUniform.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", continuousUniform.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the ContinuousUniform distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the ContinuousUniform distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(continuousUniform.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Erlang_distribution">Erlang distribution</a>
      MathDisplay.WriteLine("<b>Erlang distribution</b>");
      // 1. Initialize the new instance of the Erlang distribution class with parameters Shape = 1, Scale = 2.
      var erlang = new Erlang(1, 2.0);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Erlang distribution class with parameters Shape = {0}, Scale = {1}", erlang.Shape, erlang.Scale);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", erlang);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", erlang.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", erlang.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", erlang.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", erlang.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", erlang.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", erlang.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", erlang.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", erlang.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", erlang.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", erlang.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", erlang.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Erlang distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Erlang distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(erlang.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Exponential_distribution">Exponential distribution</a>
      MathDisplay.WriteLine("<b>Exponential distribution</b>");
      // 1. Initialize the new instance of the Exponential distribution class with parameter Lambda = 1.
      var exponential = new Exponential(1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Exponential distribution class with parameter Lambda = {0}", exponential.Rate);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", exponential);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", exponential.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", exponential.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", exponential.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", exponential.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", exponential.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", exponential.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", exponential.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", exponential.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", exponential.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", exponential.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", exponential.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", exponential.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Exponential distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Exponential distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(exponential.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/F-distribution">FisherSnedecor distribution</a>
      MathDisplay.WriteLine("<b>Fisher Snedecor distribution</b>");
      // 1. Initialize the new instance of the FisherSnedecor distribution class with parameter DegreesOfFreedom1 = 50, DegreesOfFreedom2 = 20.
      var fisherSnedecor = new FisherSnedecor(50, 20);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the FisherSnedecor distribution class with parameters DegreesOfFreedom1 = {0}, DegreesOfFreedom2 = {1}", fisherSnedecor.DegreesOfFreedom1, fisherSnedecor.DegreesOfFreedom2);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", fisherSnedecor);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", fisherSnedecor.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", fisherSnedecor.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", fisherSnedecor.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", fisherSnedecor.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", fisherSnedecor.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", fisherSnedecor.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", fisherSnedecor.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", fisherSnedecor.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", fisherSnedecor.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", fisherSnedecor.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the FisherSnedecor distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the FisherSnedecor distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(fisherSnedecor.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Gamma_distribution">Gamma distribution</a>
      MathDisplay.WriteLine("<b>Gamma distribution</b>");
      // 1. Initialize the new instance of the Gamma distribution class with parameter Shape = 1, Scale = 0.5.
      var gamma = new Gamma(1, 2.0);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Gamma distribution class with parameters Shape = {0}, Scale = {1}", gamma.Shape, gamma.Scale);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", gamma);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", gamma.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", gamma.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", gamma.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", gamma.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", gamma.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", gamma.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", gamma.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", gamma.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", gamma.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", gamma.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", gamma.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Gamma distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Gamma distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(gamma.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Inverse-gamma_distribution">InverseGamma distribution</a>
      MathDisplay.WriteLine("<b>Inverse gamma distribution</b>");
      // 1. Initialize the new instance of the InverseGamma distribution class with parameters shape = 4, scale = 0.5
      var inverseGamma = new InverseGamma(4, 0.5);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the InverseGamma distribution class with parameters Shape = {0}, Scale = {1}", inverseGamma.Shape, inverseGamma.Scale);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", inverseGamma);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", inverseGamma.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", inverseGamma.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", inverseGamma.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", inverseGamma.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", inverseGamma.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", inverseGamma.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", inverseGamma.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", inverseGamma.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", inverseGamma.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", inverseGamma.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", inverseGamma.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the InverseGamma distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the InverseGamma distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(inverseGamma.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Laplace_distribution">Laplace distribution</a>
      MathDisplay.WriteLine("<b>Laplace distribution</b>");
      // 1. Initialize the new instance of the Laplace distribution class with parameters Location = {0}, Scale = {1}
      var laplace = new Laplace(0, 1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Laplace distribution class with parameters Location = {0}, Scale = {1}", laplace.Location, laplace.Scale);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", laplace);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", laplace.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", laplace.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", laplace.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", laplace.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", laplace.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", laplace.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", laplace.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", laplace.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", laplace.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", laplace.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", laplace.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", laplace.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Laplace distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Laplace distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(laplace.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Log-normal_distribution">LogNormal distribution</a>
      MathDisplay.WriteLine("<b>Log-normal distribution</b>");
      // 1. Initialize the new instance of the LogNormal distribution class with parameters Mu = 0, Sigma = 1
      var logNormal = new LogNormal(0, 1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the LogNormal distribution class with parameters Mu = {0}, Sigma = {1}", logNormal.Mu, logNormal.Sigma);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", logNormal);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", logNormal.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", logNormal.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", logNormal.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", logNormal.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", logNormal.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", logNormal.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", logNormal.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", logNormal.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", logNormal.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", logNormal.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", logNormal.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", logNormal.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples
      MathDisplay.WriteLine(@"3. Generate 10 samples");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(logNormal.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Normal_distribution">Normal distribution</a>
      MathDisplay.WriteLine("<b>Normal distribution</b>");
      // 1. Initialize the new instance of the Normal distribution class with parameters Mean = 0, StdDev = 1
      var normal = new Normal(0, 1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Normal distribution class with parameters Mean = {0}, StdDev = {1}", normal.Mean, normal.StdDev);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", normal);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", normal.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", normal.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", normal.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", normal.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", normal.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", normal.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", normal.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", normal.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", normal.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", normal.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", normal.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", normal.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples
      MathDisplay.WriteLine(@"3. Generate 10 samples");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(normal.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Pareto_distribution">Pareto distribution</a>
      MathDisplay.WriteLine("<b>Pareto distribution</b>");
      // 1. Initialize the new instance of the Pareto distribution class with parameters Shape = 3, Scale = 1
      var pareto = new Pareto(1, 3);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Pareto distribution class with parameters Shape = {0}, Scale = {1}", pareto.Shape, pareto.Scale);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", pareto);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", pareto.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", pareto.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", pareto.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", pareto.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", pareto.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", pareto.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", pareto.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", pareto.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", pareto.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", pareto.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", pareto.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", pareto.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Pareto distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Pareto distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(pareto.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Rayleigh_distribution">Rayleigh distribution</a>
      MathDisplay.WriteLine("<b>Rayleigh distribution</b>");
      // 1. Initialize the new instance of the Rayleigh distribution class with parameter Scale = 1.
      var rayleigh = new Rayleigh(1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Rayleigh distribution class with parameter Scale = {0}", rayleigh.Scale);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", rayleigh);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", rayleigh.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", rayleigh.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", rayleigh.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", rayleigh.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", rayleigh.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", rayleigh.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", rayleigh.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", rayleigh.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", rayleigh.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", rayleigh.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", rayleigh.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", rayleigh.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Rayleigh distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Rayleigh distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(rayleigh.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/StudentT_distribution">StudentT distribution</a>
      MathDisplay.WriteLine("<b>Cauchy distribution</b>");
      // 1. Initialize the new instance of the StudentT distribution class with parameters Location = 0, Scale = 1, DegreesOfFreedom = 1
      var studentT = new StudentT();
      MathDisplay.WriteLine(@"1. Initialize the new instance of the StudentT distribution class with parameters Location = {0}, Scale = {1}, DegreesOfFreedom = {2}", studentT.Location, studentT.Scale, studentT.DegreesOfFreedom);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", studentT);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", studentT.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", studentT.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", studentT.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", studentT.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", studentT.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", studentT.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", studentT.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", studentT.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", studentT.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", studentT.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", studentT.StdDev.ToString(" #0.00000;-#0.00000"));

      // 3. Generate 10 samples of the StudentT distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the StudentT distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(studentT.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Stable_distribution">Stable distribution</a>
      MathDisplay.WriteLine("<b>Stable distribution</b>");
      // 1. Initialize the new instance of the Stable distribution class with parameters Alpha = 2.0, Beta = 0, Scale = 1, Location = 0.
      var stable = new Stable(2.0, 0, 1, 0);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Stable distribution class with parameters Alpha = {0}, Beta = {1}, Scale = {2}, Location = {3}", stable.Alpha, stable.Beta, stable.Scale, stable.Location);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", stable);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", stable.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", stable.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", stable.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", stable.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", stable.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", stable.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", stable.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", stable.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", stable.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", stable.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", stable.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Stable distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Stable distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(stable.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="https://en.wikipedia.org/wiki/Triangular_distribution">Triangular distribution</a>
      MathDisplay.WriteLine("<b>Triangular distribution</b>");
      // 1. Initialize
      var triangular = new Triangular(0, 1, 0.3);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Triangular distribution class with parameters Lower = {0}, Upper = {1}, Mode = {2}", triangular.LowerBound, triangular.UpperBound, triangular.Mode);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", triangular);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", triangular.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", triangular.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", triangular.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", triangular.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", triangular.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", triangular.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", triangular.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", triangular.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", triangular.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", triangular.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", triangular.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", triangular.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 10 samples
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Triangular distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(triangular.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Weibull_distribution">Weibull distribution</a>
      MathDisplay.WriteLine("<b>Weibull distribution</b>");
      // 1. Initialize the new instance of the Weibull distribution class with parameters Scale = 1, Shape = 0.5
      var weibull = new Weibull(0.5, 1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Weibull distribution class with parameterы Scale = {0}, Shape = {1}", weibull.Scale, weibull.Shape);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", weibull);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '0.3'", weibull.CumulativeDistribution(0.3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability density at location '0.3'", weibull.Density(0.3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability density at location '0.3'", weibull.DensityLn(0.3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", weibull.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", weibull.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", weibull.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", weibull.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", weibull.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", weibull.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", weibull.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", weibull.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", weibull.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Weibull distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Weibull distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(weibull.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


    }

  }

}
