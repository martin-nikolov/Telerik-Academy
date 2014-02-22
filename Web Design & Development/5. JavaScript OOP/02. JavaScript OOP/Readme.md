## JavaScript OOP

1. Write a hierarchy of classes to simulate vehicles
    * All **vehicles** should have speed and propulsion units (things which make them move) and a Accelerate method, which should update their speed by summing it with the acceleration of their propulsion units
    * Each **propulsion unit** can produce acceleration (change in speed). There should be three types of propulsion units - wheels, propelling nozzles and propellers
        * A **wheel** should have a radius and the acceleration it produces should be equal to its perimeter
        * A **propelling nozzle** should have power and an afterburner switch. The acceleration the nozzle should produce as much acceleration as it has power, but if the afterburner is on it should produce double acceleration.
        * A **propeller** should have a number of fins and a spin direction. The acceleration a propeller produces should by default be equal to the number of fins it has. The spin direction should be clockwise and counter-clockwise. If the spin direction is counter-clockwise, the acceleration the propeller produces should be negative, if the spin direction is clockwise, the acceleration should be positive.
    * There should be land, air and water vehicles.
        * **Land vehicles** should have 4 wheels, air vehicles should have 1 propelling nozzles and water vehicles should have a customizable number of propellers (passed in the constructor).
        * **Air vehicles** should have the ability to switch on/off their afterburners.
        * **Water vehicles** should have the ability to change the spin direction of their propellers.
        * Implement one additional **amphibious vehicle**. It should both have a propeller (so it can move on water) and wheels (so it can move on land). The amphibious vehicle should be able to switch between land and water mode and it's speed property and Accelerate method should respectively depend on its wheels in the first case and on its propeller in the second case
