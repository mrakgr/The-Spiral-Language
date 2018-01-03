let rec just_one state = function
    | true :: xs -> if state then false else just_one true xs
    | false :: xs -> just_one state xs
    | [] -> true

just_one false [] // true
just_one false [true;false] // true
just_one false [false;false] // true
just_one false [false;true;false] // true
just_one false [false;false;true] // true
just_one false [true;false;true] // false
