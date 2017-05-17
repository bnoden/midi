#include <LiquidCrystal.h>
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

const uint16_t x1 = A0;
const uint16_t y2 = A1;
const uint16_t x2 = A2;
const uint16_t y1 = A3;

void setup() {
  lcd.begin(16,2);
  lcd.clear();
  lcd.setCursor(0,0); lcd.print("X");
  lcd.setCursor(0,1); lcd.print("Y");
  lcd.setCursor(8,0);
  lcd.print("(c)1983");
  lcd.setCursor(8,1);
  lcd.print("Nintendo");
}

void readX() {
  pinMode(y1, OUTPUT);
  pinMode(x2, INPUT);
  pinMode(y2, OUTPUT);
  pinMode(x1, INPUT);
  digitalWrite(y1, LOW);
  digitalWrite(y2, HIGH);
  delay(5);
  if (analogRead(x2)<505||analogRead(x2)>509) {
    lcd.setCursor(2,0);
    lcd.print(analogRead(x2));
  }
}

void readY() {
  pinMode(y1, INPUT);
  pinMode(x2, OUTPUT);
  pinMode(y2, INPUT);
  pinMode(x1, OUTPUT);
  digitalWrite(x2, LOW);
  digitalWrite(x1, HIGH);
  delay(5);
  if (analogRead(y1)<505||analogRead(y1)>509) {
    lcd.setCursor(2,1);
    lcd.print(analogRead(y1));
  }
}

void loop() {
  if (analogRead(x2)<505||analogRead(x2)>509) {
    readX();
    readY();
  }
  delay (200);
}
