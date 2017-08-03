(()=>'strict-mode')();

const audioContext = new AudioContext();
const oscillator = audioContext.createOscillator();

oscillator.connect(audioContext.destination);

oscillator.type = 'sawtooth';
oscillator.frequency.value = 220;

oscillator.start(audioContext.currentTime);
oscillator.stop(audioContext.currentTime + 2);
