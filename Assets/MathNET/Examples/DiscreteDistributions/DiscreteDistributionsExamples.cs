using System;
using MathNet.Numerics.Distributions;


namespace MathNet.Examples {

  public class DiscreteDistributionsExamples : MathNetExampleBase {

    public override void ExecuteExample() {

      // <a href="http://en.wikipedia.org/wiki/Binomial_distribution">Binomial distribution</a>
      MathDisplay.WriteLine("<b>Binomial distribution</b>");
      // 1. Initialize the new instance of the Binomial distribution class with parameters P = 0.2, N = 20
      var binomial = new Binomial(0.2, 20);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Binomial distribution class with parameters P = {0}, N = {1}", binomial.P, binomial.N);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", binomial);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", binomial.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", binomial.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", binomial.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", binomial.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", binomial.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", binomial.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", binomial.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", binomial.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", binomial.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", binomial.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", binomial.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", binomial.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Binomial distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Binomial distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(binomial.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Bernoulli_distribution">Bernoulli distribution</a>
      MathDisplay.WriteLine("<b>Bernoulli distribution</b>");
      // 1. Initialize the new instance of the Bernoulli distribution class with parameter P = 0.2
      var bernoulli = new Bernoulli(0.2);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Bernoulli distribution class with parameter P = {0}", bernoulli.P);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", bernoulli);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", bernoulli.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", bernoulli.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", bernoulli.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", bernoulli.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", bernoulli.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", bernoulli.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", bernoulli.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", bernoulli.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", bernoulli.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", bernoulli.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", bernoulli.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Bernoulli distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Bernoulli distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(bernoulli.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Categorical_distribution">Categorical distribution</a>
      MathDisplay.WriteLine("<b>Categorical distribution</b>");
      // 1. Initialize the new instance of the Categorical distribution class with parameters P = (0.1, 0.2, 0.25, 0.45)
      var binomialC = new Categorical(new[] { 0.1, 0.2, 0.25, 0.45 });
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Categorical distribution class with parameters P = (0.1, 0.2, 0.25, 0.45)");
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", binomialC);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", binomialC.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", binomialC.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", binomialC.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", binomialC.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", binomialC.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", binomialC.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", binomialC.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", binomialC.Median.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", binomialC.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", binomialC.StdDev.ToString(" #0.00000;-#0.00000"));

      // 3. Generate 10 samples of the Categorical distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Categorical distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(binomialC.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Conway%E2%80%93Maxwell%E2%80%93Poisson_distribution">ConwayMaxwellPoisson distribution</a>
      MathDisplay.WriteLine("<b>Conway Maxwell Poisson distribution</b>");
      // 1. Initialize the new instance of the ConwayMaxwellPoisson distribution class with parameters Lambda = 2, Nu = 1
      var conwayMaxwellPoisson = new ConwayMaxwellPoisson(2, 1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the ConwayMaxwellPoisson distribution class with parameters Lambda = {0}, Nu = {1}", conwayMaxwellPoisson.Lambda, conwayMaxwellPoisson.Nu);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", conwayMaxwellPoisson);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", conwayMaxwellPoisson.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", conwayMaxwellPoisson.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", conwayMaxwellPoisson.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", conwayMaxwellPoisson.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", conwayMaxwellPoisson.Mean.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", conwayMaxwellPoisson.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", conwayMaxwellPoisson.StdDev.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the ConwayMaxwellPoisson distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the ConwayMaxwellPoisson distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(conwayMaxwellPoisson.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Discrete_uniform">DiscreteUniform distribution</a>
      MathDisplay.WriteLine("<b>Discrete Uniform distribution</b>");
      // 1. Initialize the new instance of the DiscreteUniform distribution class with parameters LowerBound = 2, UpperBound = 10
      var discreteUniform = new DiscreteUniform(2, 10);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the DiscreteUniform distribution class with parameters LowerBound = {0}, UpperBound = {1}", discreteUniform.LowerBound, discreteUniform.UpperBound);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", discreteUniform);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", discreteUniform.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", discreteUniform.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", discreteUniform.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", discreteUniform.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", discreteUniform.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", discreteUniform.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", discreteUniform.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", discreteUniform.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", discreteUniform.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", discreteUniform.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", discreteUniform.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", discreteUniform.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the DiscreteUniform distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the DiscreteUniform distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(discreteUniform.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Geometric_distribution">Geometric distribution</a>
      MathDisplay.WriteLine("<b>Geometric distribution</b>");
      // 1. Initialize the new instance of the Geometric distribution class with parameter P = 0.2
      var geometric = new Geometric(0.2);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Geometric distribution class with parameter P = {0}", geometric.P);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", geometric);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", geometric.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", geometric.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", geometric.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", geometric.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", geometric.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", geometric.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", geometric.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", geometric.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", geometric.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", geometric.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", geometric.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", geometric.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Geometric distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Geometric distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(geometric.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Hypergeometric_distribution">Hypergeometric distribution</a>
      MathDisplay.WriteLine("<b>Hypergeometric distribution</b>");
      // 1. Initialize the new instance of the Hypergeometric distribution class with parameters PopulationSize = 10, M = 2, N = 8
      var hypergeometric = new Hypergeometric(30, 15, 10);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Hypergeometric distribution class with parameters Population = {0}, Success = {1}, Draws = {2}", hypergeometric.Population, hypergeometric.Success, hypergeometric.Draws);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", hypergeometric);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", hypergeometric.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", hypergeometric.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", hypergeometric.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", hypergeometric.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", hypergeometric.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", hypergeometric.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", hypergeometric.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", hypergeometric.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", hypergeometric.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", hypergeometric.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Hypergeometric distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Hypergeometric distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(hypergeometric.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Negative_binomial">NegativeBinomial distribution</a>
      MathDisplay.WriteLine("<b>Negative Binomial distribution</b>");
      // 1. Initialize the new instance of the NegativeBinomial distribution class with parameters P = 0.2, R = 20
      var negativeBinomial = new NegativeBinomial(20, 0.2);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the NegativeBinomial distribution class with parameters P = {0}, N = {1}", negativeBinomial.P, negativeBinomial.R);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", negativeBinomial);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", negativeBinomial.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", negativeBinomial.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", negativeBinomial.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", negativeBinomial.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", negativeBinomial.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", negativeBinomial.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", negativeBinomial.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", negativeBinomial.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", negativeBinomial.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", negativeBinomial.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the NegativeBinomial distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the NegativeBinomial distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(negativeBinomial.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Poisson_distribution">Poisson distribution</a>
      MathDisplay.WriteLine("<b>Poisson distribution</b>");
      // 1. Initialize the new instance of the Poisson distribution class with parameter Lambda = 1
      var poisson = new Poisson(1);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Poisson distribution class with parameter Lambda = {0}", poisson.Lambda);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", poisson);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", poisson.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", poisson.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", poisson.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", poisson.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", poisson.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", poisson.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", poisson.Mean.ToString(" #0.00000;-#0.00000"));

      // Median
      MathDisplay.WriteLine(@"{0} - Median", poisson.Median.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", poisson.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", poisson.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", poisson.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", poisson.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Poisson distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Poisson distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(poisson.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();


      // <a href="http://en.wikipedia.org/wiki/Zipf_distribution">Zipf distribution</a>
      MathDisplay.WriteLine("<b>Zipf distribution</b>");
      // 1. Initialize the new instance of the Zipf distribution class with parameters S = 5, N = 10
      var zipf = new Zipf(5, 10);
      MathDisplay.WriteLine(@"1. Initialize the new instance of the Zipf distribution class with parameters S = {0}, N = {1}", zipf.S, zipf.N);
      MathDisplay.WriteLine();

      // 2. Distributuion properties:
      MathDisplay.WriteLine(@"2. {0} distributuion properties:", zipf);

      // Cumulative distribution function
      MathDisplay.WriteLine(@"{0} - Сumulative distribution at location '3'", zipf.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

      // Probability density
      MathDisplay.WriteLine(@"{0} - Probability mass at location '3'", zipf.Probability(3).ToString(" #0.00000;-#0.00000"));

      // Log probability density
      MathDisplay.WriteLine(@"{0} - Log probability mass at location '3'", zipf.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

      // Entropy
      MathDisplay.WriteLine(@"{0} - Entropy", zipf.Entropy.ToString(" #0.00000;-#0.00000"));

      // Largest element in the domain
      MathDisplay.WriteLine(@"{0} - Largest element in the domain", zipf.Maximum.ToString(" #0.00000;-#0.00000"));

      // Smallest element in the domain
      MathDisplay.WriteLine(@"{0} - Smallest element in the domain", zipf.Minimum.ToString(" #0.00000;-#0.00000"));

      // Mean
      MathDisplay.WriteLine(@"{0} - Mean", zipf.Mean.ToString(" #0.00000;-#0.00000"));

      // Mode
      MathDisplay.WriteLine(@"{0} - Mode", zipf.Mode.ToString(" #0.00000;-#0.00000"));

      // Variance
      MathDisplay.WriteLine(@"{0} - Variance", zipf.Variance.ToString(" #0.00000;-#0.00000"));

      // Standard deviation
      MathDisplay.WriteLine(@"{0} - Standard deviation", zipf.StdDev.ToString(" #0.00000;-#0.00000"));

      // Skewness
      MathDisplay.WriteLine(@"{0} - Skewness", zipf.Skewness.ToString(" #0.00000;-#0.00000"));
      MathDisplay.WriteLine();

      // 3. Generate 10 samples of the Zipf distribution
      MathDisplay.WriteLine(@"3. Generate 10 samples of the Zipf distribution");
      for (var i = 0; i < 10; i++)
      {
        MathDisplay.Write(zipf.Sample().ToString("N05") + @" ");
      }
      MathDisplay.FlushBuffer();
      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

    }

  }

}
