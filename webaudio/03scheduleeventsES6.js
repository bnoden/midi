(()=>'strict-mode')();

const audioContext = new AudioContext();

const play = (delay, pitch, duration) => {
  const oscillator = audioContext.createOscillator();
  oscillator.connect(audioContext.destination);
  oscillator.type = 'sawtooth';
  
  oscillator.frequency.value = 440;
  oscillator.detune.value = pitch*100;
  
  oscillator.start(audioContext.currentTime+delay);
  oscillator.stop(audioContext.currentTime+delay+duration);
}

play(0, 3, 0.5);
play(1, 10, 0.5);
play(2, 15, 0.5);