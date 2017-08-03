(()=>'strict-mode')();

const audioContext = new AudioContext();

const play = (delay, pitch, duration) => {
  let startTime = audioContext.currentTime + delay;
  let endTime = startTime + duration;

  const oscillator = audioContext.createOscillator();
  //oscillator.connect(audioContext.destination);
  const filter = audioContext.createBiquadFilter();
  
  filter.type = 'highpass';
  filter.frequency.value = 10000;
  filter.connect(audioContext.destination);
  oscillator.connect(filter);

  oscillator.type = 'sawtooth';
  oscillator.detune.value = pitch * 100;

  oscillator.start(startTime);
  oscillator.stop(endTime);
}

play(0, 3, 0.5);
play(1, 10, 0.5);
play(2, 15, 0.5);