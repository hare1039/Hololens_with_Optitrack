using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using MathNet.Numerics.Statistics;


namespace MathNet.Examples {

  public static class MathDisplay {

    static string _buffer = string.Empty;

    public static void WriteLine() {
      Debug.Log("\n");
    }

    public static void WriteLine(string message, params object[] args) {
      Debug.Log(string.Format(message, args));
    }

    public static void Write(string message, params object[] args) {
      _buffer += string.Format(message, args);
    }

    public static void FlushBuffer() {
      WriteLine(_buffer);
      _buffer = string.Empty;
    }

  }
}
