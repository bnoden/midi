#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

void setup() {
  lcd.begin(16, 2);
}

void loop() {
  int t = 0;
  while(1) {
    lcd.print(t);
    delay(1000);
    lcd.clear();
    delay(1000);
    t++;
  }
}
