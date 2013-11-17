/*
 03. Write a script that finds the biggest of
 three integers using nested if statements.
*/

function GetBiggestFromThreeNumbers (first, second, third) {
	
	if (Number.isNaN(first) || Number.isNaN(second) || Number.isNaN(third)) {
		return "Error! There is some incorrect input value!";
	}

	if (first > second) {

        if (second > third) {

            return "Biggest number: " + first;
        }
        else if (third > second) {
          
            if (third > first) {
              
                return "Biggest number: " + third;
            }
            else {
                
                return "Biggest number: " + first;
            }
        }
    }
    else if (second > third) {

        return "Biggest number: " + second;
    }
    else {

		return "Biggest number: " + third;
    }
}


(function Solve () {
	
	console.log(GetBiggestFromThreeNumbers(1, 2, 3));

	console.log(GetBiggestFromThreeNumbers(-1, -2, -3));

	console.log(GetBiggestFromThreeNumbers(1.23, -2.23, 3.23));

	console.log(GetBiggestFromThreeNumbers(-5.23, 2.23, -1));
	
}).call(this);