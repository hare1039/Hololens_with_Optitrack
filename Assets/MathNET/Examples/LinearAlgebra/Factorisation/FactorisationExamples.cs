using System;
using System.Globalization;
using MathNet.Numerics.LinearAlgebra.Double;


namespace MathNet.Examples {

  public class FactorisationExamples : MathNetExampleBase {

    public override void ExecuteExample() {

      // <seealso cref="http://en.wikipedia.org/wiki/Cholesky_decomposition">Cholesky decomposition</seealso>
      MathDisplay.WriteLine("<b>Cholesky factorisation</b>");

      // Format matrix output to console
      var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
      formatProvider.TextInfo.ListSeparator = " ";

      // Create square, symmetric, positive definite matrix
      var matrix = DenseMatrix.OfArray(new[,] { { 2.0, 1.0 }, { 1.0, 2.0 } });
      MathDisplay.WriteLine(@"Initial square, symmetric, positive definite matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Perform Cholesky decomposition
      var cholesky = matrix.Cholesky();
      MathDisplay.WriteLine(@"Perform Cholesky decomposition");

      // 1. Lower triangular form of the Cholesky matrix
      MathDisplay.WriteLine(@"1. Lower triangular form of the Cholesky matrix");
      MathDisplay.WriteLine(cholesky.Factor.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Reconstruct initial matrix: A = L * LT
      var reconstruct = cholesky.Factor * cholesky.Factor.Transpose();
      MathDisplay.WriteLine(@"2. Reconstruct initial matrix: A = L*LT");
      MathDisplay.WriteLine(reconstruct.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Get determinant of the matrix
      MathDisplay.WriteLine(@"3. Determinant of the matrix");
      MathDisplay.WriteLine(cholesky.Determinant.ToString());
      MathDisplay.WriteLine();

      // 4. Get log determinant of the matrix
      MathDisplay.WriteLine(@"4. Log determinant of the matrix");
      MathDisplay.WriteLine(cholesky.DeterminantLn.ToString());
      MathDisplay.WriteLine();


      // <seealso cref="http://en.wikipedia.org/wiki/Eigenvalue,_eigenvector_and_eigenspace">EVD decomposition</seealso>
      MathDisplay.WriteLine("<b>Eigenvalue, eigenvector and eigenspace factorisation</b>");

      // Create square symmetric matrix
      matrix = DenseMatrix.OfArray(new[,] { { 1.0, 2.0, 3.0 }, { 2.0, 1.0, 4.0 }, { 3.0, 4.0, 1.0 } });
      MathDisplay.WriteLine(@"Initial square symmetric matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Perform eigenvalue decomposition of symmetric matrix
      var evd = matrix.Evd();
      MathDisplay.WriteLine(@"Perform eigenvalue decomposition of symmetric matrix");

      // 1. Eigen vectors
      MathDisplay.WriteLine(@"1. Eigen vectors");
      MathDisplay.WriteLine(evd.EigenVectors.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Eigen values as a complex vector
      MathDisplay.WriteLine(@"2. Eigen values as a complex vector");
      MathDisplay.WriteLine(evd.EigenValues.ToString("N", formatProvider));
      MathDisplay.WriteLine();

      // 3. Eigen values as the block diagonal matrix
      MathDisplay.WriteLine(@"3. Eigen values as the block diagonal matrix");
      MathDisplay.WriteLine(evd.D.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Multiply V by its transpose VT
      var identity = evd.EigenVectors.TransposeAndMultiply(evd.EigenVectors);
      MathDisplay.WriteLine(@"4. Multiply V by its transpose VT: V*VT = I");
      MathDisplay.WriteLine(identity.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 5. Reconstruct initial matrix: A = V*D*V'
      reconstruct = evd.EigenVectors * evd.D * evd.EigenVectors.Transpose();
      MathDisplay.WriteLine(@"5. Reconstruct initial matrix: A = V*D*V'");
      MathDisplay.WriteLine(reconstruct.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 6. Determinant of the matrix
      MathDisplay.WriteLine(@"6. Determinant of the matrix");
      MathDisplay.WriteLine(evd.Determinant.ToString());
      MathDisplay.WriteLine();

      // 7. Rank of the matrix
      MathDisplay.WriteLine(@"7. Rank of the matrix");
      MathDisplay.WriteLine(evd.Rank.ToString());
      MathDisplay.WriteLine();

      // Fill matrix by random values
      var rnd = new Random(1);
      for(var i = 0; i < matrix.RowCount; i++) {
        for(var j = 0; j < matrix.ColumnCount; j++) {
          matrix[i, j] = rnd.NextDouble();
        }
      }

      MathDisplay.WriteLine(@"Fill matrix by random values");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Perform eigenvalue decomposition of non-symmetric matrix
      evd = matrix.Evd();
      MathDisplay.WriteLine(@"Perform eigenvalue decomposition of non-symmetric matrix");

      // 8. Eigen vectors
      MathDisplay.WriteLine(@"8. Eigen vectors");
      MathDisplay.WriteLine(evd.EigenVectors.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 9. Eigen values as a complex vector
      MathDisplay.WriteLine(@"9. Eigen values as a complex vector");
      MathDisplay.WriteLine(evd.EigenValues.ToString("N", formatProvider));
      MathDisplay.WriteLine();

      // 10. Eigen values as the block diagonal matrix
      MathDisplay.WriteLine(@"10. Eigen values as the block diagonal matrix");
      MathDisplay.WriteLine(evd.D.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 11. Multiply A * V
      var av = matrix * evd.EigenVectors;
      MathDisplay.WriteLine(@"11. Multiply A * V");
      MathDisplay.WriteLine(av.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 12. Multiply V * D
      var vd = evd.EigenVectors * evd.D;
      MathDisplay.WriteLine(@"12. Multiply V * D");
      MathDisplay.WriteLine(vd.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 13. Reconstruct non-symmetriv matrix A = V * D * Vinverse
      reconstruct = evd.EigenVectors * evd.D * evd.EigenVectors.Inverse();
      MathDisplay.WriteLine(@"13. Reconstruct non-symmetriv matrix A = V * D * Vinverse");
      MathDisplay.WriteLine(reconstruct.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 14. Determinant of the matrix
      MathDisplay.WriteLine(@"14. Determinant of the matrix");
      MathDisplay.WriteLine(evd.Determinant.ToString());
      MathDisplay.WriteLine();

      // 15. Rank of the matrix
      MathDisplay.WriteLine(@"15. Rank of the matrix");
      MathDisplay.WriteLine(evd.Rank.ToString());
      MathDisplay.WriteLine();


      // <seealso cref="http://en.wikipedia.org/wiki/LU_decomposition">LU decomposition</seealso>
      // <seealso cref="http://en.wikipedia.org/wiki/Invertible_matrix">Invertible matrix</seealso>
      MathDisplay.WriteLine("<b>LU factorisation</b>");

      // Create square matrix
      matrix = DenseMatrix.OfArray(new[,] { { 1.0, 2.0 }, { 3.0, 4.0 } });
      MathDisplay.WriteLine(@"Initial square matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Perform LU decomposition
      var lu = matrix.LU();
      MathDisplay.WriteLine(@"Perform LU decomposition");

      // 1. Lower triangular factor
      MathDisplay.WriteLine(@"1. Lower triangular factor");
      MathDisplay.WriteLine(lu.L.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Upper triangular factor
      MathDisplay.WriteLine(@"2. Upper triangular factor");
      MathDisplay.WriteLine(lu.U.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Permutations applied to LU factorization
      MathDisplay.WriteLine(@"3. Permutations applied to LU factorization");
      for(var i = 0; i < lu.P.Dimension; i++) {
        if(lu.P[i] > i) {
          MathDisplay.WriteLine(@"Row {0} permuted with row {1}", lu.P[i], i);
        }
      }

      MathDisplay.WriteLine();

      // 4. Reconstruct initial matrix: PA = L * U
      reconstruct = lu.L * lu.U;

      // The rows of the reconstructed matrix should be permuted to get the initial matrix
      reconstruct.PermuteRows(lu.P.Inverse());
      MathDisplay.WriteLine(@"4. Reconstruct initial matrix: PA = L*U");
      MathDisplay.WriteLine(reconstruct.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 5. Get the determinant of the matrix
      MathDisplay.WriteLine(@"5. Determinant of the matrix");
      MathDisplay.WriteLine(lu.Determinant.ToString());
      MathDisplay.WriteLine();

      // 6. Get the inverse of the matrix
      var matrixInverse = lu.Inverse();
      MathDisplay.WriteLine(@"6. Inverse of the matrix");
      MathDisplay.WriteLine(matrixInverse.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 7. Matrix multiplied by its inverse 
      identity = matrix * matrixInverse;
      MathDisplay.WriteLine(@"7. Matrix multiplied by its inverse ");
      MathDisplay.WriteLine(identity.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();


      // QR factorization example. Any real square matrix A (m x n) may be decomposed as A = QR where Q is an 
      // orthogonal matrix (m x m)
      // (its columns are orthogonal unit vectors meaning QTQ = I) and R (m x n) is an upper triangular matrix 
      // (also called right triangular matrix).
      // In this example two methods for actually computing the QR decomposition presented: by means of the 
      // Gram–Schmidt process and Householder transformations.
      // <seealso cref="http://reference.wolfram.com/mathematica/ref/QRDecomposition.html"/>
      MathDisplay.WriteLine("<b>QR factorisation</b>");

      // Create 3 x 2 matrix
      matrix = DenseMatrix.OfArray(new[,] { { 1.0, 2.0 }, { 3.0, 4.0 }, { 5.0, 6.0 } });
      MathDisplay.WriteLine(@"Initial 3x2 matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Perform QR decomposition (Householder transformations)
      var qr = matrix.QR();
      MathDisplay.WriteLine(@"QR decomposition (Householder transformations)");

      // 1. Orthogonal Q matrix
      MathDisplay.WriteLine(@"1. Orthogonal Q matrix");
      MathDisplay.WriteLine(qr.Q.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Multiply Q matrix by its transpose gives identity matrix
      MathDisplay.WriteLine(@"2. Multiply Q matrix by its transpose gives identity matrix");
      MathDisplay.WriteLine(qr.Q.TransposeAndMultiply(qr.Q).ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Upper triangular factor R
      MathDisplay.WriteLine(@"3. Upper triangular factor R");
      MathDisplay.WriteLine(qr.R.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Reconstruct initial matrix: A = Q * R
      reconstruct = qr.Q * qr.R;
      MathDisplay.WriteLine(@"4. Reconstruct initial matrix: A = Q*R");
      MathDisplay.WriteLine(reconstruct.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Perform QR decomposition (Gram–Schmidt process)
      var gramSchmidt = matrix.GramSchmidt();
      MathDisplay.WriteLine(@"QR decomposition (Gram–Schmidt process)");

      // 5. Orthogonal Q matrix
      MathDisplay.WriteLine(@"5. Orthogonal Q matrix");
      MathDisplay.WriteLine(gramSchmidt.Q.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 6. Multiply Q matrix by its transpose gives identity matrix
      MathDisplay.WriteLine(@"6. Multiply Q matrix by its transpose gives identity matrix");
      MathDisplay.WriteLine((gramSchmidt.Q.Transpose() * gramSchmidt.Q).ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 7. Upper triangular factor R
      MathDisplay.WriteLine(@"7. Upper triangular factor R");
      MathDisplay.WriteLine(gramSchmidt.R.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 8. Reconstruct initial matrix: A = Q * R
      reconstruct = gramSchmidt.Q * gramSchmidt.R;
      MathDisplay.WriteLine(@"8. Reconstruct initial matrix: A = Q*R");
      MathDisplay.WriteLine(reconstruct.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();


      // SVD factorization example. Suppose M is an m-by-n matrix whose entries are real numbers. 
      // Then there exists a factorization of the form M = UΣVT where:
      // - U is an m-by-m unitary matrix;
      // - Σ is m-by-n diagonal matrix with nonnegative real numbers on the diagonal;
      // - VT denotes transpose of V, an n-by-n unitary matrix; 
      // Such a factorization is called a singular-value decomposition of M. A common convention is to order the diagonal 
      // entries Σ(i,i) in descending order. In this case, the diagonal matrix Σ is uniquely determined 
      // by M (though the matrices U and V are not). The diagonal entries of Σ are known as the singular values of M.
      // <seealso cref="http://reference.wolfram.com/mathematica/ref/SingularValueDecomposition.html"/>
      MathDisplay.WriteLine("<b>SVD factorisation</b>");

      // Create square matrix
      matrix = DenseMatrix.OfArray(new[,] { { 4.0, 1.0 }, { 3.0, 2.0 } });
      MathDisplay.WriteLine(@"Initial square matrix");
      MathDisplay.WriteLine(matrix.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // Perform full SVD decomposition
      var svd = matrix.Svd();
      MathDisplay.WriteLine(@"Perform full SVD decomposition");

      // 1. Left singular vectors
      MathDisplay.WriteLine(@"1. Left singular vectors");
      MathDisplay.WriteLine(svd.U.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 2. Singular values as vector
      MathDisplay.WriteLine(@"2. Singular values as vector");
      MathDisplay.WriteLine(svd.S.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 3. Singular values as diagonal matrix
      MathDisplay.WriteLine(@"3. Singular values as diagonal matrix");
      MathDisplay.WriteLine(svd.W.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 4. Right singular vectors
      MathDisplay.WriteLine(@"4. Right singular vectors");
      MathDisplay.WriteLine(svd.VT.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 5. Multiply U matrix by its transpose
      var identinty = svd.U * svd.U.Transpose();
      MathDisplay.WriteLine(@"5. Multiply U matrix by its transpose");
      MathDisplay.WriteLine(identinty.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 6. Multiply V matrix by its transpose
      identinty = svd.VT.TransposeAndMultiply(svd.VT);
      MathDisplay.WriteLine(@"6. Multiply V matrix by its transpose");
      MathDisplay.WriteLine(identinty.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 7. Reconstruct initial matrix: A = U*Σ*VT
      reconstruct = svd.U * svd.W * svd.VT;
      MathDisplay.WriteLine(@"7. Reconstruct initial matrix: A = U*S*VT");
      MathDisplay.WriteLine(reconstruct.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 8. Condition Number of the matrix
      MathDisplay.WriteLine(@"8. Condition Number of the matrix");
      MathDisplay.WriteLine(svd.ConditionNumber.ToString());
      MathDisplay.WriteLine();

      // 9. Determinant of the matrix
      MathDisplay.WriteLine(@"9. Determinant of the matrix");
      MathDisplay.WriteLine(svd.Determinant.ToString());
      MathDisplay.WriteLine();

      // 10. 2-norm of the matrix
      MathDisplay.WriteLine(@"10. 2-norm of the matrix");
      MathDisplay.WriteLine(svd.L2Norm.ToString());
      MathDisplay.WriteLine();

      // 11. Rank of the matrix
      MathDisplay.WriteLine(@"11. Rank of the matrix");
      MathDisplay.WriteLine(svd.Rank.ToString());
      MathDisplay.WriteLine();

      // Perform partial SVD decomposition, without computing the singular U and VT vectors
      svd = matrix.Svd(false);
      MathDisplay.WriteLine(@"Perform partial SVD decomposition, without computing the singular U and VT vectors");

      // 12. Singular values as vector
      MathDisplay.WriteLine(@"12. Singular values as vector");
      MathDisplay.WriteLine(svd.S.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 13. Singular values as diagonal matrix
      MathDisplay.WriteLine(@"13. Singular values as diagonal matrix");
      MathDisplay.WriteLine(svd.W.ToString("#0.00\t", formatProvider));
      MathDisplay.WriteLine();

      // 14. Access to left singular vectors when partial SVD decomposition was performed
      try {
        MathDisplay.WriteLine(@"14. Access to left singular vectors when partial SVD decomposition was performed");
        MathDisplay.WriteLine(svd.U.ToString("#0.00\t", formatProvider));
      } catch(Exception ex) {
        MathDisplay.WriteLine(ex.Message);
        MathDisplay.WriteLine();
      }

      // 15. Access to right singular vectors when partial SVD decomposition was performed
      try {
        MathDisplay.WriteLine(@"15. Access to right singular vectors when partial SVD decomposition was performed");
        MathDisplay.WriteLine(svd.VT.ToString("#0.00\t", formatProvider));
      } catch(Exception ex) {
        MathDisplay.WriteLine(ex.Message);
        MathDisplay.WriteLine();
      }


    }

  }

}
