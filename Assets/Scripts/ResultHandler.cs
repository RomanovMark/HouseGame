using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultHandler : MonoBehaviour
{
    public Text Price;
    public Text EnergyConversation;

    public float EnergyConversationResult; // Oman talon tulos
    public float HeatingPowerNeeds; //The need for heating power// F(lämmitys W)

    [Header("EnergyLoss")]
    public float CurrentTemperatureLoses; // Rakennusvaipan lämpöhäviöteho //First house around 40000 kW // Ominaistehon tarve on 21,7  W/m^3
    public float HeatLossExternlWall; // Lämpöhäviö ulkoseinien läpi W
    public float HeatLossUpperBottom; // Lämpöhäviö yläpohjan läpi W
    public float HeatLossBottom; // Lämpöhäviö alapohjan läpi W
    public float HeatLossWindow;// Lämpöhäviö ikkunoiden läpi W
    public float HeatLossFrontDoor; // Lämpöhäviö ulko-ovien läpi
    [Header("HeatingPower")]
    public float HeatingPower; //The need for space heating power // 13,6 kW
    public float HeatingTransfer; //Rakennusosan lämmönläpäisykerroin [W/(m2°C]
    public float HouseArea; // Rakennusosan pinta-ala [m2]
    public float IndoorTemperature; // Sisäilman lämpötila C
    public float OutdoorTemperature; // Mitoittava ulkolämpötila C
    [Header("HeatLoss")]
    public float HeatLoss; //Vuotoilman lämpöhäviöteho // First house 3 kW
    public float AirDensity; // Ilman tiheys [kg/m3]
    public float AirHeatCapacity; // Ilman ominaislämpökapasiteetti [kJ/kg°C]
    public float LeakingAirFlow; // Vuotoilmavirta [m3/s]
    [Header("LKVPower")]
    public float LKVPower; //Lämpimän käyttöveden tehon tarve // First house 420kWh
    public float HeatingEnergy; // Lämmitysenergia (50 °C muutos) [kWh/m3]
    public float HotWaterConsumption; // Lämpimän käyttöveden kulutus [m^3/a]



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
