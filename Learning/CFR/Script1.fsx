let claims: (int * int) [] = [|1,2; 1,3; 1,4; 1,5; 1,6; 1,1; 2,2; 2,3; 2,4; 2,5; 2,6; 2,1|]
let to_the_right_of x = claims.[Array.findIndex ((=) x) claims + 1 ..]

to_the_right_of (1,4)

//val claims : (int * int) [] =
//  [|(1, 2); (1, 3); (1, 4); (1, 5); (1, 6); (1, 1); (2, 2); (2, 3); (2, 4);
//    (2, 5); (2, 6); (2, 1)|]
//val to_the_right_of : int * int -> (int * int) []
//val it : (int * int) [] =
//  [|(1, 5); (1, 6); (1, 1); (2, 2); (2, 3); (2, 4); (2, 5); (2, 6); (2, 1)|]