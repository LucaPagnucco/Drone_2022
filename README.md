# Drone_2022

GRUPPO:

Luca Pagnucco

Carlo Pavon

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

MQTT:

Il programma pubblica su un topic 'drone_1/<i>sensore</i>' ed è iscritto ad un topic 'drone_1/commands' per la ricezione dei comandi

Invia posizione (latitudine e longitudine) e la velocità

Legge i comandi inviati sul topic 'drone_1/commands'

Utilizza il retain per i dati inviati