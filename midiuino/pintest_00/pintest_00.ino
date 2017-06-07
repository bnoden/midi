const int clockPin = 10;
const int latchPin = 9;
const int dataPin = 8;

void setup() {
  pinMode(dataPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(latchPin, OUTPUT);
}

void loop() {
  digitalWrite(latchPin, LOW);
  shiftOut(dataPin, clockPin, MSBFIRST, B01010101);
  digitalWrite(latchPin, HIGH);
}
