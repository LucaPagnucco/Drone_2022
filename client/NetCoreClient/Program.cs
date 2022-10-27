using System;
using NetCoreClient.Sensors;
using NetCoreClient.Protocols;

// define sensors
List<ISensorInterface> sensors = new();
sensors.Add(new VirtualSpeedSensor());
sensors.Add(new VirtualPositionSensor());

// define protocol
// IProtocolInterface protocol = new Http("http://localhost:8011/drones/1/status");
IProtocolInterface protocol = new Http("http://192.168.101.39:8011/drones/1/status");

// send data to server
while (true)
{
    /* le interfaccie servono perché sennò dovresti creare una lista di ogni sensore (VirtualSpeedSensore, VirtualPositionSensor,...).
    Invece puoi fare solo una lista di ISensorInterface che, tra l'altro garantisce la presenza del metodo ToJson (sennò dovresti fare un foreach per ogni sensore)*/
    foreach (ISensorInterface sensor in sensors)
    {
        // in questo caso, sensor non si sa che tipo di sensore sia, però avrà di sicuro un meotodo ToJson che lo serializzerà (siccome fa parte dell'interfaccia)
        var sensorValue = sensor.ToJson();

        //stessa cosa per i protocolli, lui qui non sa che protocollo sta usando, solo che ha un metodo Send che invia dei dati
        protocol.Send(sensorValue);

        Console.WriteLine("Data sent: " + sensorValue);

        Thread.Sleep(1000);
    }

}