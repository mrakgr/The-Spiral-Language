let mutable chips = 0
for i=0 to 2 do
    let ante = pown 2 i
    for hand_number = 0 to 17 do
        chips <- chips + ante * (hand_number % 2 + 1)

pown 6 5


let seconds_in_rl = 60.0 * 5.0 * 1.0 // 5 minutes
let hours_in_year = 8760.0
let seconds_in_year = 60.0 * 60.0 * hours_in_year
let speedup = pown 10.0 11
let years = speedup * seconds_in_rl / seconds_in_year
let million_years = years / pown 10.0 6

(7 * 18 * 3 + 54) / 54

let marathon_length = 42195.0 
let speed = 10.0 / 100.0
let marathon_time_in_seconds = marathon_length * speed
marathon_time_in_seconds / 60.0

105.0*1.30

10_000_000