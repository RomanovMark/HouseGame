using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultHandler : MonoBehaviour
{
    public Text Price;
    public Text EnergyConversation;

    public float EnergyConversationResult; // Oman talon tulos
    public float HeatingPowerNeeds; //The need for heating power// F(l�mmitys W)

    [Header("EnergyLoss")]
    public float CurrentTemperatureLoses; // Rakennusvaipan l�mp�h�vi�teho //First house around 40000 kW // Ominaistehon tarve on 21,7  W/m^3
    public float HeatLossExternlWall; // L�mp�h�vi� ulkoseinien l�pi W
    public float HeatLossUpperBottom; // L�mp�h�vi� yl�pohjan l�pi W
    public float HeatLossBottom; // L�mp�h�vi� alapohjan l�pi W
    public float HeatLossWindow;// L�mp�h�vi� ikkunoiden l�pi W
    public float HeatLossFrontDoor; // L�mp�h�vi� ulko-ovien l�pi
    [Header("HeatingPower")]
    public float HeatingPower; //The need for space heating power // 13,6 kW
    public float HeatingTransfer; //Rakennusosan l�mm�nl�p�isykerroin [W/(m2�C]
    public float HouseArea; // Rakennusosan pinta-ala [m2]
    public float IndoorTemperature; // Sis�ilman l�mp�tila C
    public float OutdoorTemperature; // Mitoittava ulkol�mp�tila C
    [Header("HeatLoss")]
    public float HeatLoss; //Vuotoilman l�mp�h�vi�teho // First house 3 kW
    public float AirDensity; // Ilman tiheys [kg/m3]
    public float AirHeatCapacity; // Ilman ominaisl�mp�kapasiteetti [kJ/kg�C]
    public float LeakingAirFlow; // Vuotoilmavirta [m3/s]
    [Header("LKVPower")]
    public float LKVPower; //L�mpim�n k�ytt�veden tehon tarve // First house 420kWh
    public float HeatingEnergy; // L�mmitysenergia (50 �C muutos) [kWh/m3]
    public float HotWaterConsumption; // L�mpim�n k�ytt�veden kulutus [m^3/a]



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
