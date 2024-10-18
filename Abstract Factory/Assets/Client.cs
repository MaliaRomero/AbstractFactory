/*﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    //Variables
    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    //Validate Data
    void Start()
    {
        //Inputs
        NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);
        Engine = Cargo;

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = NumberOfWheels;
        requirements.Engine = Engine;
        requirements.Passengers = Passengers;

        //Call GetVehicle
        IVehicle v = GetVehicle(requirements);
        Debug.Log(v);
    }

    //Get Vehicle from IVehicle script that contains all the vehicle classes
    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Client : MonoBehaviour
{
    // Variables
    public TMP_InputField numberOfWheelsInput;
    public TMP_InputField passengersInput;
    public TMP_Text resultText;
    public bool engine;
    public bool cargo;

    private int numberOfWheels;
    private int passengers;

    // Validate Data and Get Vehicle
    public void GetVehicleButton()
    {
        // Parse inputs
        int.TryParse(numberOfWheelsInput.text, out numberOfWheels);
        int.TryParse(passengersInput.text, out passengers);

        // Ensure minimum values
        numberOfWheels = Mathf.Max(numberOfWheels, 1);
        passengers = Mathf.Max(passengers, 1);
        engine = cargo; // Adjust as needed based on input

        VehicleRequirements requirements = new VehicleRequirements
        {
            NumberOfWheels = numberOfWheels,
            Engine = engine,
            Passengers = passengers
        };

        // Call GetVehicle
        IVehicle v = GetVehicle(requirements);

        // Display the vehicle type in the result text
        resultText.text = $"Vehicle: {v.GetType().Name}";
    }

    // Get Vehicle from IVehicle script that contains all the vehicle classes
    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Required for using Toggle

public class Client : MonoBehaviour
{
    // Variables
    public TMP_InputField numberOfWheelsInput;
    public TMP_InputField passengersInput;
    public Toggle engineToggle;
    public Toggle cargoToggle;
    public TMP_Text resultText;

    private int numberOfWheels;
    private int passengers;
    private bool engine;
    private bool cargo;

    // Validate Data and Get Vehicle
    public void GetVehicleButton()
    {
        // Parse inputs
        int.TryParse(numberOfWheelsInput.text, out numberOfWheels);
        int.TryParse(passengersInput.text, out passengers);

        // Read toggle values
        engine = engineToggle.isOn;
        cargo = cargoToggle.isOn;

        // Ensure minimum values
        numberOfWheels = Mathf.Max(numberOfWheels, 1);
        passengers = Mathf.Max(passengers, 1);

        VehicleRequirements requirements = new VehicleRequirements
        {
            NumberOfWheels = numberOfWheels,
            Engine = engine,
            Passengers = passengers
        };

        // Call GetVehicle
        IVehicle v = GetVehicle(requirements);

        // Display the vehicle type in the result text
        resultText.text = $"Vehicle: {v.GetType().Name}";
    }

    // Get Vehicle from IVehicle script that contains all the vehicle classes
    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }
}