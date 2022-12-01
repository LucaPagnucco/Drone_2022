# Drone_2022

GRUPPO:

Luca Pagnucco

Carlo Pavon

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

Il programma simula il funzionamento di un client installato all'interno di un drone

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

MQTT:

Il programma si appoggia su un broker esterno "mosquitto" grazie a docker --> COMANDO: "docker run -p 1883:1883 -p 9001:9001 eclipse-mosquitto:1.6".
Quindi si collega alla macchina stessa con IP "127.0.0.1".

Esistono 2 topic: 
<ul>
    <li>"/drone_1/<i>sensore</i>" per la pubblicazione dei dati ricavati da un sensore --> il programma pubblica su questo topic;</li>
    <li>"/drone_1/commands" per l'invio dei comandi al drone --> il programma è iscritto a questo topic.</li>
</ul>
P.S. se fosse il client di un altro drone, i topic cambierebbero in drone_2, _3,...

Per la pubblicazione dei dati si è deciso di sfruttare il flag retain in modo che, se un client si iscrive a "/drone_1/#" gli vengano inviati gli ultimi valori rilevati di ogni drone.

Per i test di ricezione dati e invio comandi si è deciso di usare un altro client MQTT: "MQTT.fx".