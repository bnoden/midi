// Example 23.1

#include <LiquidCrystal.h> // we need this library for the LCD commands
LiquidCrystal lcd(12, 11, 5, 4, 3, 2); // your pins may vary
int x,y = 0;

void setup()
{
  lcd.begin(16,2); // need to specify how many columns and rows are in the LCD unit
  lcd.clear();
}

int readX() // returns the value of the touch screen's X-axis
{
  int xr=0;
  pinMode(14, INPUT);   // A0
  pinMode(15, OUTPUT);    // A1
  pinMode(16, INPUT);   // A2
  pinMode(17, OUTPUT);   // A3
  digitalWrite(15, LOW); // set A1 to GND
  digitalWrite(17, HIGH);  // set A3 as 5V
  delay(5); // short delay is required to give the analog pins time to adjust to their new roles
  xr=analogRead(0); 
  return xr;
}

int readY() // returns the value of the touch screen's Y-axis
{
  int yr=0;
  pinMode(14, OUTPUT);   // A0
  pinMode(15, INPUT);    // A1
  pinMode(16, OUTPUT);   // A2
  pinMode(17, INPUT);   // A3
  digitalWrite(14, LOW); // set A0 to GND
  digitalWrite(16, HIGH);  // set A2 as 5V
  delay(50); // short delay is required to give the analog pins time to adjust to their new roles
  yr=analogRead(1);
  return yr;
}

void loop()
{
  lcd.setCursor(0,0);
  lcd.print("x=");
  x=readX();
  lcd.print(x, DEC);
  y=readY();
  lcd.setCursor(5,0);
  lcd.print(" y=");
  lcd.print(y, DEC);
  lcd.setCursor(0,1);
  char cr = 0xa9;
  lcd.print(cr);
  lcd.print(" 1993 Nintendo");
  delay (200);
}
