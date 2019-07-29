using System;
using System.Globalization;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;


namespace MathNet.Examples {

  public class LinearAlgebraGeneralExamples : MathNetExampleBase {

    public override void ExecuteExample() {

      MathDisplay.WriteLine("<b>Direct solvers</b>");

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

      // 1. Solve linear equations using LU decomposition
      var resultX = matrixA.LU().Solve(vectorB);
      MathDisplay.WriteLine(@"1. Solution using LU decomposition");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Solve linear equations using QR decomposition
      resultX = matrixA.QR().Solve(vectorB);
      MathDisplay.WriteLine(@"2. Solution using QR decomposition");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Solve linear equations using SVD decomposition
      matrixA.Svd().Solve(vectorB, resultX);
      MathDisplay.WriteLine(@"3. Solution using SVD decomposition");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Solve linear equations using Gram-Shmidt decomposition
      matrixA.GramSchmidt().Solve(vectorB, resultX);
      MathDisplay.WriteLine(@"4. Solution using Gram-Shmidt decomposition");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 5. Verify result. Multiply coefficient matrix "A" by result vector "x"
      var reconstructVecorB = matrixA * resultX;
      MathDisplay.WriteLine(@"5. Multiply coefficient matrix 'A' by result vector 'x'");
      MathDisplay.WriteLine(reconstructVecorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // To use Cholesky or Eigenvalue decomposition coefficient matrix must be 
      // symmetric (for Evd and Cholesky) and positive definite (for Cholesky)
      // Multipy matrix "A" by its transpose - the result will be symmetric and positive definite matrix
      var newMatrixA = matrixA.TransposeAndMultiply(matrixA);
      MathDisplay.WriteLine(@"Symmetric positive definite matrix");
      MathDisplay.WriteLine(newMatrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 6. Solve linear equations using Cholesky decomposition
      newMatrixA.Cholesky().Solve(vectorB, resultX);
      MathDisplay.WriteLine(@"6. Solution using Cholesky decomposition");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 7. Solve linear equations using eigen value decomposition
      newMatrixA.Evd().Solve(vectorB, resultX);
      MathDisplay.WriteLine(@"7. Solution using eigen value decomposition");
      MathDisplay.WriteLine(resultX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 8. Verify result. Multiply new coefficient matrix "A" by result vector "x"
      reconstructVecorB = newMatrixA * resultX;
      MathDisplay.WriteLine(@"8. Multiply new coefficient matrix 'A' by result vector 'x'");
      MathDisplay.WriteLine(reconstructVecorB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();


      MathDisplay.WriteLine("<b>Data access, copying and conversions</b>");

      // Create new empty square matrix
      var matrix = new DenseMatrix(10);
      MathDisplay.WriteLine(@"Empty matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 1. Fill matrix by data using indexer []
      var k = 0;
      for(var i = 0; i < matrix.RowCount; i++) {
        for(var j = 0; j < matrix.ColumnCount; j++) {
          matrix[i, j] = k++;
        }
      }

      MathDisplay.WriteLine(@"1. Fill matrix by data using indexer []");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Fill matrix by data using At. The element is set without range checking.
      for(var i = 0; i < matrix.RowCount; i++) {
        for(var j = 0; j < matrix.ColumnCount; j++) {
          matrix.At(i, j, k--);
        }
      }

      MathDisplay.WriteLine(@"2. Fill matrix by data using At");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Clone matrix
      var clone = matrix.Clone();
      MathDisplay.WriteLine(@"3. Clone matrix");
      MathDisplay.WriteLine(clone.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Clear matrix
      clone.Clear();
      MathDisplay.WriteLine(@"4. Clear matrix");
      MathDisplay.WriteLine(clone.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 5. Copy matrix into another matrix
      matrix.CopyTo(clone);
      MathDisplay.WriteLine(@"5. Copy matrix into another matrix");
      MathDisplay.WriteLine(clone.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 6. Get submatrix into another matrix
      var submatrix = matrix.SubMatrix(2, 2, 3, 3);
      MathDisplay.WriteLine(@"6. Copy submatrix into another matrix");
      MathDisplay.WriteLine(submatrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 7. Get part of the row as vector. In this example: get 4 elements from row 5 starting from column 3
      var row = matrix.Row(5, 3, 4);
      MathDisplay.WriteLine(@"7. Get part of the row as vector");
      MathDisplay.WriteLine(row.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 8. Get part of the column as vector. In this example: get 3 elements from column 2 starting from row 6
      var column = matrix.Column(2, 6, 3);
      MathDisplay.WriteLine(@"8. Get part of the column as vector");
      MathDisplay.WriteLine(column.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 9. Get columns using column enumerator. If you need all columns you may use ColumnEnumerator without parameters
      MathDisplay.WriteLine(@"9. Get columns using column enumerator");
      foreach(var keyValuePair in matrix.EnumerateColumnsIndexed(2, 4)) {
        MathDisplay.WriteLine(
          @"Column {0}: {1}",
          keyValuePair.Item1,
          keyValuePair.Item2.ToString(
            "#0.00\t",
            formatProvider));
      }

      MathDisplay.WriteLine();

      // 10. Get rows using row enumerator. If you need all rows you may use RowEnumerator without parameters
      MathDisplay.WriteLine(@"10. Get rows using row enumerator");
      foreach(var keyValuePair in matrix.EnumerateRowsIndexed(4, 3)) {
        MathDisplay.WriteLine(@"Row {0}: {1}", keyValuePair.Item1, keyValuePair.Item2.ToString("#0.00\t", formatProvider));
      }

      MathDisplay.WriteLine();

      // 11. Convert matrix into multidimensional array
      var data = matrix.ToArray();
      MathDisplay.WriteLine(@"11. Convert matrix into multidimensional array");
      for(var i = 0; i < data.GetLongLength(0); i++) {
        for(var j = 0; j < data.GetLongLength(1); j++) {
          MathDisplay.Write(data[i, j].ToString("#0.00\t"));
        }
        MathDisplay.FlushBuffer();

        MathDisplay.WriteLine();
      }

      MathDisplay.WriteLine();

      // 12. Convert matrix into row-wise array
      var rowwise = matrix.ToRowMajorArray();
      MathDisplay.WriteLine(@"12. Convert matrix into row-wise array");
      for(var i = 0; i < matrix.RowCount; i++) {
        for(var j = 0; j < matrix.ColumnCount; j++) {
          MathDisplay.Write(rowwise[(i * matrix.ColumnCount) + j].ToString("#0.00\t"));
        }
        MathDisplay.FlushBuffer();

        MathDisplay.WriteLine();
      }

      MathDisplay.WriteLine();

      // 13. Convert matrix into column-wise array
      var columnise = matrix.ToColumnMajorArray();
      MathDisplay.WriteLine(@"13. Convert matrix into column-wise array");
      for(var i = 0; i < matrix.RowCount; i++) {
        for(var j = 0; j < matrix.ColumnCount; j++) {
          MathDisplay.Write(columnise[(j * matrix.RowCount) + i].ToString("#0.00\t"));
        }
        MathDisplay.FlushBuffer();

        MathDisplay.WriteLine();
      }

      MathDisplay.WriteLine();

      // 14. Get matrix diagonal as vector
      var diagonal = matrix.Diagonal();
      MathDisplay.WriteLine(@"14. Get matrix diagonal as vector");
      MathDisplay.WriteLine(diagonal.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();


      // <seealso cref="http://en.wikipedia.org/wiki/Matrix_multiplication#Scalar_multiplication">Multiply matrix by scalar</seealso>
      // <seealso cref="http://reference.wolfram.com/mathematica/tutorial/MultiplyingVectorsAndMatrices.html">Multiply matrix by vector</seealso>
      // <seealso cref="http://en.wikipedia.org/wiki/Matrix_multiplication#Matrix_product">Multiply matrix by matrix</seealso>
      // <seealso cref="http://en.wikipedia.org/wiki/Matrix_multiplication#Hadamard_product">Pointwise multiplies matrix with another matrix</seealso>
      // <seealso cref="http://en.wikipedia.org/wiki/Matrix_%28mathematics%29#Basic_operations">Addition and subtraction</seealso>
      MathDisplay.WriteLine("<b>Basic matrix operations (+, -, *, /) </b>");


      // Initialize IFormatProvider to print matrix/vector data 
      formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
      formatProvider.TextInfo.ListSeparator = " ";

      // Create matrix "A"
      matrixA = DenseMatrix.OfArray(new[,] { { 1.0, 2.0, 3.0 }, { 4.0, 5.0, 6.0 }, { 7.0, 8.0, 9.0 } });
      MathDisplay.WriteLine(@"Matrix A");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create matrix "B"
      var matrixB = DenseMatrix.OfArray(new[,] { { 1.0, 3.0, 5.0 }, { 2.0, 4.0, 6.0 }, { 3.0, 5.0, 7.0 } });
      MathDisplay.WriteLine(@"Matrix B");
      MathDisplay.WriteLine(matrixB.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Multiply matrix by scalar
      // 1. Using operator "*"
      var resultM = 3.0 * matrixA;
      MathDisplay.WriteLine(@"Multiply matrix by scalar using operator *. (result = 3.0 * A)");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using Multiply method and getting result into different matrix instance
      resultM = (DenseMatrix)matrixA.Multiply(3.0);
      MathDisplay.WriteLine(@"Multiply matrix by scalar using method Multiply. (result = A.Multiply(3.0))");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Using Multiply method and updating matrix itself
      matrixA.Multiply(3.0, matrixA);
      MathDisplay.WriteLine(@"Multiply matrix by scalar using method Multiply. (A.Multiply(3.0, A))");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Multiply matrix by vector (right-multiply)
      var vector = new DenseVector(new[] { 1.0, 2.0, 3.0 });
      MathDisplay.WriteLine(@"Vector");
      MathDisplay.WriteLine(vector.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 1. Using operator "*"
      var resultV = matrixA * vector;
      MathDisplay.WriteLine(@"Multiply matrix by vector using operator *. (result = A * vec)");
      MathDisplay.WriteLine(resultV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using Multiply method and getting result into different vector instance
      resultV = (DenseVector)matrixA.Multiply(vector);
      MathDisplay.WriteLine(@"Multiply matrix by vector using method Multiply. (result = A.Multiply(vec))");
      MathDisplay.WriteLine(resultV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Using Multiply method and updating vector itself
      matrixA.Multiply(vector, vector);
      MathDisplay.WriteLine(@"Multiply matrix by vector using method Multiply. (A.Multiply(vec, vec))");
      MathDisplay.WriteLine(vector.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Multiply vector by matrix (left-multiply)
      // 1. Using operator "*"
      resultV = vector * matrixA;
      MathDisplay.WriteLine(@"Multiply vector by matrix using operator *. (result = vec * A)");
      MathDisplay.WriteLine(resultV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using LeftMultiply method and getting result into different vector instance
      resultV = (DenseVector)matrixA.LeftMultiply(vector);
      MathDisplay.WriteLine(@"Multiply vector by matrix using method LeftMultiply. (result = A.LeftMultiply(vec))");
      MathDisplay.WriteLine(resultV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Using LeftMultiply method and updating vector itself
      matrixA.LeftMultiply(vector, vector);
      MathDisplay.WriteLine(@"Multiply vector by matrix using method LeftMultiply. (A.LeftMultiply(vec, vec))");
      MathDisplay.WriteLine(vector.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Multiply matrix by matrix
      // 1. Using operator "*"
      resultM = matrixA * matrixB;
      MathDisplay.WriteLine(@"Multiply matrix by matrix using operator *. (result = A * B)");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using Multiply method and getting result into different matrix instance
      resultM = (DenseMatrix)matrixA.Multiply(matrixB);
      MathDisplay.WriteLine(@"Multiply matrix by matrix using method Multiply. (result = A.Multiply(B))");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Using Multiply method and updating matrix itself
      matrixA.Multiply(matrixB, matrixA);
      MathDisplay.WriteLine(@"Multiply matrix by matrix using method Multiply. (A.Multiply(B, A))");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Pointwise multiplies matrix with another matrix
      // 1. Using PointwiseMultiply method and getting result into different matrix instance
      resultM = (DenseMatrix)matrixA.PointwiseMultiply(matrixB);
      MathDisplay.WriteLine(@"Pointwise multiplies matrix with another matrix using method PointwiseMultiply. (result = A.PointwiseMultiply(B))");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using PointwiseMultiply method and updating matrix itself
      matrixA.PointwiseMultiply(matrixB, matrixA);
      MathDisplay.WriteLine(@"Pointwise multiplies matrix with another matrix using method PointwiseMultiply. (A.PointwiseMultiply(B, A))");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Pointwise divide matrix with another matrix
      // 1. Using PointwiseDivide method and getting result into different matrix instance
      resultM = (DenseMatrix)matrixA.PointwiseDivide(matrixB);
      MathDisplay.WriteLine(@"Pointwise divide matrix with another matrix using method PointwiseDivide. (result = A.PointwiseDivide(B))");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using PointwiseDivide method and updating matrix itself
      matrixA.PointwiseDivide(matrixB, matrixA);
      MathDisplay.WriteLine(@"Pointwise divide matrix with another matrix using method PointwiseDivide. (A.PointwiseDivide(B, A))");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Addition
      // 1. Using operator "+"
      resultM = matrixA + matrixB;
      MathDisplay.WriteLine(@"Add matrices using operator +. (result = A + B)");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using Add method and getting result into different matrix instance
      resultM = (DenseMatrix)matrixA.Add(matrixB);
      MathDisplay.WriteLine(@"Add matrices using method Add. (result = A.Add(B))");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Using Add method and updating matrix itself
      matrixA.Add(matrixB, matrixA);
      MathDisplay.WriteLine(@"Add matrices using method Add. (A.Add(B, A))");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Subtraction
      // 1. Using operator "-"
      resultM = matrixA - matrixB;
      MathDisplay.WriteLine(@"Subtract matrices using operator -. (result = A - B)");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using Subtract method and getting result into different matrix instance
      resultM = (DenseMatrix)matrixA.Subtract(matrixB);
      MathDisplay.WriteLine(@"Subtract matrices using method Subtract. (result = A.Subtract(B))");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Using Subtract method and updating matrix itself
      matrixA.Subtract(matrixB, matrixA);
      MathDisplay.WriteLine(@"Subtract matrices using method Subtract. (A.Subtract(B, A))");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Divide by scalar
      // 1. Using Divide method and getting result into different matrix instance
      resultM = (DenseMatrix)matrixA.Divide(3.0);
      MathDisplay.WriteLine(@"Divide matrix by scalar using method Divide. (result = A.Divide(3.0))");
      MathDisplay.WriteLine(resultM.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using Divide method and updating matrix itself
      matrixA.Divide(3.0, matrixA);
      MathDisplay.WriteLine(@"Divide matrix by scalar using method Divide. (A.Divide(3.0, A))");
      MathDisplay.WriteLine(matrixA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();



      MathDisplay.WriteLine("<b>Matrix initialisation </b>");

      // 1. Initialize a new instance of the matrix from a 2D array. This constructor will allocate a completely new memory block for storing the dense matrix.
      var matrix1 = DenseMatrix.OfArray(new[,] { { 1.0, 2.0, 3.0 }, { 4.0, 5.0, 6.0 } });

      // 2. Initialize a new instance of the empty square matrix with a given order.
      var matrix2 = new DenseMatrix(3);

      // 3. Initialize a new instance of the empty matrix with a given size.
      var matrix3 = new DenseMatrix(2, 3);

      // 4. Initialize a new instance of the matrix with all entries set to a particular value.
      var matrix4 = DenseMatrix.Create(2, 3, (i, j) => 3.0);

      // 4. Initialize a new instance of the matrix from a one dimensional array. This array should store the matrix in column-major order. 
      var matrix5 = new DenseMatrix(2, 3, new[] { 1.0, 4.0, 2.0, 5.0, 3.0, 6.0 });

      // 5. Initialize a square matrix with all zero's except for ones on the diagonal. Identity matrix (http://en.wikipedia.org/wiki/Identity_matrix).
      var matrixI = DenseMatrix.CreateIdentity(5);


      MathDisplay.WriteLine(@"Matrix 1");
      MathDisplay.WriteLine(matrix1.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      MathDisplay.WriteLine(@"Matrix 2");
      MathDisplay.WriteLine(matrix2.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      MathDisplay.WriteLine(@"Matrix 3");
      MathDisplay.WriteLine(matrix3.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      MathDisplay.WriteLine(@"Matrix 4");
      MathDisplay.WriteLine(matrix4.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      MathDisplay.WriteLine(@"Matrix 5");
      MathDisplay.WriteLine(matrix5.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      MathDisplay.WriteLine(@"Identity matrix");
      MathDisplay.WriteLine(matrixI.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();


      MathDisplay.WriteLine("<b>Matrix norms</b>");

      // Create square matrix
      matrix = DenseMatrix.OfArray(new[,] { { 1.0, 2.0, 3.0 }, { 6.0, 5.0, 4.0 }, { 8.0, 9.0, 7.0 } });
      MathDisplay.WriteLine(@"Initial square matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 1. 1-norm of the matrix
      MathDisplay.WriteLine(@"1. 1-norm of the matrix");
      MathDisplay.WriteLine(matrix.L1Norm().ToString());
      MathDisplay.WriteLine();

      // 2. 2-norm of the matrix
      MathDisplay.WriteLine(@"2. 2-norm of the matrix");
      MathDisplay.WriteLine(matrix.L2Norm().ToString());
      MathDisplay.WriteLine();

      // 3. Frobenius norm of the matrix
      MathDisplay.WriteLine(@"3. Frobenius norm of the matrix");
      MathDisplay.WriteLine(matrix.FrobeniusNorm().ToString());
      MathDisplay.WriteLine();

      // 4. Infinity norm of the matrix
      MathDisplay.WriteLine(@"4. Infinity norm of the matrix");
      MathDisplay.WriteLine(matrix.InfinityNorm().ToString());
      MathDisplay.WriteLine();

      // 5. Normalize matrix columns
      MathDisplay.WriteLine(@"5. Normalize matrix columns: before normalize");
      foreach(var keyValuePair in matrix.EnumerateColumnsIndexed()) {
        MathDisplay.WriteLine(@"Column {0} 2-nd norm is: {1}", keyValuePair.Item1, keyValuePair.Item2.L2Norm());
      }

      MathDisplay.WriteLine();
      var normalized = matrix.NormalizeColumns(2);
      MathDisplay.WriteLine(@"5. Normalize matrix columns: after normalize");
      foreach(var keyValuePair in normalized.EnumerateColumnsIndexed()) {
        MathDisplay.WriteLine(@"Column {0} 2-nd norm is: {1}", keyValuePair.Item1, keyValuePair.Item2.L2Norm());
      }

      MathDisplay.WriteLine();

      // 6. Normalize matrix columns
      MathDisplay.WriteLine(@"6. Normalize matrix rows: before normalize");
      foreach(var keyValuePair in matrix.EnumerateRowsIndexed()) {
        MathDisplay.WriteLine(@"Row {0} 2-nd norm is: {1}", keyValuePair.Item1, keyValuePair.Item2.L2Norm());
      }

      MathDisplay.WriteLine();
      normalized = matrix.NormalizeRows(2);
      MathDisplay.WriteLine(@"6. Normalize matrix rows: after normalize");
      foreach(var keyValuePair in normalized.EnumerateRowsIndexed()) {
        MathDisplay.WriteLine(@"Row {0} 2-nd norm is: {1}", keyValuePair.Item1, keyValuePair.Item2.L2Norm());
      }



      MathDisplay.WriteLine("<b>Matrix row/column operations</b>");

      // Format matrix output to console
      formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
      formatProvider.TextInfo.ListSeparator = " ";

      // Create square matrix
      matrix = new DenseMatrix(5);
      k = 0;
      for(var i = 0; i < matrix.RowCount; i++) {
        for(var j = 0; j < matrix.ColumnCount; j++) {
          matrix[i, j] = k++;
        }
      }

      MathDisplay.WriteLine(@"Initial matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create vector
      vector = new DenseVector(new[] { 50.0, 51.0, 52.0, 53.0, 54.0 });
      MathDisplay.WriteLine(@"Sample vector");
      MathDisplay.WriteLine(vector.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 1. Insert new column
      var result = matrix.InsertColumn(3, vector);
      MathDisplay.WriteLine(@"1. Insert new column");
      MathDisplay.WriteLine(result.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Insert new row
      result = matrix.InsertRow(3, vector);
      MathDisplay.WriteLine(@"2. Insert new row");
      MathDisplay.WriteLine(result.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Set column values
      matrix.SetColumn(2, vector);
      MathDisplay.WriteLine(@"3. Set column values");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Set row values. 
      matrix.SetRow(3, (double[])vector);
      MathDisplay.WriteLine(@"4. Set row values");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 5. Set diagonal values. SetRow/SetColumn/SetDiagonal accepts Vector and double[] as input parameter
      matrix.SetDiagonal(new[] { 5.0, 4.0, 3.0, 2.0, 1.0 });
      MathDisplay.WriteLine(@"5. Set diagonal values");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 6. Set submatrix values
      matrix.SetSubMatrix(1, 3, 1, 3, DenseMatrix.CreateIdentity(3));
      MathDisplay.WriteLine(@"6. Set submatrix values");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Permutations. 
      // Initialize a new instance of the Permutation class. An array represents where each integer is permuted too: 
      // indices[i] represents that integer "i" is permuted to location indices[i]
      var permutations = new Permutation(new[] { 0, 1, 3, 2, 4 });

      // 7. Permute rows 3 and 4
      matrix.PermuteRows(permutations);
      MathDisplay.WriteLine(@"7. Permute rows 3 and 4");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 8. Permute columns 1 and 2, 3 and 5
      permutations = new Permutation(new[] { 1, 0, 4, 3, 2 });
      matrix.PermuteColumns(permutations);
      MathDisplay.WriteLine(@"8. Permute columns 1 and 2, 3 and 5");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 9. Concatenate the matrix with the given matrix
      var append = matrix.Append(matrix);

      // Concatenate into result matrix
      matrix.Append(matrix, append);
      MathDisplay.WriteLine(@"9. Append matrix to matrix");
      MathDisplay.WriteLine(append.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 10. Stack the matrix on top of the given matrix matrix
      var stack = matrix.Stack(matrix);

      // Stack into result matrix
      matrix.Stack(matrix, stack);
      MathDisplay.WriteLine(@"10. Stack the matrix on top of the given matrix matrix");
      MathDisplay.WriteLine(stack.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 11. Diagonally stack the matrix on top of the given matrix matrix
      var diagoinalStack = matrix.DiagonalStack(matrix);

      // Diagonally stack into result matrix
      matrix.DiagonalStack(matrix, diagoinalStack);
      MathDisplay.WriteLine(@"11. Diagonally stack the matrix on top of the given matrix matrix");
      MathDisplay.WriteLine(diagoinalStack.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();
    


      // <seealso cref="http://reference.wolfram.com/mathematica/ref/Det.html">The determinant of the square matrix</seealso>
      // <seealso cref="http://reference.wolfram.com/mathematica/ref/Tr.html">The trace of the matrix</seealso>
      // <seealso cref="http://reference.wolfram.com/mathematica/ref/MatrixRank.html">The rank of the matrix</seealso>
      MathDisplay.WriteLine("<b>Special numbers associated with square matrices</b>");

      // Create random square matrix
      matrix = new DenseMatrix(5);
      var rnd = new Random(1); 
      for(var i = 0; i < matrix.RowCount; i++) {
        for(var j = 0; j < matrix.ColumnCount; j++) {
          matrix[i, j] = rnd.NextDouble();
        }
      }

      MathDisplay.WriteLine(@"Initial matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 1. Determinant
      MathDisplay.WriteLine(@"1. Determinant");
      MathDisplay.WriteLine(matrix.Determinant().ToString());
      MathDisplay.WriteLine();

      // 2. Rank
      MathDisplay.WriteLine(@"2. Rank");
      MathDisplay.WriteLine(matrix.Rank().ToString());
      MathDisplay.WriteLine();

      // 3. Condition number
      MathDisplay.WriteLine(@"2. Condition number");
      MathDisplay.WriteLine(matrix.ConditionNumber().ToString());
      MathDisplay.WriteLine();

      // 4. Trace
      MathDisplay.WriteLine(@"4. Trace");
      MathDisplay.WriteLine(matrix.Trace().ToString());
      MathDisplay.WriteLine();


      // <seealso cref="http://reference.wolfram.com/mathematica/ref/Transpose.html">Transpose</seealso>
      // <seealso cref="http://reference.wolfram.com/mathematica/ref/Inverse.html">Inverse</seealso>
      // <seealso cref="http://en.wikipedia.org/wiki/Transpose">Transpose</seealso>
      // <seealso cref="http://en.wikipedia.org/wiki/Invertible_matrix">Invertible matrix</seealso>
      MathDisplay.WriteLine("<b>Special numbers associated with square matrices</b>");

      // Create random square matrix
      matrix = new DenseMatrix(5);
      rnd = new Random(1);
      for(var i = 0; i < matrix.RowCount; i++) {
        for(var j = 0; j < matrix.ColumnCount; j++) {
          matrix[i, j] = rnd.NextDouble();
        }
      }

      MathDisplay.WriteLine(@"Initial matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 1. Get matrix inverse
      var inverse = matrix.Inverse();
      MathDisplay.WriteLine(@"1. Matrix inverse");
      MathDisplay.WriteLine(inverse.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Matrix multiplied by its inverse gives identity matrix
      var identity = matrix * inverse;
      MathDisplay.WriteLine(@"2. Matrix multiplied by its inverse");
      MathDisplay.WriteLine(identity.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Get matrix transpose
      var transpose = matrix.Transpose();
      MathDisplay.WriteLine(@"3. Matrix transpose");
      MathDisplay.WriteLine(transpose.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Get orthogonal  matrix, i.e. do QR decomposition and get matrix Q
      var orthogonal = matrix.QR().Q;
      MathDisplay.WriteLine(@"4. Orthogonal  matrix");
      MathDisplay.WriteLine(orthogonal.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 5. Transpose and multiply orthogonal matrix by iteslf gives identity matrix
      identity = orthogonal.TransposeAndMultiply(orthogonal);
      MathDisplay.WriteLine(@"Transpose and multiply orthogonal matrix by iteslf");
      MathDisplay.WriteLine(identity.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();


      // <seealso cref="http://en.wikipedia.org/wiki/Triangular_matrix">Triangular matrix</seealso>
      MathDisplay.WriteLine("<b>Triangular matrices</b>");

      // Create square matrix
      matrix = new DenseMatrix(10);
      k = 0;
      for(var i = 0; i < matrix.RowCount; i++) {
        for(var j = 0; j < matrix.ColumnCount; j++) {
          matrix[i, j] = k++;
        }
      }

      MathDisplay.WriteLine(@"Initial square matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 1. Retrieve a new matrix containing the lower triangle of the matrix
      var lower = matrix.LowerTriangle();

      // Puts the lower triangle of the matrix into the result matrix.
      matrix.LowerTriangle(lower);
      MathDisplay.WriteLine(@"1. Lower triangle of the matrix");
      MathDisplay.WriteLine(lower.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Retrieve a new matrix containing the upper triangle of the matrix
      var upper = matrix.UpperTriangle();

      // Puts the upper triangle of the matrix into the result matrix.
      matrix.UpperTriangle(lower);
      MathDisplay.WriteLine(@"2. Upper triangle of the matrix");
      MathDisplay.WriteLine(upper.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Retrieve a new matrix containing the strictly lower triangle of the matrix
      var strictlylower = matrix.StrictlyLowerTriangle();

      // Puts the strictly lower triangle of the matrix into the result matrix.
      matrix.StrictlyLowerTriangle(strictlylower);
      MathDisplay.WriteLine(@"3. Strictly lower triangle of the matrix");
      MathDisplay.WriteLine(strictlylower.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Retrieve a new matrix containing the strictly upper triangle of the matrix
      var strictlyupper = matrix.StrictlyUpperTriangle();

      // Puts the strictly upper triangle of the matrix into the result matrix.
      matrix.StrictlyUpperTriangle(strictlyupper);
      MathDisplay.WriteLine(@"4. Strictly upper triangle of the matrix");
      MathDisplay.WriteLine(strictlyupper.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();
    
    
      // <seealso cref="http://en.wikipedia.org/wiki/Euclidean_vector#Scalar_multiplication">Multiply vector by scalar</seealso>
      // <seealso cref="http://en.wikipedia.org/wiki/Euclidean_vector#Dot_product">Multiply vector by vector (compute the dot product between two vectors)</seealso>
      // <seealso cref="http://en.wikipedia.org/wiki/Euclidean_vector#Addition_and_subtraction">Vector addition and subtraction</seealso>
      // <seealso cref="http://en.wikipedia.org/wiki/Outer_product">Outer Product of two vectors</seealso>
      MathDisplay.WriteLine("<b>Basic vector operations</b>");

      // Create vector "X"
      var vectorX = new DenseVector(new[] { 1.0, 2.0, 3.0, 4.0, 5.0 });
      MathDisplay.WriteLine(@"Vector X");
      MathDisplay.WriteLine(vectorX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Create vector "Y"
      var vectorY = new DenseVector(new[] { 5.0, 4.0, 3.0, 2.0, 1.0 });
      MathDisplay.WriteLine(@"Vector Y");
      MathDisplay.WriteLine(vectorY.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Multiply vector by scalar
      // 1. Using Multiply method and getting result into different vector instance
      var resultVV = vectorX.Multiply(3.0);
      MathDisplay.WriteLine(@"Multiply vector by scalar using method Multiply. (result = X.Multiply(3.0))");
      MathDisplay.WriteLine(resultVV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using operator "*"
      resultVV = 3.0 * vectorX;
      MathDisplay.WriteLine(@"Multiply vector by scalar using operator *. (result = 3.0 * X)");
      MathDisplay.WriteLine(resultVV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Using Multiply method and updating vector itself
      vectorX.Multiply(3.0, vectorX);
      MathDisplay.WriteLine(@"Multiply vector by scalar using method Multiply. (X.Multiply(3.0, X))");
      MathDisplay.WriteLine(vectorX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Multiply vector by vector (compute the dot product between two vectors)
      // 1. Using operator "*"
      var dotProduct = vectorX * vectorY;
      MathDisplay.WriteLine(@"Dot product between two vectors using operator *. (result = X * Y)");
      MathDisplay.WriteLine(dotProduct.ToString());
      MathDisplay.WriteLine();

      // 2. Using DotProduct method and getting result into different vector instance
      dotProduct = vectorX.DotProduct(vectorY);
      MathDisplay.WriteLine(@"Dot product between two vectors using method DotProduct. (result = X.DotProduct(Y))");
      MathDisplay.WriteLine(dotProduct.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Pointwise multiplies vector with another vector
      // 1. Using PointwiseMultiply method and getting result into different vector instance
      resultVV = vectorX.PointwiseMultiply(vectorY);
      MathDisplay.WriteLine(@"Pointwise multiplies vector with another vector using method PointwiseMultiply. (result = X.PointwiseMultiply(Y))");
      MathDisplay.WriteLine(resultVV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using PointwiseMultiply method and updating vector itself
      vectorX.PointwiseMultiply(vectorY, vectorX);
      MathDisplay.WriteLine(@"Pointwise multiplies vector with another vector using method PointwiseMultiply. (X.PointwiseMultiply(Y, X))");
      MathDisplay.WriteLine(vectorX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Pointwise divide vector with another vector
      // 1. Using PointwiseDivide method and getting result into different vector instance
      resultVV = vectorX.PointwiseDivide(vectorY);
      MathDisplay.WriteLine(@"Pointwise divide vector with another vector using method PointwiseDivide. (result = X.PointwiseDivide(Y))");
      MathDisplay.WriteLine(resultVV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using PointwiseDivide method and updating vector itself
      vectorX.PointwiseDivide(vectorY, vectorX);
      MathDisplay.WriteLine(@"Pointwise divide vector with another vector using method PointwiseDivide. (X.PointwiseDivide(Y, X))");
      MathDisplay.WriteLine(vectorX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Addition
      // 1. Using operator "+"
      resultV = vectorX + vectorY;
      MathDisplay.WriteLine(@"Add vectors using operator +. (result = X + Y)");
      MathDisplay.WriteLine(resultV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using Add method and getting result into different vector instance
      resultVV = vectorX.Add(vectorY);
      MathDisplay.WriteLine(@"Add vectors using method Add. (result = X.Add(Y))");
      MathDisplay.WriteLine(resultVV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Using Add method and updating vector itself
      vectorX.Add(vectorY, vectorX);
      MathDisplay.WriteLine(@"Add vectors using method Add. (X.Add(Y, X))");
      MathDisplay.WriteLine(vectorX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Subtraction
      // 1. Using operator "-"
      resultVV = vectorX - vectorY;
      MathDisplay.WriteLine(@"Subtract vectors using operator -. (result = X - Y)");
      MathDisplay.WriteLine(resultVV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using Subtract method and getting result into different vector instance
      resultVV = vectorX.Subtract(vectorY);
      MathDisplay.WriteLine(@"Subtract vectors using method Subtract. (result = X.Subtract(Y))");
      MathDisplay.WriteLine(resultVV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Using Subtract method and updating vector itself
      vectorX.Subtract(vectorY, vectorX);
      MathDisplay.WriteLine(@"Subtract vectors using method Subtract. (X.Subtract(Y, X))");
      MathDisplay.WriteLine(vectorX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Divide by scalar
      // 1. Using Divide method and getting result into different vector instance
      resultVV = vectorX.Divide(3.0);
      MathDisplay.WriteLine(@"Divide vector by scalar using method Divide. (result = A.Divide(3.0))");
      MathDisplay.WriteLine(resultVV.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using Divide method and updating vector itself
      vectorX.Divide(3.0, vectorX);
      MathDisplay.WriteLine(@"Divide vector by scalar using method Divide. (X.Divide(3.0, X))");
      MathDisplay.WriteLine(vectorX.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Outer Product of two vectors
      // 1. Using instanse method OuterProduct
      var resultMv = vectorX.OuterProduct(vectorY);
      MathDisplay.WriteLine(@"Outer Product of two vectors using method OuterProduct. (X.OuterProduct(Y))");
      MathDisplay.WriteLine(resultMv.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Using static method of the Vector class
      resultMv = Vector.OuterProduct(vectorX, vectorY);
      MathDisplay.WriteLine(@"Outer Product of two vectors using method OuterProduct. (Vector.OuterProduct(X,Y))");
      MathDisplay.WriteLine(resultMv.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();



      MathDisplay.WriteLine("<b>Vector data access, copying and conversions</b>");

      // Create new empty vector
      var vectorA = new DenseVector(10);
      MathDisplay.WriteLine(@"Empty vector A");
      MathDisplay.WriteLine(vectorA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 1. Fill vector by data using indexer []
      for(var i = 0; i < vectorA.Count; i++) {
        vectorA[i] = i;
      }

      MathDisplay.WriteLine(@"1. Fill vector by data using indexer []");
      MathDisplay.WriteLine(vectorA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Fill vector by data using SetValues method
      vectorA.SetValues(new[] { 9.0, 8.0, 7.0, 6.0, 5.0, 4.0, 3.0, 2.0, 1.0, 0.0 });
      MathDisplay.WriteLine(@"2. Fill vector by data using SetValues method");
      MathDisplay.WriteLine(vectorA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Convert Vector to double[]
      var dataV = vectorA.ToArray();
      MathDisplay.WriteLine(@"3. Convert vector to double array");
      for(var i = 0; i < dataV.Length; i++) {
        MathDisplay.Write(dataV[i].ToString("#0.00\t", formatProvider) + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 4. Convert Vector to column matrix. A matrix based on this vector in column form (one single column)
      var columnMatrix = vectorA.ToColumnMatrix();
      MathDisplay.WriteLine(@"4. Convert vector to column matrix");
      MathDisplay.WriteLine(columnMatrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 5. Convert Vector to row matrix. A matrix based on this vector in row form (one single row)
      var rowMatrix = vectorA.ToRowMatrix();
      MathDisplay.WriteLine(@"5. Convert vector to row matrix");
      MathDisplay.WriteLine(rowMatrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 6. Clone vector
      var cloneA = vectorA.Clone();
      MathDisplay.WriteLine(@"6. Clone vector");
      MathDisplay.WriteLine(cloneA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 7. Clear vector
      cloneA.Clear();
      MathDisplay.WriteLine(@"7. Clear vector");
      MathDisplay.WriteLine(cloneA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 8. Copy part of vector into another vector. If you need to copy all data then use CopoTy(vector) method.
      vectorA.CopySubVectorTo(cloneA, 3, 3, 4);
      MathDisplay.WriteLine(@"8. Copy part of vector into another vector");
      MathDisplay.WriteLine(cloneA.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 9. Get part of vector as another vector
      var subvector = vectorA.SubVector(0, 5);
      MathDisplay.WriteLine(@"9. Get subvector");
      MathDisplay.WriteLine(subvector.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 10. Enumerator usage
      MathDisplay.WriteLine(@"10. Enumerator usage");
      foreach(var value in vectorA) {
        MathDisplay.Write(value.ToString() + @" ");
      }
      MathDisplay.FlushBuffer();

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 11. Indexed enumerator usage
      MathDisplay.WriteLine(@"11. Enumerator usage");
      foreach(var value in vectorA.EnumerateIndexed(Zeros.Include)) {
        MathDisplay.WriteLine(@"Index = {0}; Value = {1}", value.Item1, value.Item2.ToString("#0.00\t", formatProvider));
      }

      MathDisplay.WriteLine();
      MathDisplay.WriteLine();

      // 12. Indexed non-zero enumerator usage
      MathDisplay.WriteLine(@"11. Non-Zero Enumerator usage");
      foreach(var value in vectorA.EnumerateIndexed(Zeros.AllowSkip)) {
        MathDisplay.WriteLine(@"Index = {0}; Value = {1}", value.Item1, value.Item2.ToString("#0.00\t", formatProvider));
      }

      MathDisplay.WriteLine();


      MathDisplay.WriteLine("<b>Vector initialisation</b>");
      // 1. Initialize a new instance of the empty vector with a given size
      var vector1 = Vector<double>.Build.Dense(5);

      // 2. Initialize a new instance of the vector with a given size and each element set to the given value
      var vector2 = Vector<double>.Build.Dense(5, i => i + 3.0);

      // 3. Initialize a new instance of the vector from an array.
      var vector3 = Vector<double>.Build.Dense(new[] { 1.0, 2.0, 3.0, 4.0, 5.0 });

      // 4. Initialize a new instance of the vector by copying the values from another.
      var vector4 = Vector<double>.Build.DenseOfVector(vector3);

      MathDisplay.WriteLine(@"Vector 1");
      MathDisplay.WriteLine(vector1.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      MathDisplay.WriteLine(@"Vector 2");
      MathDisplay.WriteLine(vector2.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      MathDisplay.WriteLine(@"Vector 3");
      MathDisplay.WriteLine(vector3.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      MathDisplay.WriteLine(@"Vector 4");
      MathDisplay.WriteLine(vector4.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

    }

  }

}
