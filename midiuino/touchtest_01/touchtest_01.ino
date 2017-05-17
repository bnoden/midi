#include <LiquidCrystal.h>
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

const int x1 = A0;
const int y2 = A1;
const int x2 = A2;
const int y1 = A3;

void setup() {
  lcd.begin(16,2);
  lcd.clear();
}

int readX() {
  pinMode(y1, INPUT);
  pinMode(x2, OUTPUT);
  pinMode(y2, INPUT);
  pinMode(x1, OUTPUT);
  digitalWrite(x2, LOW);
  digitalWrite(x1, HIGH);
  delay(5);
  return analogRead(y1);
}

int readY() {
  pinMode(y1, OUTPUT);
  pinMode(x2, INPUT);
  pinMode(y2, OUTPUT);
  pinMode(x1, INPUT);
  digitalWrite(y1, LOW);
  digitalWrite(y2, HIGH);
  delay(5);
  return analogRead(x2);
}

void loop() {
  int y = readY();
  int x = readX();
  lcd.setCursor(0,0);
  lcd.print("X ");lcd.print(x);
  lcd.setCursor(0,1);
  lcd.print("Y ");lcd.print(y);
  delay (200);
}
