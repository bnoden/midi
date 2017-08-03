(()=>'strict-mode')();

(() => {
  const audioContext = new AudioContext();

  const play = (delay, pitch, duration) => {
    let startTime = audioContext.currentTime + delay;
    let endTime = startTime + duration;
  
    const filter = audioContext.createBiquadFilter();
    filter.connect(audioContext.destination);
    filter.type = 'highpass';
    filter.frequency.value = 10000;
    
    filter.frequency.setValueAtTime(10000, startTime);
    filter.frequency.linearRampToValueAtTime(500, endTime);
  
    const oscillator = audioContext.createOscillator();
    oscillator.connect(filter);
  
    oscillator.type = 'sawtooth';
    oscillator.detune.value = pitch * 100;
  
    oscillator.start(startTime);
    oscillator.stop(endTime);
}

  play(0, 3, 0.5);
  play(1, 10, 0.5);
  play(2, 15, 0.5);
}());
