#include <LiquidCrystal.h>
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

const uint16_t x1 = A0;
const uint16_t y2 = A1;
const uint16_t x2 = A2;
const uint16_t y1 = A3;

void setup() {
  lcd.begin(16,2);
  lcd.clear();
}

uint16_t readX() {
  pinMode(y1, OUTPUT);
  pinMode(x2, INPUT);
  pinMode(y2, OUTPUT);
  pinMode(x1, INPUT);
  digitalWrite(y1, LOW);
  digitalWrite(y2, HIGH);
  delay(5);
  return analogRead(x2);
}

uint16_t readY() {
  pinMode(y1, INPUT);
  pinMode(x2, OUTPUT);
  pinMode(y2, INPUT);
  pinMode(x1, OUTPUT);
  digitalWrite(x2, LOW);
  digitalWrite(x1, HIGH);
  delay(5);
  return analogRead(y1);
}

void loop() {
  lcd.setCursor(0,0);
  lcd.print("X ");lcd.print(readX());
  lcd.setCursor(0,1);
  lcd.print("Y ");lcd.print(readY());
  delay (200);
}
