﻿// Classes and structures being serialized

// Generated by ProtocolBuffer
// - a pure c# code generation implementation of protocol buffers
// Report bugs to: https://silentorbit.com/protobuf/

// DO NOT EDIT
// This file will be overwritten when CodeGenerator is run.
// To make custom modifications, edit the .proto file and add //:external before the message line
// then write the code and the changes in a separate file.
using System;
using System.Collections.Generic;

namespace Example
{
    /// <summary>
    /// <para>*</para>
    /// <para> * Coordinate System</para>
    /// <para> * X: Positive is Right along the CDTI, Negative is Left.</para>
    /// <para> * Y: Positive is Up along the CDTI, Negative is Down.</para>
    /// <para> * Z: Positive is above the ship in CDTI, Negative is below.</para>
    /// <para></para>
    /// </summary>
    public partial class Vector
    {
        public Vector() { }
        public Vector(float x, float y, float z)
        {
            N = x;
            E = y;
            D = z;
        }
        public float N { get; set; }

        public float E { get; set; }

        public float D { get; set; }

   /*     public float X
        {
            get { return N; }
            set { N = value; }
        }
        public float Y
        {
            get { return E; }
            set { E = value;}
        }
        public float Z
        {
            get { return D; }
            set { D = value; }
        } */

    }

    /// <summary>
    /// <para>*</para>
    /// <para> * Represents one plane in the CDTI message.</para>
    /// <para></para>
    /// </summary>
    public partial class CDTIPlane
    {
        public enum Severity
        {
            PROXIMATE = 0,
            TRAFFIC = 1,
            RESOLUTION = 2,
        }

        public string Id { get; set; }

        /// <summary> ID of target</summary>
        public Example.Vector Position { get; set; }

        /// <summary>
        /// <para> Relative to Ownship.</para>
        /// <para> X and Y are in Nautical Miles, Z is in feet</para>
        /// </summary>
        public Example.Vector Velocity { get; set; }

        /// <summary> North East and Down, in Feet/Second</summary>
        public Example.CDTIPlane.Severity severity { get; set; }

    }

    /// <summary>
    /// <para>*</para>
    /// <para> * CDTI Report, sent once a second by the SAA application.</para>
    /// <para> * Contains a list of planes, and an optional message.</para>
    /// <para></para>
    /// </summary>
    public partial class CDTIReport
    {
        public enum Severity
        {
            PROXIMATE = 0,
            TRAFFIC = 1,
            RESOLUTION = 2,
        }

        public long Timestamp { get; set; }

        /// <summary> UTC timestamp</summary>
        public Example.CDTIPlane Ownship { get; set; }

        /// <summary> Ownship id and velocity, position is 0</summary>
        public string AdvisoryMessage { get; set; }

        /// <summary> The string to display</summary>
        public Example.CDTIReport.Severity AdvisoryLevel { get; set; }

        /// <summary> The warning level</summary>
        public List<Example.CDTIPlane> Planes { get; set; }

    }

}