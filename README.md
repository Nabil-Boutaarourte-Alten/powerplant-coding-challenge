# powerplant-coding-challenge
Coding challenge made for GEM (ENGIE) 

First things first clone the repository on your machine. Afterwards you can run the application. The API is exposed on the 8888 port. Using postman or swagger you can test the Calculate endpoint which is a POST method that requires a JSON Object (the payload).

Here is an example of a Payload that you need to send to test the Calculate endpoint:
{
  "load": 480,
  "fuels":
  {
    "gas": 13.4,
    "kerosine": 50.8,
    "co2": 20,
    "wind": 60
  },
  "powerplants": [
    {
      "name": "gasfiredbig1",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredbig2",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredsomewhatsmaller",
      "type": "gasfired",
      "efficiency": 0.37,
      "pmin": 40,
      "pmax": 210
    },
    {
      "name": "tj1",
      "type": "turbojet",
      "efficiency": 0.3,
      "pmin": 0,
      "pmax": 16
    },
    {
      "name": "windpark1",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 150
    },
    {
      "name": "windpark2",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 36
    }
  ]
}

I've removed the (euro/Mwh) after each fuel for convenience. 

The endpoint should return a list of JSON objects containing the name of the powerplant and how much power it should deliver (p).

An example of such a response on postman:
![image](https://user-images.githubusercontent.com/129526166/229152725-c3af0788-b9a0-4320-809a-b4688252c1a9.png)
