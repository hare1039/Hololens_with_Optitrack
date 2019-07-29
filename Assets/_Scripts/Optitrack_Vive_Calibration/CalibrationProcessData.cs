using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;



public class CalibrationProcessData : MonoBehaviour {

    public List<Vector3> oriPosition;
    public List<Vector3> targetPosition;
	public List<Vector3> markerRotation;
	public List<Vector3> controllerRotation;

	//Position Calibration Data
    private Vector3 oriPositionCentroid, targetPositionCentroid;

    public Matrix4x4 PositionTransloationMatrix;
    public Matrix4x4 PositionRotationMatrix;
    public Matrix4x4 PositiontransformationMatrix;

    private DenseMatrix PositionrotationDenseMatrix;
    private DenseVector PositiontranslationDenseVector;

	//For output the transformation matrix
	private String PositiontransformationFilename = "Assets/CalibrationData/CalibrationPositionTransformationMatrix.txt";
    private String PositionrotationFilename = "Assets/CalibrationData/CalibrationPositionRotationMatrix.txt";
    private String PositiontranslationFilename = "Assets/CalibrationData/CalibrationPositionTranslationMatrix.txt";


	public CalibrationProcessData()
    {
        this.oriPosition = new List<Vector3>();
        this.targetPosition = new List<Vector3>();
    }

    public void addPositionData(Vector3 markerPos, Vector3 controllerPos)
    {
        oriPosition.Add(markerPos);
        targetPosition.Add(controllerPos);
    }

    public void setPositionData(List<Vector3> oriPos, List<Vector3> targetPos){
        this.oriPosition = oriPos;
        this.targetPosition = targetPos;
    }

    public void calibrateTransformationMatrix()
    {
        findCentroids();
        setRotationMatrix();
        setTranslationMatrix();

        //calculate Position transformation matrix
        PositiontransformationMatrix = new Matrix4x4();
        PositiontransformationMatrix = Matrix4x4.identity;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if (j == 3)
                    PositiontransformationMatrix[i, j] = PositionTransloationMatrix[i, j];
                else
                    PositiontransformationMatrix[i, j] = PositionRotationMatrix[i, j];
            }
        }

		writeMatrixToFile();
    }

    public void loadMatrixFromFile()
    {
        loadTransformationMatrix();
        loadRotationMatrix();
        loadTranslationMatrix();
    }

    private void findCentroids()
    {
		//find the Position Centroid
        oriPositionCentroid = Vector3.zero;
        targetPositionCentroid = Vector3.zero;

        for(int i = 0; i < oriPosition.Count; i++)
        {
            oriPositionCentroid += oriPosition[i];
            targetPositionCentroid += targetPosition[i];
        }

        oriPositionCentroid /= oriPosition.Count;
        targetPositionCentroid /= targetPosition.Count;

	}

    private void setTranslationMatrix()
    {
		//Set Position Translation Matrix
        PositionTransloationMatrix = new Matrix4x4();
        PositionTransloationMatrix = Matrix4x4.identity;

        //Calculate the translation Matrix
        DenseVector MCentroid = new DenseVector(3);
        DenseVector CCentroid = new DenseVector(3);
        MCentroid[0] = oriPositionCentroid[0]; MCentroid[1] = oriPositionCentroid[1]; MCentroid[2] = oriPositionCentroid[2];
        CCentroid[0] = targetPositionCentroid[0]; CCentroid[1] = targetPositionCentroid[1]; CCentroid[2] = targetPositionCentroid[2];
        PositiontranslationDenseVector = (DenseVector)(PositionrotationDenseMatrix.Multiply(-1).Multiply(MCentroid) + CCentroid);

        for (int i = 0; i < 3; i++)
            PositionTransloationMatrix[i, 3] = (float)PositiontranslationDenseVector[i];
	}

    private void setRotationMatrix()
    {
		//Set Position Rotation Matrix
        PositionRotationMatrix = new Matrix4x4();
        PositionRotationMatrix = Matrix4x4.identity;

        //align the centroid
        List<Vector3> newOriPosition = new List<Vector3>(oriPosition);
        Vector3 diff = oriPositionCentroid - targetPositionCentroid;
        for(int i = 0; i < newOriPosition.Count; i++)
            newOriPosition[i] -= diff;

        //slove SVD
        DenseMatrix accumulateMatrix = new DenseMatrix(3,3);
        DenseMatrix markerdiff = new DenseMatrix(3,3);
        DenseMatrix controllerdiff = new DenseMatrix(3,3);
        for (int i = 0; i < targetPosition.Count; i++)
        {
            markerdiff[0,0] = newOriPosition[i].x - targetPositionCentroid.x;
            markerdiff[1,0] = newOriPosition[i].y - targetPositionCentroid.y;
            markerdiff[2,0] = newOriPosition[i].z - targetPositionCentroid.z;

            controllerdiff[0,0] = targetPosition[i].x - targetPositionCentroid.x;
            controllerdiff[1,0] = targetPosition[i].y - targetPositionCentroid.y;
            controllerdiff[2,0] = targetPosition[i].z - targetPositionCentroid.z;

            accumulateMatrix += (DenseMatrix)(markerdiff.TransposeAndMultiply(controllerdiff));

            markerdiff.Clear(); controllerdiff.Clear();
        }

        PositionrotationDenseMatrix = (DenseMatrix)(accumulateMatrix.Svd().VT.Transpose().TransposeAndMultiply(accumulateMatrix.Svd().U));

        //Assign to the rotationMatrix
        for (int i = 0; i < PositionrotationDenseMatrix.RowCount; i++)
            for (int j = 0; j < PositionrotationDenseMatrix.ColumnCount; j++)
                PositionRotationMatrix[i, j] = (float)PositionrotationDenseMatrix[i, j];
	}

    private void loadTransformationMatrix()
    {
        //open the position file
        FileInfo theSourceFile = null;
        StreamReader reader = null;
        theSourceFile = new FileInfo(PositiontransformationFilename);
        reader = theSourceFile.OpenText();
        String text = reader.ReadLine();
        int numOfLine = 0;
        bool endOfLine = false;

        while (!endOfLine)
        {

            if (text != null)
            {
                numOfLine++;
                parseLine(text, numOfLine, 0);
                text = reader.ReadLine();
            }
            else
            {
                endOfLine = true;
                reader.Close();
            }
        }

        print("Position Transformation Matrix" + PositiontransformationMatrix);
	}

    private void loadRotationMatrix()
    {
        //open the Position Rotation Matrix file
        FileInfo theSourceFile = null;
        StreamReader reader = null;
        theSourceFile = new FileInfo(PositionrotationFilename);
        reader = theSourceFile.OpenText();
        String text = reader.ReadLine();
        int numOfLine = 0;
        bool endOfLine = false;

        while (!endOfLine)
        {

            if (text != null)
            {
                numOfLine++;
                parseLine(text, numOfLine, 1);
                text = reader.ReadLine();
            }
            else
            {
                Debug.Log("Read Down\nnumOfLine: " + numOfLine);
                endOfLine = true;
                reader.Close();
            }
        }

        print("Position Rotation Matrix" + PositionRotationMatrix);

	}

    private void loadTranslationMatrix()
    {
        //open the Position Translation Matrix file
        FileInfo theSourceFile = null;
        StreamReader reader = null;
        theSourceFile = new FileInfo(PositiontranslationFilename);
        reader = theSourceFile.OpenText();
        String text = reader.ReadLine();
        int numOfLine = 0;
        bool endOfLine = false;

        while (!endOfLine)
        {
            if (text != null)
            {
                numOfLine++;
                parseLine(text, numOfLine, 2);
                text = reader.ReadLine();
            }
            else
            {
                endOfLine = true;
                reader.Close();
            }
        }

        print("Position Translation Matrix" + PositionTransloationMatrix);

	}

    private void parseLine(String text, int numOfLine, int type)
    {
        String spiltPattern = ",";
        String[] elements = text.Split(spiltPattern.ToCharArray());
        int count = 0;

        for(int i = 0; i < elements.Length; i++)
        {
            if(elements[i].Length > 0)
            {
                switch (type)
                {
                    case 0:
                        PositiontransformationMatrix[numOfLine - 1, count] = float.Parse(elements[i]);
                        break;
                    case 1:
                        PositionRotationMatrix[numOfLine - 1, count] = float.Parse(elements[i]);
                        break;
                    case 2:
                        PositionTransloationMatrix[numOfLine - 1, count] = float.Parse(elements[i]);
                        break;
				}
                count++;
            }
        }
    }

    private void writeMatrixToFile()
    {
        //transformation matrix
        StreamWriter matrixWriter = File.CreateText(PositiontransformationFilename);
        String text = "";

        for(int i = 0; i < 4; i++)
        {
            text = "";
            text = PositiontransformationMatrix[i, 0].ToString();
            for (int j = 1; j < 4; j++)
                text += "," + PositiontransformationMatrix[i, j];
            matrixWriter.WriteLine(text);
        }

        matrixWriter.Close();

		//rotation matrix
		matrixWriter = File.CreateText(PositionrotationFilename);
        text = "";

        for (int i = 0; i < 4; i++)
        {
            text = "";
            text = PositionRotationMatrix[i, 0].ToString();
            for (int j = 1; j < 4; j++)
                text += "," + PositionRotationMatrix[i, j];
            matrixWriter.WriteLine(text);
        }

        matrixWriter.Close();

		//translation matrix
		matrixWriter = File.CreateText(PositiontranslationFilename);
        text = "";

        for (int i = 0; i < 4; i++)
        {
            text = "";
            text = PositionTransloationMatrix[i, 0].ToString();
            for (int j = 1; j < 4; j++)
                text += "," + PositionTransloationMatrix[i, j];
            matrixWriter.WriteLine(text);
        }

        matrixWriter.Close();
	}
	
}
