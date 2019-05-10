# AMANCalculator

## About

This is a simple brute force optimizer that will calculate the expected value of returns from FFXI's A.M.A.N. Trove event, based on player gathered data.

Please feel free to download it and modify the constants in the program to match your expectations, then run it to see the average gil return per run.

## Assumptions

Program is optimized to use a best fit stopping algorithm that assumes whether a chest is a Noise, Thud, or Loud thud is determined at opening time, and there are no limits on how many Thuds you may encounter per run.

If the chests for A.M.A.N. Trove are theoretically pregenerated on entering, and the algorithm would never generate, say, 9 Thud chests and has a hard upper limit, then this algorithm's best fit guessing is incorrect. The only way to calculate this would be to find a player's screenshot of obtaining an unnaturally high quantity of Thud's in their run. Around the 7+ mark.

Furthermore, it is assumed the location of the Mimic is fixed at generation of the run, and thus the Tenth chest opened will ALWAYS be the mimic, and you just lucky and picked it last. There is no record too date of anyone opening 10/10 chests without a mimic appearing at all, so this is most likely a safe assumption.

## Constants

#### trials
How many trials the program will run to calculate profitability

#### sampleSize
The total sample size of your chests data, should be equal to Noises + Thuds + Loud Thuds, this is how many non mimic chests you opened

#### noiseCount
How many 'Noise's you encountered in your sample data

#### thudCount
How many 'Thud's you encountered in your sample data

#### loudThudCount
How many 'Loud Thud's you encountered in your sample data

#### noiseValue
The expected gil value of the reward out of a 'Noise' chest, on average

#### thudValue
The expected gil value of the reward out of a 'Thud' chest, on average

#### loudThudValue
The expected gil value of the reward out of a 'Loud Thud' chest, on average
