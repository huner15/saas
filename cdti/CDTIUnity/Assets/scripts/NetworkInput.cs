﻿using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System;
using Example;
public class NetworkInput : MonoBehaviour {

    TcpListener server = null;
    NetworkStream stream;

    public Sprite airTrafficDirectional, airTrafficNonDirectional, proximateTrafficDirectional, proximateTrafficNonDirectional, resolutionAdvisoryDirectional, trafficAdvisoryDirectional;
    public GameObject aircraftBuilder;
    private System.Collections.Generic.List<GameObject> aircraft = new System.Collections.Generic.List<GameObject>();
    private System.Collections.Generic.List<GameObject> aircraftHidden = new System.Collections.Generic.List<GameObject>();

    public int maxRange = 20;


    // Use this for initialization
    void Start () {
        Int32 port = 13000;
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");

        // TcpListener server = new TcpListener(port);
        server = new TcpListener(localAddr, port);

        // Start listening for client requests.
        server.Start();

        Console.WriteLine("waiting fr a connection... ");

        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Connected");

        stream = client.GetStream();


    }
	
	// Update is called once per frame
	void Update () {

        //try to read in the client info here.
        if(stream.DataAvailable)
        {
            intake(CDTIReport.Deserialize(stream));
        }
	}

    private void  intake(CDTIReport report)
    {
        clearPlanes();

        foreach (CDTIPlane plane in report.Planes)
        {
            AddToScreen(plane);
        }


    }

    private void AddToScreen(CDTIPlane plane)
    {
        GameObject toAdd;
        if (aircraftHidden.Count > 0)
        {
            toAdd = aircraftHidden[0];
            aircraftHidden.Remove(toAdd);
        }
        else
        {
            toAdd = Instantiate(aircraftBuilder) as GameObject;
        }


        toAdd.GetComponent<SpriteRenderer>().sprite = getCorrectSprite(plane);
        toAdd.GetComponent<Transform>().position = figurePositon(plane);




        aircraft.Add(toAdd);
        //throw new NotImplementedException();
    }

    private Vector3 figurePositon(CDTIPlane plane)
    {
        Vector3 positon;

        positon.x = plane.Position.X/maxRange*5;
        positon.y = plane.Position.Y/maxRange*5;
        positon.z = 0;
        //add writing for the elevation later
        return positon;
       // throw new NotImplementedException();
    }

    private Sprite getCorrectSprite(CDTIPlane plane)
    {

        Vector zeroVector = new Vector();
        zeroVector.X = 0;
        zeroVector.Y = 0;
        zeroVector.Z = 0;
        switch (plane.severity) {
            case (CDTIPlane.Severity.PROXIMATE):
                if (plane.Velocity == zeroVector)
                {
                    return proximateTrafficNonDirectional;
                }
                else
                    return proximateTrafficDirectional;
            case (CDTIPlane.Severity.TRAFFIC):
                return trafficAdvisoryDirectional;
            case (CDTIPlane.Severity.RESOLUTION):
                return resolutionAdvisoryDirectional;

            default:
                if (plane.Velocity == zeroVector)
                {
                    return airTrafficNonDirectional;
                }
                else
                    return airTrafficDirectional;
                
        }
            
                

        throw new NotImplementedException();
    }

    private void clearPlanes()
    {
        foreach(GameObject plane in aircraft)
        {
            plane.GetComponent<SpriteRenderer>().sprite = null;
            aircraftHidden.Add(plane);
           // Destroy(plane);
            
        }
        aircraft.Clear();


       // throw new NotImplementedException();
    }
}