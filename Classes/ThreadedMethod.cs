/*
 * by Swen Kooij aka Kirk - swenkooij@gmail.com 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

/// <summary>
/// Makes starting a method in a seperated thread just a little bit easier.
/// </summary>
class ThreadedMethod
{
    /// <summary>
    /// Holds an instance of the ParametizedThreadStart delegate in case the method has paramters.
    /// </summary>
    private ParameterizedThreadStart pStart;

    /// <summary>
    /// Holds an instance of the ThreadStart delegate in case the method doesn't have any parameters.
    /// </summary>
    private ThreadStart tStart;

    /// <summary>
    /// Class constructor if you want to start a method with parameters.
    /// </summary>
    /// <param name="_pStart">The name of the method, all parameters are object. See MSDN documentation on ParameterizedThreadStart.</param>
    public ThreadedMethod(ParameterizedThreadStart _pStart)
    {
        pStart = _pStart;
    }

    /// <summary>
    /// Class constructor if you want to start a method without parameters.
    /// </summary>
    /// <param name="_tStart">The name of the method that needs to be started in a seperated thread.</param>
    public ThreadedMethod(ThreadStart _tStart)
    {
        tStart = _tStart;
    }

    /// <summary>
    /// Starts the method in a new thread.
    /// </summary>
    public void Start()
    {
        if (pStart == null)
        {
            Thread Th = new Thread(tStart);
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Th.Start();
        }
        else
        {
            Thread Th = new Thread(pStart);
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Th.Start();
        }
    }
}

