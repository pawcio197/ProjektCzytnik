/*
 * -----------------------------------------------------------------------------------------
 *             MFRC522      Arduino       Arduino   Arduino    Arduino          Arduino
 *             Reader/PCD   Uno/101       Mega      Nano v3    Leonardo/Micro   Pro Micro
 * Signal      Pin          Pin           Pin       Pin        Pin              Pin
 * -----------------------------------------------------------------------------------------
 * RST/Reset   RST          9             5         D9         RESET/ICSP-5     RST
 * SPI SS      SDA(SS)      10            53        D10        10               10
 * SPI MOSI    MOSI         11 / ICSP-4   51        D11        ICSP-4           16
 * SPI MISO    MISO         12 / ICSP-1   50        D12        ICSP-1           14
 * SPI SCK     SCK          13 / ICSP-3   52        D13        ICSP-3           15
 */

// Żeby działało Wi-Fi: odkomentować!

#include <SPI.h>
#include <MFRC522.h>
//#include <RestClient.h>
#include <ArduinoJson.h>

#define SS_PIN 10
#define RST_PIN 9
#define RELAY_PIN 7


MFRC522 rfid(SS_PIN, RST_PIN);
//RestClient api = RestClient("192.168.100.100", 80);
//String sciezkaDoApi = "/User/ValidateUser";

void setup() {
  Serial.begin(9600);
  SPI.begin();
  rfid.PCD_Init();
  rfid.PCD_SetAntennaGain(rfid.RxGain_max);
  //api.begin("SSID", "hasło");
  //api.dhcp();
  pinMode(RELAY_PIN, OUTPUT);
}

int b[4];

void loop() {
  if (rfid.PICC_IsNewCardPresent())
  {
    if (!rfid.PICC_ReadCardSerial()) {Serial.println("Błąd odczytu ID"); return;}
    Serial.print("UID: ");
    for(int i = 0; i<4; i++)
    {
      b[i] = rfid.uid.uidByte[i];
      Serial.print(b[i]);
      Serial.print(" ");
    }
    Serial.println("");
    Serial.print("Sprawdzanie dostępu... ");
    if (checkAccessPermission()) 
    {
      Serial.println("OK!");
      Serial.println("");
      digitalWrite(RELAY_PIN, HIGH);
      delay(5000);
      digitalWrite(RELAY_PIN, LOW);
    }
    else 
    {
      Serial.println("Błąd odczytu!!");
      Serial.println("");
    }
    rfid.PICC_HaltA();
  }

  //api.maintain();
}

bool checkAccessPermission() {
  /*String response = "";
  String query = "{\"id0\": " + b[0] + ", \"id1\": " + b[1] + ", \"id2\": " + b[2] + ", \"id3\": " + b[3] + "}";

  com.setContentType = "application/json";
  int statusHTTP = com.post(sciezkaDoApi.c_str(), query.c_str(), &response);
  
  if (statusHTTP != 200) return false;
  else 
  {
    response.replace(" ","");
    JsonObject& root = jsonBuffer.parseObject(myInput);
    return root["Success"];
  }
  */
  if (b[0] == 186 && b[1] == 160 && b[2] == 98 && b[3] == 161) return true;
  else return false;
}
