using System;
using System.Globalization;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Double.Solvers;
using MathNet.Numerics.LinearAlgebra.Solvers;
using System.Reflection;


namespace MathNet.Examples {

  public class IterativeSolversExamples : MathNetExampleBase {

    public override void ExecuteExample() {

      // <seealso cref="http://en.wikipedia.org/wiki/Biconjugate_gradient_stabilized_method">Biconjugate gradient stabilized method</seealso>
      MathDisplay.WriteLine("<b>Biconjugate gradient stabilised iterative solver</b>");

      // Format matrix output to console
      var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
      formatProvider.TextInfo.ListSeparator = " ";

      // Solve next system of linear equations (Ax=b):
      // 5*x + 2*y - 4*z = -7
      // 3*x - 7*y + 6*z = 38
      // 4*x + 1*y + 5*z = 43

      // Create matrix "A" with coefficients 
      var matrixA = DenseMatrix.OfArray(new[,] { { 5.00, 2.00, -4.00 }, { 3.00, -7.00, 6.00 }, { 4.00, 1.00, 5.00 } });
      MathDisplay.WriteLine(@"Matrix 'A' with coefficients");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create vector "b" with the constant terms.
      var vectorB = new DenseVector(new[] { -7.0, 38.0, 43.0 });
      MathDisplay.WriteLine(@"Vector 'b' with the constant terms");
      MathDisplay.WriteLine(vectorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create stop criteria to monitor an iterative calculation. There are next available stop criteria:
      // - DivergenceStopCriterion: monitors an iterative calculation for signs of divergence;
      // - FailureStopCriterion: monitors residuals for NaN's;
      // - IterationCountStopCriterion: monitors the numbers of iteration steps;
      // - ResidualStopCriterion: monitors residuals if calculation is considered converged;

      // Stop calculation if 1000 iterations reached during calculation
      var iterationCountStopCriterion = new IterationCountStopCriterion<double>(1000);

      // Stop calculation if residuals are below 1E-10 --> the calculation is considered converged
      var residualStopCriterion = new ResidualStopCriterion<double>(1e-10);

      // Create monitor with defined stop criteria
      var monitor = new Iterator<double>(iterationCountStopCriterion, residualStopCriterion);

      // Create Bi-Conjugate Gradient Stabilized solver
      var solverBiCgStab = new BiCgStab();

      // 1. Solve the matrix equation
      var resultX = matrixA.SolveIterative(vectorB, solverBiCgStab, monitor);
      MathDisplay.WriteLine(@"1. Solve the matrix equation");
      MathDisplay.WriteLine();

      // 2. Check solver status of the iterations. 
      // Solver has property IterationResult which contains the status of the iteration once the calculation is finished.
      // Possible values are:
      // - CalculationCancelled: calculation was cancelled by the user;
      // - CalculationConverged: calculation has converged to the desired convergence levels;
      // - CalculationDiverged: calculation diverged;
      // - CalculationFailure: calculation has failed for some reason;
      // - CalculationIndetermined: calculation is indetermined, not started or stopped;
      // - CalculationRunning: calculation is running and no results are yet known;
      // - CalculationStoppedWithoutConvergence: calculation has been stopped due to reaching the stopping limits, but that convergence was not achieved;
      MathDisplay.WriteLine(@"2. Solver status of the iterations");
      MathDisplay.WriteLine(monitor.Status.ToString());
      MathDisplay.WriteLine();

      // 3. Solution result vector of the matrix equation
      MathDisplay.WriteLine(@"3. Solution result vector of the matrix equation");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Verify result. Multiply coefficient matrix "A" by result vector "x"
      var reconstructVecorB = matrixA * resultX;
      MathDisplay.WriteLine(@"4. Multiply coefficient matrix 'A' by result vector 'x'");
      MathDisplay.WriteLine(reconstructVecorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();



      MathDisplay.WriteLine("<b>Generalized product biconjugate gradient solver</b>");

      // Solve next system of linear equations (Ax=b):
      // 5*x + 2*y - 4*z = -7
      // 3*x - 7*y + 6*z = 38
      // 4*x + 1*y + 5*z = 43

      // Create matrix "A" with coefficients 
      matrixA = DenseMatrix.OfArray(new[,] { { 5.00, 2.00, -4.00 }, { 3.00, -7.00, 6.00 }, { 4.00, 1.00, 5.00 } });
      MathDisplay.WriteLine(@"Matrix 'A' with coefficients");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create vector "b" with the constant terms.
      vectorB = new DenseVector(new[] { -7.0, 38.0, 43.0 });
      MathDisplay.WriteLine(@"Vector 'b' with the constant terms");
      MathDisplay.WriteLine(vectorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create stop criteria to monitor an iterative calculation. There are next available stop criteria:
      // - DivergenceStopCriterion: monitors an iterative calculation for signs of divergence;
      // - FailureStopCriterion: monitors residuals for NaN's;
      // - IterationCountStopCriterion: monitors the numbers of iteration steps;
      // - ResidualStopCriterion: monitors residuals if calculation is considered converged;

      // Stop calculation if 1000 iterations reached during calculation
      iterationCountStopCriterion = new IterationCountStopCriterion<double>(1000);

      // Stop calculation if residuals are below 1E-10 --> the calculation is considered converged
      residualStopCriterion = new ResidualStopCriterion<double>(1e-10);

      // Create monitor with defined stop criteria
      monitor = new Iterator<double>(iterationCountStopCriterion, residualStopCriterion);

      // Create Generalized Product Bi-Conjugate Gradient solver
      var solverGpBiCg = new GpBiCg();

      // 1. Solve the matrix equation
      resultX = matrixA.SolveIterative(vectorB, solverGpBiCg, monitor);
      MathDisplay.WriteLine(@"1. Solve the matrix equation");
      MathDisplay.WriteLine();

      // 2. Check solver status of the iterations. 
      // Solver has property IterationResult which contains the status of the iteration once the calculation is finished.
      // Possible values are:
      // - CalculationCancelled: calculation was cancelled by the user;
      // - CalculationConverged: calculation has converged to the desired convergence levels;
      // - CalculationDiverged: calculation diverged;
      // - CalculationFailure: calculation has failed for some reason;
      // - CalculationIndetermined: calculation is indetermined, not started or stopped;
      // - CalculationRunning: calculation is running and no results are yet known;
      // - CalculationStoppedWithoutConvergence: calculation has been stopped due to reaching the stopping limits, but that convergence was not achieved;
      MathDisplay.WriteLine(@"2. Solver status of the iterations");
      MathDisplay.WriteLine(monitor.Status.ToString());
      MathDisplay.WriteLine();

      // 3. Solution result vector of the matrix equation
      MathDisplay.WriteLine(@"3. Solution result vector of the matrix equation");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Verify result. Multiply coefficient matrix "A" by result vector "x"
      reconstructVecorB = matrixA * resultX;
      MathDisplay.WriteLine(@"4. Multiply coefficient matrix 'A' by result vector 'x'");
      MathDisplay.WriteLine(reconstructVecorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();


      MathDisplay.WriteLine("<b>Composite linear equation solver</b>");

      // Solve next system of linear equations (Ax=b):
      // 5*x + 2*y - 4*z = -7
      // 3*x - 7*y + 6*z = 38
      // 4*x + 1*y + 5*z = 43

      // Create matrix "A" with coefficients
      matrixA = DenseMatrix.OfArray(new[,] { { 5.00, 2.00, -4.00 }, { 3.00, -7.00, 6.00 }, { 4.00, 1.00, 5.00 } });
      MathDisplay.WriteLine(@"Matrix 'A' with coefficients");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create vector "b" with the constant terms.
      vectorB = new DenseVector(new[] { -7.0, 38.0, 43.0 });
      MathDisplay.WriteLine(@"Vector 'b' with the constant terms");
      MathDisplay.WriteLine(vectorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create stop criteria to monitor an iterative calculation. There are next available stop criteria:
      // - DivergenceStopCriterion: monitors an iterative calculation for signs of divergence;
      // - FailureStopCriterion: monitors residuals for NaN's;
      // - IterationCountStopCriterion: monitors the numbers of iteration steps;
      // - ResidualStopCriterion: monitors residuals if calculation is considered converged;

      // Stop calculation if 1000 iterations reached during calculation
      iterationCountStopCriterion = new IterationCountStopCriterion<double>(1000);

      // Stop calculation if residuals are below 1E-10 --> the calculation is considered converged
      residualStopCriterion = new ResidualStopCriterion<double>(1e-10);

      // Create monitor with defined stop criteria
      monitor = new Iterator<double>(iterationCountStopCriterion, residualStopCriterion);

      // Load all suitable solvers from current assembly. Below (see UserBiCgStab) there is a custom user-defined solver
      // "class UserBiCgStab : IIterativeSolverSetup<double>" which derives from the regular BiCgStab solver. However users can
      // create any other solver and solver setup classes that implement IIterativeSolverSetup<T> and load the assembly that 
      // contains them using the following function: 
      var solverComp = new CompositeSolver(SolverSetup<double>.LoadFromAssembly(Assembly.GetExecutingAssembly()));

      // 1. Solve the linear system
      resultX = matrixA.SolveIterative(vectorB, solverComp, monitor);
      MathDisplay.WriteLine(@"1. Solve the matrix equation");
      MathDisplay.WriteLine();

      // 2. Check solver status of the iterations.
      // Solver has property IterationResult which contains the status of the iteration once the calculation is finished.
      // Possible values are:
      // - CalculationCancelled: calculation was cancelled by the user;
      // - CalculationConverged: calculation has converged to the desired convergence levels;
      // - CalculationDiverged: calculation diverged;
      // - CalculationFailure: calculation has failed for some reason;
      // - CalculationIndetermined: calculation is indetermined, not started or stopped;
      // - CalculationRunning: calculation is running and no results are yet known;
      // - CalculationStoppedWithoutConvergence: calculation has been stopped due to reaching the stopping limits, but that convergence was not achieved;
      MathDisplay.WriteLine(@"2. Solver status of the iterations");
      MathDisplay.WriteLine(monitor.Status.ToString());
      MathDisplay.WriteLine();

      // 3. Solution result vector of the matrix equation
      MathDisplay.WriteLine(@"3. Solution result vector of the matrix equation");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Verify result. Multiply coefficient matrix "A" by result vector "x"
      reconstructVecorB = matrixA * resultX;
      MathDisplay.WriteLine(@"4. Multiply coefficient matrix 'A' by result vector 'x'");
      MathDisplay.WriteLine(reconstructVecorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();


      MathDisplay.WriteLine("<b>Multiple-Lanczos biconjugate gradient stabilised iterative solver</b>");

      // Solve next system of linear equations (Ax=b):
      // 5*x + 2*y - 4*z = -7
      // 3*x - 7*y + 6*z = 38
      // 4*x + 1*y + 5*z = 43

      // Create matrix "A" with coefficients
      matrixA = DenseMatrix.OfArray(new[,] { { 5.00, 2.00, -4.00 }, { 3.00, -7.00, 6.00 }, { 4.00, 1.00, 5.00 } });
      MathDisplay.WriteLine(@"Matrix 'A' with coefficients");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create vector "b" with the constant terms.
      vectorB = new DenseVector(new[] { -7.0, 38.0, 43.0 });
      MathDisplay.WriteLine(@"Vector 'b' with the constant terms");
      MathDisplay.WriteLine(vectorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create stop criteria to monitor an iterative calculation. There are next available stop criteria:
      // - DivergenceStopCriterion: monitors an iterative calculation for signs of divergence;
      // - FailureStopCriterion: monitors residuals for NaN's;
      // - IterationCountStopCriterion: monitors the numbers of iteration steps;
      // - ResidualStopCriterion: monitors residuals if calculation is considered converged;

      // Stop calculation if 1000 iterations reached during calculation
      iterationCountStopCriterion = new IterationCountStopCriterion<double>(1000);

      // Stop calculation if residuals are below 1E-10 --> the calculation is considered converged
      residualStopCriterion = new ResidualStopCriterion<double>(1e-10);

      // Create monitor with defined stop criteria
      monitor = new Iterator<double>(iterationCountStopCriterion, residualStopCriterion);

      // Create Multiple-Lanczos Bi-Conjugate Gradient Stabilized solver
      var solverLanczos = new MlkBiCgStab();

      // 1. Solve the matrix equation
      resultX = matrixA.SolveIterative(vectorB, solverLanczos, monitor);
      MathDisplay.WriteLine(@"1. Solve the matrix equation");
      MathDisplay.WriteLine();

      // 2. Check solver status of the iterations.
      // Solver has property IterationResult which contains the status of the iteration once the calculation is finished.
      // Possible values are:
      // - CalculationCancelled: calculation was cancelled by the user;
      // - CalculationConverged: calculation has converged to the desired convergence levels;
      // - CalculationDiverged: calculation diverged;
      // - CalculationFailure: calculation has failed for some reason;
      // - CalculationIndetermined: calculation is indetermined, not started or stopped;
      // - CalculationRunning: calculation is running and no results are yet known;
      // - CalculationStoppedWithoutConvergence: calculation has been stopped due to reaching the stopping limits, but that convergence was not achieved;
      MathDisplay.WriteLine(@"2. Solver status of the iterations");
      MathDisplay.WriteLine(monitor.Status.ToString());
      MathDisplay.WriteLine();

      // 3. Solution result vector of the matrix equation
      MathDisplay.WriteLine(@"3. Solution result vector of the matrix equation");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Verify result. Multiply coefficient matrix "A" by result vector "x"
      reconstructVecorB = matrixA*resultX;
      MathDisplay.WriteLine(@"4. Multiply coefficient matrix 'A' by result vector 'x'");
      MathDisplay.WriteLine(reconstructVecorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();


      MathDisplay.WriteLine("<b>Transpose freee quasi-minimal residual iterative solver</b>");

      // Solve next system of linear equations (Ax=b):
      // 5*x + 2*y - 4*z = -7
      // 3*x - 7*y + 6*z = 38
      // 4*x + 1*y + 5*z = 43

      // Create matrix "A" with coefficients 
      matrixA = DenseMatrix.OfArray(new[,] { { 5.00, 2.00, -4.00 }, { 3.00, -7.00, 6.00 }, { 4.00, 1.00, 5.00 } });
      MathDisplay.WriteLine(@"Matrix 'A' with coefficients");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create vector "b" with the constant terms.
      vectorB = new DenseVector(new[] { -7.0, 38.0, 43.0 });
      MathDisplay.WriteLine(@"Vector 'b' with the constant terms");
      MathDisplay.WriteLine(vectorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create stop criteria to monitor an iterative calculation. There are next available stop criteria:
      // - DivergenceStopCriterion: monitors an iterative calculation for signs of divergence;
      // - FailureStopCriterion: monitors residuals for NaN's;
      // - IterationCountStopCriterion: monitors the numbers of iteration steps;
      // - ResidualStopCriterion: monitors residuals if calculation is considered converged;

      // Stop calculation if 1000 iterations reached during calculation
      iterationCountStopCriterion = new IterationCountStopCriterion<double>(1000);

      // Stop calculation if residuals are below 1E-10 --> the calculation is considered converged
      residualStopCriterion = new ResidualStopCriterion<double>(1e-10);

      // Create monitor with defined stop criteria
      monitor = new Iterator<double>(iterationCountStopCriterion, residualStopCriterion);

      // Create Transpose Free Quasi-Minimal Residual solver
      var solverTFQMR = new TFQMR();

      // 1. Solve the matrix equation
      resultX = matrixA.SolveIterative(vectorB, solverTFQMR, monitor);
      MathDisplay.WriteLine(@"1. Solve the matrix equation");
      MathDisplay.WriteLine();

      // 2. Check solver status of the iterations. 
      // Solver has property IterationResult which contains the status of the iteration once the calculation is finished.
      // Possible values are:
      // - CalculationCancelled: calculation was cancelled by the user;
      // - CalculationConverged: calculation has converged to the desired convergence levels;
      // - CalculationDiverged: calculation diverged;
      // - CalculationFailure: calculation has failed for some reason;
      // - CalculationIndetermined: calculation is indetermined, not started or stopped;
      // - CalculationRunning: calculation is running and no results are yet known;
      // - CalculationStoppedWithoutConvergence: calculation has been stopped due to reaching the stopping limits, but that convergence was not achieved;
      MathDisplay.WriteLine(@"2. Solver status of the iterations");
      MathDisplay.WriteLine(monitor.Status.ToString());
      MathDisplay.WriteLine();

      // 3. Solution result vector of the matrix equation
      MathDisplay.WriteLine(@"3. Solution result vector of the matrix equation");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Verify result. Multiply coefficient matrix "A" by result vector "x"
      reconstructVecorB = matrixA*resultX;
      MathDisplay.WriteLine(@"4. Multiply coefficient matrix 'A' by result vector 'x'");
      MathDisplay.WriteLine(reconstructVecorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

    }

    /// <summary>
    /// Sample of user-defined solver setup
    /// </summary>
    public class UserBiCgStab : IIterativeSolverSetup<double> {
      /// <summary>
      /// Gets the type of the solver that will be created by this setup object.
      /// </summary>
      public Type SolverType {
        get { return null; }
      }

      /// <summary>
      /// Gets type of preconditioner, if any, that will be created by this setup object.
      /// </summary>
      public Type PreconditionerType {
        get { return null; }
      }

      /// <summary>
      /// Creates a fully functional iterative solver with the default settings
      /// given by this setup.
      /// </summary>
      /// <returns>A new <see cref="IIterativeSolver{T}"/>.</returns>
      public IIterativeSolver<double> CreateSolver() {
        return new BiCgStab();
      }

      public IPreconditioner<double> CreatePreconditioner() {
        return null;
      }

      /// <summary>
      /// Gets the relative speed of the solver.
      /// </summary>
      /// <value>Returns a value between 0 and 1, inclusive.</value>
      public double SolutionSpeed {
        get { return 0.99; }
      }

      /// <summary>
      /// Gets the relative reliability of the solver.
      /// </summary>
      /// <value>Returns a value between 0 and 1 inclusive.</value>
      public double Reliability {
        get { return 0.99; }
      }
    }

  }

}
