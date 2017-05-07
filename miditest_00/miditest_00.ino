class MidiTest {
  private:
    byte channel, note, velocity, noteOn;
    
  public:
    MidiTest(){
      channel=0x01; note=0x3c; velocity=0x00;
      noteOn = 0x90+(channel-1);
    };
    MidiTest(byte c, byte n, byte v) {
      channel = c; note = n; velocity = v;
      noteOn = 0x90+(c-1);
    }
    
    byte getChannel() {return channel;}
    byte getNote() {return note;}
    byte getVelocity() {return velocity;}
    byte getNoteOn() {return 0x90+(channel-1);}
    
    void setChannel(byte c) {channel=c;}
    void setNote(byte n) {note = n;}
    void setVelocity(byte v) {velocity = v;}
    void setNoteOn(byte o) {noteOn = o;}
    
    void Out() { Serial.write("{noteOn}\n{note}\n{velocity}\n"); }
};

void setup() { Serial.begin(31250); }

void loop() {
   MidiTest mn;
   
   for (byte i = 0x3c; i < 0x48; i++) { // 60 to 72
    mn.setNote(i);
    mn.Out();
    delay(60);
    mn.setVelocity(0);
    mn.Out();
    delay(60);
   }
}
