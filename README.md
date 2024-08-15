# A GAME OF ICE AND FIRE
En este juego vas a elegir a tu personaje favorito de Game Of Thrones y lo haras pelear contra una maquina
## Modo de juego
Debes elegir 1 de los 10 personajes generados, ten en cuenta que no todos son iguales, tienes distintos tipos de peleadores y cada uno de ellos tiene mejor dominio de habilidades especificas.
## Tipos de personajes:
* **Defensa:** Posee puntos extra en fuerza y armadura.
* **Soldado:** Puntos extras en velocidad y fuerza.
* **Medico:** Mejoria en destreza y armadura.
* **Espia:** Mayor puntaje en velocidad y destreza.
## Implementacion de API
Para el juego decidi utilizar la [Game of Thrones Quotes API](https://gameofthronesquotes.xyz) esta se encarga de que al momento de la generacion de personajes, me brinde el nombre de un personaje de Game Of Thrones y una frase iconica del mismo, si bien esta me brinda mas informacion, decidi utilizar solamente estos dos datos.
El endpoint que utilice es el siguiente:
[https://api.gameofthronesquotes.xyz/v1/random](https://api.gameofthronesquotes.xyz/v1/random)
Y el cuerpo de la respuesta es esta:
```json
{
  "sentence": "Three victories don't make you a conqueror.",
  "character": {
    "name": "Jaime Lannister",
    "slug": "jaime",
    "house": {
      "name": "House Lannister of Casterly Rock",
      "slug": "lannister"
    }
  }
}
